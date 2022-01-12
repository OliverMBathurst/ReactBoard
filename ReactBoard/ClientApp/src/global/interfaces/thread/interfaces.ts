import { IEntity } from "../common/interfaces";
import { INewPost, IPost } from "../post/interfaces";

export interface IThread extends IEntity<number | null> {
    locked: boolean
    boardId: number
    posts: IPost[]
}

export interface INewThread {
    boardId: string
    post: INewPost
}

export interface IThreadService {
    getThread: (threadId: number, boardId: number) => Promise<IThread>
    deleteThread: (threadId: number, boardId: number) => Promise<void>
}