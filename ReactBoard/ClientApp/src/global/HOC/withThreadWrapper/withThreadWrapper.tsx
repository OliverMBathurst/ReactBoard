import React, { ComponentType } from 'react'
import { IThread } from "../../interfaces/thread"
import './styles.scss'
import { ThreadControlsRow } from './threadControlsRow'

interface IThreadWrapperProps {
    thread: IThread
    boardUrlName: string
    autoRefreshEnabled: boolean
    onAutoRefreshToggled: () => void
    onUpdateRequested: () => void
}

const withThreadWrapper = (Component: ComponentType) => {
    return (props: IThreadWrapperProps) => {
        return (
            <div className="thread-wrapper">
                <ThreadControlsRow {...props} isBottom={false} />
                <Component />
                <ThreadControlsRow {...props} isBottom />
            </div>
        )
    }
}

export default withThreadWrapper