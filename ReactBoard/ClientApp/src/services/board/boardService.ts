import axios from "axios";
import { HttpStatusCodes } from "../../global/enums/api/enums";
import { formatString } from "../../global/helpers/stringFormatter";
import { IBoard, IBoardService } from "../../global/interfaces/board/interfaces";

class BoardService implements IBoardService {
    private allBoardsRoute: string = 'board/all'
    private boardByUrlNameRoute: string = 'board/{0}'

    getAllBoards = (): Promise<IBoard[]> => {
        return new Promise<IBoard[]>((resolve, reject) => {
            axios.get<IBoard[]>(this.allBoardsRoute).then(res => {
                if (res.status === HttpStatusCodes.Status200OK) {
                    resolve(res.data)
                }

                reject()
            })
        })
    }

    getBoardByUrlName = (boardUrlName: string): Promise<IBoard> => {
        return new Promise<IBoard>((resolve, reject) => {
            axios.get<IBoard>(formatString(this.boardByUrlNameRoute, boardUrlName)).then(res => {
                if (res.status === HttpStatusCodes.Status200OK) {
                    resolve(res.data)
                }

                reject()
            })
        })
    }
}

export default BoardService