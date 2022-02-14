import React from 'react'
import { IThread } from '../../../../global/interfaces/thread'
import { ThreadControlsRow } from './components'
import { IThreadControlsRowProps } from './components/threadControlsRow/interfaces'
import './styles.scss'

interface IThreadControlsProps {
    thread: IThread
    boardUrlName: string
    children: React.ReactNode
    autoRefreshEnabled: boolean
    onAutoRefreshToggled: () => void
    onUpdateRequested: () => void
}

const ThreadControls = (props: IThreadControlsProps) => {
    const {
        thread,
        boardUrlName,
        children,
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
        <div className="thread-controls">
            <ThreadControlsRow {...controlsRowProps} />
            {children}
            <ThreadControlsRow {...controlsRowProps} isBottom />
        </div>)
}

export default ThreadControls