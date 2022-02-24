import React from 'react'
import { IThread } from "../../interfaces/thread"
import './styles.scss'
import { IThreadControlsRowProps, ThreadControlsRow } from './threadControlsRow'

interface IThreadWrapperProps {
    thread: IThread
    boardUrlName: string
    autoRefreshEnabled: boolean
    onAutoRefreshToggled: () => void
    onUpdateRequested: () => void
}

const withThreadWrapper = <P extends object>(component: React.ComponentType<P>, props: IThreadWrapperProps) => {
    const {
        thread,
        boardUrlName,
        autoRefreshEnabled,
        onAutoRefreshToggled,
        onUpdateRequested
    } = props

    const controlsRowProps: IThreadControlsRowProps = {
        thread: thread,
        boardUrlName: boardUrlName,
        autoRefreshEnabled: autoRefreshEnabled,
        onUpdateRequested: onUpdateRequested,
        onAutoRefreshToggled: onAutoRefreshToggled,
        isBottom: false
    }

    return (
        <div className="thread-wrapper">
            <ThreadControlsRow {...controlsRowProps} />
            {component}
            <ThreadControlsRow {...controlsRowProps} isBottom />
        </div>
    )
}

export default withThreadWrapper