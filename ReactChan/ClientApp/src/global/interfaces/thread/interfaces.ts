import { IEntity } from "../common/interfaces";
import { IPost } from "../post/interfaces";

export interface IThread extends IEntity<string> {
    boardId: string
    posts: IPost[]
}

export interface INewThread {
    boardId: string
    post: IPost
}