import axios from "axios";
import { HttpStatusCode } from "../../global/enums/api/enums";
import { formatString } from "../../global/helpers/stringFormatter";
import { IBoard, IBoardService, INewBoard } from "../../global/interfaces/board/interfaces";

class BoardService implements IBoardService {
    private endpoint: string = 'board'
    private allBoardsRoute: string = `${this.endpoint}/all`
    private boardByUrlNameRoute: string = `${this.endpoint}/{0}`

    getAllBoards = (): Promise<IBoard[]> => {
        return new Promise<IBoard[]>((resolve, reject) => {
            axios.get<IBoard[]>(this.allBoardsRoute).then(res => {
                if (res.status === HttpStatusCode.Status200OK) {
                    resolve(res.data)
                }

                reject()
            })
        })
    }

    getBoardByUrlName = (boardUrlName: string): Promise<IBoard> => {
        return new Promise<IBoard>((resolve, reject) => {
            axios.get<IBoard>(formatString(this.boardByUrlNameRoute, boardUrlName)).then(res => {
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