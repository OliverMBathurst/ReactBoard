import axios from "axios";
import { HttpStatusCodes } from "../../global/enums/api/enums";
import { IThread, IThreadService } from "../../global/interfaces/thread/interfaces";
import { formatString } from "../../global/helpers/stringFormatter";

class ThreadService implements IThreadService {
    private endpoint: string = 'thread'
    private deleteEndpoint: string = `${this.endpoint}?threadId={0}&boardId={1}`
    private getEndpoint: string = `${this.endpoint}?threadId={0}&boardId={1}`

    getThread = (threadId: number, boardId: number): Promise<IThread> => {
        return new Promise<IThread>((resolve, reject) => {
            axios.get<IThread>(formatString(this.getEndpoint, threadId, boardId)).then(res => {
                if (res.status === HttpStatusCodes.Status200OK) {
                    resolve(res.data)
                }

                reject()
            })
        })
    }

    deleteThread = (threadId: number, boardId: number): Promise<void> => {
        return new Promise<void>((resolve, reject) => {
            axios.delete<void>(formatString(this.deleteEndpoint, threadId, boardId)).then(res => {
                if (res.status === HttpStatusCodes.Status200OK) {
                    resolve()
                }

                reject()
            })
        })
    }
}

export default ThreadService