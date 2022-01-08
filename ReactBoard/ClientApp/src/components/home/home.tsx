import React, { useEffect, useState } from 'react';
import SiteIcon from '../../assets/site-icon';
import Panel from '../../global/components/panel/panel';
import { SITE_DESCRIPTION, SITE_TITLE } from '../../global/constants/strings';
import { groupBy } from '../../global/helpers/grouper';
import { IBoard } from '../../global/interfaces/board/interfaces';
import BoardsOverviewPanel from './components/boardsOverviewPanel/boardsOverviewPanel';
import Footer from './components/footer/footer';
import './styles.scss';

const Home = () => {
    const [descriptionDismissed, setDescriptionDismissed] = useState<boolean>(false)
    const [boards, setBoards] = useState<IBoard[]>([])

    useEffect(() => {



    }, [])

    const groupedBoards = groupBy<IBoard, string>(boards, b => b.category.name)

    return (
        <div className="home-panel">
            <SiteIcon onClick={() => location.reload()} />
            {!descriptionDismissed &&
                <Panel dismissable title={SITE_TITLE} onClose={() => setDescriptionDismissed(true)}>
                    <span>{SITE_DESCRIPTION}</span>
                </Panel>
            }
            <BoardsOverviewPanel boardsGroupedByCategory={groupedBoards} />
            <Footer />
        </div>)
}

export default Home