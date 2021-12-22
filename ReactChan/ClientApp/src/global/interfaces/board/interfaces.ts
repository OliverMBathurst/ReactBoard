import { IEntity } from "../common/interfaces"
import { IThread } from "../thread/interfaces"

export interface IBoard extends IEntity<string> {
    name: string
    description: string
    suffix: string
    threads: IThread[]
}

export interface IBoardAdminMapping extends IEntity<string> {
    boardId: string
    userId: string
}