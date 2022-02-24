import axios from "axios";
import { HttpStatusCode, ThreadFilter } from "../global/enums";
import { formatString } from "../global/helpers";
import { IFeaturedThread } from "../global/interfaces/thread/interfaces";

interface IHomeService {
    getFeaturedThreadsByFilter: (threadFilter: ThreadFilter) => Promise<IFeaturedThread[]>
}

class HomeService implements IHomeService {
    private endpoint: string = 'home'
    private getFeaturedThreadsByFilterEndpoint: string = `/${this.endpoint}/featured/{0}`

    getFeaturedThreadsByFilter = (threadFilter: ThreadFilter): Promise<IFeaturedThread[]> => {
        return new Promise<IFeaturedThread[]>((resolve, reject) => {
            axios.get<IFeaturedThread[]>(formatString(this.getFeaturedThreadsByFilterEndpoint, threadFilter)).then(res => {
                if (res.status === HttpStatusCode.Status200OK) {
                    resolve(res.data)
                }

                reject()
            })
        })
    }
}

export default HomeService