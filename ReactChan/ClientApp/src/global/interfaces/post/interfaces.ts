import { IEntity } from "../common/interfaces";
import { IImage } from "../image/interfaces";

export interface IPost extends IEntity<string> {
    threadId: string
    boardId: string
    time: Date
    text: string
    image?: IImage
    replies: IPost[]
}

export interface INewPost {
    boardId: string
    post: IPost
}