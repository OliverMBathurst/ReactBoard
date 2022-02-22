import { ICategory } from "../category"
import { IEntity } from "../common"
import { IPost } from "../post"
import { IThread } from "../thread"

export interface IBoard extends IEntity<number> {
    name: string
    description: string
    categoryId: number
    isWorkSafe: boolean
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

export interface IBoardCatalog {
    items: IBoardCatalogItem[]
}

export interface IBoardCatalogItem {
    totalReplies: number
    totalImages: number
    originalPost: IPost
}

export interface IBoardService {
    getAll: () => Promise<IBoard[]>
    getBoardByUrlName: (urlName: string) => Promise<IBoard>
    createBoard: (board: INewBoard) => Promise<void>
    getCatalog: (urlName: string) => Promise<IBoardCatalog>
}