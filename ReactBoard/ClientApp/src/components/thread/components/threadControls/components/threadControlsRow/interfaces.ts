import { IThread } from "../../../../../../global/interfaces/thread";

export interface ILinkItem {
    title: string
    onClick: () => void
}

export interface IStatisticItem {
    dataTip: string
    value: number
}

export interface IThreadControlsRowProps {
    thread: IThread
    isBottom: boolean
    boardUrlName: string
    autoRefreshEnabled: boolean
    onUpdateRequested: () => void
    onAutoRefreshToggled: () => void
}