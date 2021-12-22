import { IEntity } from "../common/interfaces";

export interface IThread extends IEntity<string> {
    boardId: string
    posts: IPost[]
}