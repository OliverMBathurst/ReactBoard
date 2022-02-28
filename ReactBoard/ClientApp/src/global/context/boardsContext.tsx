import React, { useEffect, useState, createContext } from 'react'
import { BoardService } from '../../services'
import { IBoard } from '../interfaces/board'
import { toMap } from '../helpers/toMap';

const _boardService = new BoardService()

export const BoardContext = createContext<IBoardContext>({
    boards: [],
    boardsMappedByUrlName: new Map<string, IBoard>()
});

interface IBoardContext {
    boards: IBoard[]
    boardsMappedByUrlName: Map<string, IBoard>
}

interface IBoardContextProps {
    children: React.ReactNode
}

const BoardsContext = (props: IBoardContextProps) => {
    const { children } = props
    const [boards, setBoards] = useState<IBoard[]>([])
    const [boardsMappedByUrlName, setBoardsMappedByUrlName] = useState<Map<string, IBoard>>(new Map<string, IBoard>())

    useEffect(() => {
        let mounted = true

        _boardService.getAll().then(b => {
            if (mounted) {
                setBoards(b)
                setBoardsMappedByUrlName(toMap(b, board => board.urlName, board => board))
            }
        })

        return () => {
            mounted = false
        }
    }, [])

    return (
        <BoardContext.Provider value={{
            boards: boards,
            boardsMappedByUrlName: boardsMappedByUrlName
        }}>
            {children}
        </BoardContext.Provider>)
}

export default BoardsContext