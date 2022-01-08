﻿import axios from "axios"
import { HttpStatusCodes } from "../../global/enums/api/enums"
import { formatString } from "../../global/helpers/stringFormatter"
import { IPost, IPostService } from "../../global/interfaces/post/interfaces"

class PostService implements IPostService {
    private endpoint: string = 'post'
    private threadPostsEndpoint: string = `${this.endpoint}/thread?threadId={0}&boardId={1}`
    private getPostEndpoint: string = `${this.endpoint}?postId={0}&threadId={1}&boardId={2}`

    getPost = (postId: number, threadId: number, boardId: number): Promise<IPost> => {
        return new Promise<IPost>((resolve, reject) => {
            axios.get<IPost>(formatString(this.getPostEndpoint, postId, threadId, boardId)).then(res => {
                if (res.status === HttpStatusCodes.Status200OK) {
                    resolve(res.data)
                }

                reject()
            })
        })
    }

    submitPost = (post: IPost): Promise<void> => {
        return new Promise<void>((resolve, reject) => {
            axios.post<IPost>(this.endpoint, post).then(res => {
                if (res.status === HttpStatusCodes.Status200OK) {
                    resolve()
                }

                reject()
            })
        })
    }

    getAllThreadPosts = (threadId: number, boardId: number): Promise<IPost[]> => {
        return new Promise<IPost[]>((resolve, reject) => {
            axios.get<IPost[]>(formatString(this.threadPostsEndpoint, threadId, boardId)).then(res => {
                if (res.status === HttpStatusCodes.Status200OK) {
                    resolve(res.data)
                }

                reject()
            })
        })
    }
}

export default PostService