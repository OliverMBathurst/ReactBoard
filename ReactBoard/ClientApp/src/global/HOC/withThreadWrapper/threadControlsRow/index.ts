import { IThread } from '../../../interfaces/thread'
import ThreadControlsRow from './threadControlsRow'

export interface IThreadControlsRowProps {
    thread: IThread
    isBottom: boolean
    boardUrlName: string
    autoRefreshEnabled: boolean
    onUpdateRequested: () => void
    onAutoRefreshToggled: () => void
}

export { ThreadControlsRow }
