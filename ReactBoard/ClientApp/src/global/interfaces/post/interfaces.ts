import { IImage } from "../image/interfaces";
import { IThreadKey } from "../thread/interfaces";

export interface IPostKey {
    postId: number | null
    threadId: string
    boardId: string
}

export interface IPost extends IPostKey {
    time: Date
    text: string
    image?: IImage
    replies: IPost[]
}

export interface INewPost {
    text: string
    threadId: number
    boardId: number
    image: IImage
}

export interface IPostService {
    getPost: (postKey: IPostKey) => Promise<IPost>
    submitPost: (post: IPost) => Promise<void>
    getAllThreadPosts: (threadKey: IThreadKey) => Promise<IPost[]>
}