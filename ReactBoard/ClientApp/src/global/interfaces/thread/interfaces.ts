import { IEntity } from "../common";
import { INewPost, IPost } from "../post";

export interface IThread extends IEntity<number | null> {
    locked: boolean
    boardId: number
    posts: IPost[]
}

export interface INewThread {
    boardId: string
    post: INewPost
}

export interface IThreadUpdateRequest {
    threadId: number
    latest: Date
}

export interface IThreadService {
    postThread: (thread: INewThread) => Promise<void>
    getThread: (threadId: number, boardId: number) => Promise<IThread>
    deleteThread: (threadId: number, boardId: number) => Promise<void>
    getNewPostsForThread: (threadId: number, lastPostDate: Date) => Promise<IPost[]>
}