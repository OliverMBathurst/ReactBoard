import axios from "axios";
import { HttpStatusCode } from "../global/enums";
import { formatString } from "../global/helpers/stringFormatter";
import { IPaginationResult } from "../global/interfaces/pagination";
import { INewThread, IThread, IThreadService } from "../global/interfaces/thread";

class ThreadService implements IThreadService {
    private endpoint: string = 'thread'
    private getPaginatedResult: string = `${this.endpoint}/pagination?boardId={0}&pageNumber={1}`
    private deleteEndpoint: string = `${this.endpoint}?threadId={0}`
    private getEndpoint: string = `${this.endpoint}?threadId={0}`

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

    getThread = (threadId: number, boardId: number): Promise<IThread> => {
        return new Promise<IThread>((resolve, reject) => {
            axios.get<IThread>(formatString(this.getEndpoint, threadId, boardId)).then(res => {
                if (res.status === HttpStatusCode.Status200OK) {
                    resolve(res.data)
                }

                reject()
            })
        })
    }

    deleteThread = (threadId: number, boardId: number): Promise<void> => {
        return new Promise<void>((resolve, reject) => {
            axios.delete<void>(formatString(this.deleteEndpoint, threadId, boardId)).then(res => {
                if (res.status === HttpStatusCode.Status200OK) {
                    resolve()
                }

                reject()
            })
        })
    }
}

export default ThreadService