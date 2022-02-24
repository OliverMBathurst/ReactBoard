import React, { useEffect, useMemo, useState } from 'react';
import { SiteIcon } from '../../assets';
import { Panel } from '../../global/components';
import { SITE_DESCRIPTION, SITE_TITLE } from '../../global/constants/strings';
import { BoardFilter, ThreadFilter } from '../../global/enums';
import { IBoard } from '../../global/interfaces/board';
import { ICategory } from '../../global/interfaces/category';
import { IDropdownOptions, ISiteStatistic } from '../../global/interfaces/misc';
import { IFeaturedThread } from '../../global/interfaces/thread/interfaces';
import { CategoryService, HomeService, StatisticsService } from '../../services';
import { BoardCategory, Footer } from './components';
import './styles.scss';

const _categoryService = new CategoryService(), _homeService = new HomeService(), _statisticsService = new StatisticsService()

const Home = () => {
    const [descriptionDismissed, setDescriptionDismissed] = useState<boolean>(false)
    const [categories, setCategories] = useState<ICategory[]>([])
    const [featuredThreads, setFeaturedThreads] = useState<IFeaturedThread[]>([])
    const [siteStatistics, setSiteStatistics] = useState<ISiteStatistic[]>([])
    const [threadsFilter, setThreadsFilter] = useState<ThreadFilter>(ThreadFilter.ShowSFWContentOnly)
    const [boardsFilter, setBoardsFilter] = useState<BoardFilter>(BoardFilter.ShowAllBoards)

    useEffect(() => {
        let mounted = true

        _categoryService.getAll().then(c => {
            if (mounted) {
                setCategories(c)
            }
        })

        _statisticsService.getSiteStatistics().then(res => {
            if (mounted) {
                setSiteStatistics(res)
            }
        })

        return () => {
            mounted = false
        }
    }, [])

    useEffect(() => {
        let mounted = true

        _homeService.getFeaturedThreadsByFilter(threadsFilter).then(res => {
            if (mounted) {
                setFeaturedThreads(res)
            }
        })

        return () => {
            mounted = false
        }
    }, [threadsFilter])

    const shouldDisplayBoard = (board: IBoard) => {
        if (board.isWorkSafe && boardsFilter === BoardFilter.ShowNSFWBoardsOnly) {
            return false
        }

        if (!board.isWorkSafe && boardsFilter === BoardFilter.ShowSFWBoardsOnly) {
            return false
        }

        return true
    }

    const boardsDropdownOptions: IDropdownOptions = useMemo(() => {
        return {
            items: [{
                id: BoardFilter.ShowAllBoards,
                text: "Show All Boards",
                onSelect: () => setBoardsFilter(BoardFilter.ShowAllBoards)
            }, {
                id: BoardFilter.ShowNSFWBoardsOnly,
                text: "Show NSFW Boards Only",
                onSelect: () => setBoardsFilter(BoardFilter.ShowNSFWBoardsOnly)
            }, {
                id: BoardFilter.ShowSFWBoardsOnly,
                text: "Show SFW Boards Only",
                onSelect: () => setBoardsFilter(BoardFilter.ShowSFWBoardsOnly)
            }],
            defaultValue: BoardFilter.ShowAllBoards
        }
    }, [])

    const threadsDropdownOptions: IDropdownOptions = useMemo(() => {
        return {
            items: [{
                id: ThreadFilter.ShowSFWContentOnly,
                text: "Show SFW Content Only",
                onSelect: () => setThreadsFilter(ThreadFilter.ShowSFWContentOnly)
            }, {
                id: ThreadFilter.ShowNSFWContentOnly,
                text: "Show NSFW Content Only",
                onSelect: () => setThreadsFilter(ThreadFilter.ShowNSFWContentOnly)
            }, {
                id: ThreadFilter.ShowAllContent,
                text: "Show All Content",
                onSelect: () => setThreadsFilter(ThreadFilter.ShowAllContent)
            }],
            defaultValue: ThreadFilter.ShowSFWContentOnly
        }
    }, [])

    return (
        <div className="home-panel">
            <SiteIcon onClick={() => window.location.reload()} />
            {!descriptionDismissed &&
                <Panel dismissable title={SITE_TITLE} onClose={() => setDescriptionDismissed(true)}>
                    <span>{SITE_DESCRIPTION}</span>
                </Panel>
            }
            <Panel title="Boards" dropdownOptions={boardsDropdownOptions}>
                {categories.filter(c => c.boards.some(shouldDisplayBoard)).map(category => {
                    return (
                        <BoardCategory
                            key={category.id}
                            category={category.name}
                            boards={category.boards.filter(shouldDisplayBoard)}
                        />)
                })}
            </Panel>
            {featuredThreads &&
                <Panel title="Featured Threads" dropdownOptions={threadsDropdownOptions}>

                </Panel>
            }
            {siteStatistics &&
                <Panel title="Stats">
                    <table className="home-panel__statistics-table">
                        <tbody className="home-panel__statistics-table__body">
                            <tr className="home-panel__statistics-table__body__row">
                                {siteStatistics.map(stat => {
                                    return (
                                        <th key={stat.placeholder} className="home-panel__statistics-table__body__row__head">
                                            {`${stat.placeholder}: ${stat.value}`}
                                        </th>)
                                })}
                            </tr>
                        </tbody>
                    </table>
                </Panel>
            }
            <Footer />
        </div>)
}

export default Home