import axios from "axios";
import { HttpStatusCode } from "../global/enums";
import { ISiteStatistic } from "../global/interfaces/misc";

interface IStatisticsService {
    getSiteStatistics: () => Promise<ISiteStatistic[]>
}

class StatisticsService implements IStatisticsService {
    private endpoint: string = 'statistics'

    getSiteStatistics = (): Promise<ISiteStatistic[]> => {
        return new Promise<ISiteStatistic[]>((resolve, reject) => {
            axios.get<ISiteStatistic[]>(this.endpoint).then(res => {
                if (res.status === HttpStatusCode.Status200OK) {
                    resolve(res.data)
                }

                reject()
            })
        })
    }
}

export default StatisticsService