import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router'
import { withBoardWrapper } from '../../../global/HOC'
import { IBoard } from '../../../global/interfaces/board'
import { IPaginationResult } from '../../../global/interfaces/pagination'
import { IThread } from '../../../global/interfaces/thread'
import { BoardService, ThreadService } from '../../../services'
import { Threads } from './components'

const _threadService = new ThreadService(), _boardService = new BoardService()

interface IBoardPaginatedViewParams {
    boardUrlName: string
    pageNumber: string | undefined
}

const BoardPaginatedView = () => {
    const { boardUrlName, pageNumber: pgNum } = useParams<IBoardPaginatedViewParams>()

    const pageNumber = parseInt(pgNum || "1")
    const [board, setBoard] = useState<IBoard>()
    const [paginatedResult, setPaginatedResult] = useState<IPaginationResult<IThread>>()

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

    useEffect(() => {
        let mounted = true

        if (board) {
            _threadService.getPaginatedThreadsForBoard(board.id, pageNumber).then(res => {
                if (mounted) {
                    setPaginatedResult(res)
                }
            })
        }

        return () => {
            mounted = false
        }
    }, [board, pageNumber])

    if (!paginatedResult || !board) {
        return null
    }

    return <Threads boardUrlName={board.urlName} threads={paginatedResult.entities} />
}

export default withBoardWrapper(BoardPaginatedView)