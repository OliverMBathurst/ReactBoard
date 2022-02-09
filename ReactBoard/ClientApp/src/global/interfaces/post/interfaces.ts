import { IEntity } from "../common";
import { IImage, INewImage } from "../image";

export interface IPost extends IEntity<number> {
    time: Date
    text: string
    image?: IImage
    replies: IPost[]
}

export interface INewPost {
    text: string
    threadId: number
    boardId: number
    image?: INewImage
}

export interface IPostService {
    getPost: (postId: number, threadId: number, boardId: number) => Promise<IPost>
    submitPost: (post: IPost) => Promise<void>
    getAllThreadPosts: (threadId: number, boardId: number) => Promise<IPost[]>
}