import axios from "axios"
import { HttpStatusCode, Language, MessageKey } from "../global/enums"

interface IMessageKeyService {
    getAllMessageKeys: (language: Language) => Promise<Map<MessageKey, string>>
}

class MessageKeyService implements IMessageKeyService {
    private endpoint: string = "messagekey"

    getAllMessageKeys = (language: Language): Promise<Map<MessageKey, string>> => {
        return new Promise<Map<MessageKey, string>>((resolve, reject) => {
            axios.get<Map<MessageKey, string>>(this.endpoint).then(res => {
                if (res.status === HttpStatusCode.Status200OK) {
                    resolve(res.data)
                }

                reject()
            })
        })
    }
}

export default MessageKeyService