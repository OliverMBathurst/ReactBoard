import { IEntity } from "../common/interfaces";

export interface IPost extends IEntity<string> {
    threadId: string
    boardId: string
    time: Date
    text: string
    image?: IImage
    replies: IPost[]
}