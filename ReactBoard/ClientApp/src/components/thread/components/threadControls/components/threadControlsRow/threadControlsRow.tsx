import React from 'react'
import { getBoardCatalogRoute, getBoardRoute } from '../../../../../../global/helpers/routeHelper'
import { ILinkItem, IStatisticItem, IThreadControlsRowProps } from './interfaces'
import './styles.scss'

const ThreadControlsRow = (props: IThreadControlsRowProps) => {
    const {
        thread,
        isBottom,
        boardUrlName,
        autoRefreshEnabled,
        onUpdateRequested,
        onAutoRefreshToggled
    } = props

    const links: ILinkItem[] = [
        {
            title: "Return",
            onClick: () => window.location.href = getBoardRoute(boardUrlName)
        },
        {
            title: "Catalog",
            onClick: () => window.location.href = getBoardCatalogRoute(boardUrlName)
        },
        {
            title: "Bottom",
            onClick: () => window.scrollTo(0, document.body.scrollHeight)
        },
        {
            title: "Update",
            onClick: () => onUpdateRequested()
        }
    ]

    const statistics: IStatisticItem[] = [
        {
            dataTip: "Replies",
            value: thread.posts.length - 1
        },
        {
            dataTip: "Images",
            value: thread.posts.filter(p => p.image).length
        }
    ]

    return (
        <div className="thread-controls__top-row">
            {links.map(l => {
                return (
                    <span className="thread-controls__top-row__link">
                        [
                        <span
                            className="thread-controls__top-row__link__text"
                            onClick={l.onClick}
                        >
                            {l.title}
                        </span>
                        ]
                    </span>)
            })}
            <span className="thread-controls__top-row__link">
                [
                <>
                    <input
                        type="checkbox"
                        title="Fetch new replies automatically"
                        checked={autoRefreshEnabled}
                        onChange={() => onAutoRefreshToggled()}
                    />
                    <span
                        className="thread-controls__top-row__link__text__auto"
                        onClick={() => onAutoRefreshToggled()}
                    >
                        Auto
                    </span>
                </>
                ]
            </span>
            <div className="thread-controls__top-row__stats-container">
                {statistics.map((stat, idx) => {
                    return (
                        <span
                            className="thread-controls__top-row__stats-container__stat"
                            data-tip={stat.dataTip}
                        >
                            {`${stat.value}${idx !== statistics.length - 1 && "/"}`}
                        </span>)
                })}
            </div>
        </div>)
}

export default ThreadControlsRow