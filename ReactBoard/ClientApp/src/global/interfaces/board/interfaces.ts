import { ICategory } from "../category"
import { IEntity } from "../common"
import { IThread } from "../thread"

export interface IBoard extends IEntity<number> {
    name: string
    description: string
    category: ICategory
    urlName: string
    threads?: IThread[]
}

export interface IBoardAdminMapping extends IEntity<string> {
    boardId: string
    userId: string
}

export interface INewBoard {
    name: string
    description: string
    urlName: string
    category: ICategory
    isWorkSafe: boolean
    maxThreads: number
}

export interface IBoardService {
    getAll: () => Promise<IBoard[]>
    getBoardByUrlName: (urlName: string) => Promise<IBoard>
    createBoard: (board: INewBoard) => Promise<void>
}