import { IPost } from "../post/interfaces";
import { IEntity } from "../common/interfaces";

export interface IThread extends IEntity<number | null> {
    locked: boolean
    boardId: number
    posts: IPost[]
}

export interface INewThread {
    boardId: string
    post: IPost
}

export interface IThreadService {
    getThread: (threadId: number, boardId: number) => Promise<IThread>
    deleteThread: (threadId: number, boardId: number) => Promise<void>
}