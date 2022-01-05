import axios from "axios";
import { HttpStatusCodes } from "../../global/enums/api/enums";
import { IThread, IThreadKey, IThreadService } from "../../global/interfaces/thread/interfaces";

class ThreadService implements IThreadService {
    private endpoint: string = 'thread'

    getThread = (threadKey: IThreadKey): Promise<IThread> => {
        return new Promise<IThread>((resolve, reject) => {
            axios.get<IThread>(this.endpoint, { data: threadKey }).then(res => {
                if (res.status === HttpStatusCodes.Status200OK) {
                    resolve(res.data)
                }

                reject()
            })
        })
    }

    deleteThread = (threadKey: IThreadKey): Promise<void> => {
        return new Promise<void>((resolve, reject) => {
            axios.delete<void>(this.endpoint, { data: threadKey }).then(res => {
                if (res.status === HttpStatusCodes.Status200OK) {
                    resolve()
                }

                reject()
            })
        })
    }
}

export default ThreadService