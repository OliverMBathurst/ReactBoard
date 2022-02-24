import React from 'react'
import { Link } from 'react-router-dom'
import { IThreadControlsRowProps } from '.'
import { Statistic } from '../../../components'
import BracketedLink from '../../../components/bracketedLink/bracketedLink'
import { ILinkItem } from '../../../interfaces/link'
import { IStatisticItem } from '../../../interfaces/statistic'
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
            element: <Link to={{ pathname: `/${boardUrlName}`, state: { fromHome: true } }}>Return</Link>
        },
        {
            element: <Link to={{ pathname: `/${boardUrlName}/catalog`, state: { fromHome: true } }}>Catalog</Link>
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

    const onReplyRequested = () => {
        //todo
    }

    return (
        <div className="thread-controls__row">
            {links.map(link => <BracketedLink link={link} />)}
            <BracketedLink link={{
                element: (<>
                    <input
                        type="checkbox"
                        title="Fetch new replies automatically"
                        checked={autoRefreshEnabled}
                        onChange={() => onAutoRefreshToggled()}
                    />
                    <span
                        className="thread-controls__row__link__text__auto"
                        onClick={() => onAutoRefreshToggled()}
                    >
                        Auto
                    </span>
                </>)
            }} />
            {isBottom && <BracketedLink link={{ title: "Post a Reply", onClick: onReplyRequested }} />}
            <div className="thread-controls__row__stats-container">
                {statistics.map((stat, idx) => {
                    return <Statistic item={stat} isLast={idx === statistics.length - 1} />
                })}
            </div>
        </div>)
}

export default ThreadControlsRow