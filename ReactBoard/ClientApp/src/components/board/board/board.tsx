import React, { useEffect, useState } from 'react'
import { IBoard } from '../../../global/interfaces/board'
import { BoardService } from '../../../services'
import { BoardPaginatedView } from './components'

interface IBoardProps {
    boardUrlName: string
    pageNumber?: number
}

const _boardService = new BoardService()

const Board = (props: IBoardProps) => {
    const {
        boardUrlName,
        pageNumber = 1
    } = props

    const [board, setBoard] = useState<IBoard | undefined>()

    useEffect(() => {
        let mounted = true

        _boardService.getBoardByUrlName(boardUrlName).then(res => {
            if (mounted) {
                setBoard(res)
            }
        })

        return () => {
            mounted = false
        }
    }, [boardUrlName])

    return board
        ? <BoardPaginatedView board={board} pageNumber={pageNumber} />
        : null
}

export default Board