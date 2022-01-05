import { IPost } from "../post/interfaces";

export interface IThreadKey {
    threadId: number | null
    boardId: number
}

export interface IThread extends IThreadKey {
    posts: IPost[]
}

export interface INewThread {
    boardId: string
    post: IPost
}

export interface IThreadService {
    getThread: (threadKey: IThreadKey) => Promise<IThread>
    deleteThread: (threadKey: IThreadKey) => Promise<void>
}