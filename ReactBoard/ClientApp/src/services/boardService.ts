import axios from "axios";
import { HttpStatusCode } from "../global/enums";
import { formatString } from "../global/helpers";
import { IBoard, IBoardCatalog, IBoardService, INewBoard } from "../global/interfaces/board";

class BoardService implements IBoardService {
    private endpoint: string = 'board'
    private allBoardsRoute: string = `${this.endpoint}/all`
    private boardByUrlNameRoute: string = `${this.endpoint}/{0}`
    private getCatalogRoute: string = `${this.endpoint}/{0}/catalog`

    getAll = (): Promise<IBoard[]> => {
        return new Promise<IBoard[]>((resolve, reject) => {
            axios.get<IBoard[]>(this.allBoardsRoute).then(res => {
                if (res.status === HttpStatusCode.Status200OK) {
                    resolve(res.data)
                }

                reject()
            })
        })
    }

    getBoardByUrlName = (urlName: string): Promise<IBoard> => {
        return new Promise<IBoard>((resolve, reject) => {
            axios.get<IBoard>(formatString(this.boardByUrlNameRoute, urlName)).then(res => {
                if (res.status === HttpStatusCode.Status200OK) {
                    resolve(res.data)
                }

                reject()
            })
        })
    }

    getCatalog = (urlName: string): Promise<IBoardCatalog> => {
        return new Promise<IBoardCatalog>((resolve, reject) => {
            axios.get<IBoardCatalog>(formatString(this.getCatalogRoute, urlName)).then(res => {
                if (res.status === HttpStatusCode.Status200OK) {
                    resolve(res.data)
                }

                reject()
            })
        })
    }

    createBoard = (board: INewBoard): Promise<void> => {
        return new Promise<void>((resolve, reject) => {
            axios.post<INewBoard>(this.endpoint, { data: board }).then(res => {
                if (res.status === HttpStatusCode.Status200OK) {
                    resolve()
                }

                reject()
            })

        })
    }
}

export default BoardService