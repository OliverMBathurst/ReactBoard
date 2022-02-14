import axios, { AxiosResponse } from "axios";
import { HttpStatusCode } from "../global/enums";
import { formatString } from "../global/helpers/stringFormatter";
import { IPaginationResult } from "../global/interfaces/pagination";
import { IPost } from "../global/interfaces/post";
import { INewThread, IThread, IThreadService, IThreadUpdateRequest } from "../global/interfaces/thread";

class ThreadService implements IThreadService {
    private endpoint: string = 'thread'
    private getPaginatedResult: string = `${this.endpoint}/pagination?boardId={0}&pageNumber={1}`
    private deleteEndpoint: string = `${this.endpoint}?threadId={0}`
    private getEndpoint: string = `${this.endpoint}?threadId={0}`
    private updatesEndpoint: string = `${this.endpoint}/updates`

    getPaginatedThreadsForBoard = (boardId: number, pageNumber: number): Promise<IPaginationResult<IThread>> => {
        return new Promise<IPaginationResult<IThread>>((resolve, reject) => {
            axios.get<IPaginationResult<IThread>>(formatString(this.getPaginatedResult, boardId, pageNumber)).then(res => {
                if (res.status === HttpStatusCode.Status200OK) {
                    resolve(res.data)
                }

                reject()
            })
        })
    }

    postThread = (newThread: INewThread): Promise<void> => {
        return new Promise<void>((resolve, reject) => {
            axios.post<INewThread>(this.endpoint, newThread).then(res => {
                if (res.status === HttpStatusCode.Status200OK) {
                    resolve()
                }

                reject()
            })
        })
    }

    getThread = (threadId: number): Promise<IThread> => {
        return new Promise<IThread>((resolve, reject) => {
            axios.get<IThread>(formatString(this.getEndpoint, threadId)).then(res => {
                if (res.status === HttpStatusCode.Status200OK) {
                    resolve(res.data)
                }

                reject()
            })
        })
    }

    deleteThread = (threadId: number): Promise<void> => {
        return new Promise<void>((resolve, reject) => {
            axios.delete<void>(formatString(this.deleteEndpoint, threadId)).then(res => {
                if (res.status === HttpStatusCode.Status200OK) {
                    resolve()
                }

                reject()
            })
        })
    }

    getNewPostsForThread = (threadId: number, lastPostDate: Date): Promise<IPost[]> => {
        return new Promise<IPost[]>((resolve, reject) => {
            axios.post<IThreadUpdateRequest, AxiosResponse<IPost[]>>(this.updatesEndpoint, { threadId: threadId, latest: lastPostDate })
                .then(res => {
                    if (res.status === HttpStatusCode.Status200OK) {
                        resolve(res.data)
                    }

                    reject()
                })
        })
    }
}

export default ThreadService