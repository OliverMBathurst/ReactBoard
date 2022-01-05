import { IEntity } from "../common/interfaces"
import { IThread } from "../thread/interfaces"

export interface IBoardKey {
    boardId: number | null
}

export interface IBoard extends IBoardKey {
    name: string
    description: string
    suffix: string
    threads: IThread[]
}

export interface IBoardAdminMapping extends IEntity<string> {
    boardId: string
    userId: string
}

export interface INewBoard {
    name: string
    description: string
    boardUrlName: string
    isWorkSafe: boolean
    maxThreads: number
}

export interface IBoardService {
    getAllBoards: () => Promise<IBoard[]>
    getBoardByUrlName: (boardUrlName: string) => Promise<IBoard>
}