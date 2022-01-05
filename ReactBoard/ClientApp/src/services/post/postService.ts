import axios from "axios"
import { HttpStatusCodes } from "../../global/enums/api/enums"
import { IPost, IPostKey, IPostService } from "../../global/interfaces/post/interfaces"
import { IThreadKey } from "../../global/interfaces/thread/interfaces"

class PostService implements IPostService {
    private endpoint: string = 'post'
    private threadPostsEndpoint: string = `${this.endpoint}/thread`

    getPost = (postKey: IPostKey): Promise<IPost> => {
        return new Promise<IPost>((resolve, reject) => {
            axios.get<IPost>(this.endpoint, { data: postKey }).then(res => {
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

    getAllThreadPosts = (threadKey: IThreadKey): Promise<IPost[]> => {
        return new Promise<IPost[]>((resolve, reject) => {
            axios.get<IPost[]>(this.threadPostsEndpoint, { data: threadKey }).then(res => {
                if (res.status === HttpStatusCodes.Status200OK) {
                    resolve(res.data)
                }

                reject()
            })
        })
    }
}

export default PostService