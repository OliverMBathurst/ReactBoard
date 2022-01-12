import { IEntity } from "../common/interfaces";
import { IImage } from "../image/interfaces";

export interface IPost extends IEntity<number | null> {
    threadId: string
    boardId: string
    time: Date
    text: string
    image?: IImage
    replies: IPost[]
}

export interface INewPost {
    text: string
    threadId: number
    boardId: number
    image?: IImage
}

export interface IPostService {
    getPost: (postId: number, threadId: number, boardId: number ) => Promise<IPost>
    submitPost: (post: IPost) => Promise<void>
    getAllThreadPosts: (threadId: number, boardId: number) => Promise<IPost[]>
}