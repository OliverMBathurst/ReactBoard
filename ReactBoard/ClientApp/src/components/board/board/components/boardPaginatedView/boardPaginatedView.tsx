import React, { useEffect, useState } from 'react'
import { IBoard } from '../../../../../global/interfaces/board'
import { IPaginationResult } from '../../../../../global/interfaces/pagination'
import { IThread } from '../../../../../global/interfaces/thread'
import { ThreadService } from '../../../../../services'
import { ThreadsView, ThreadsViewFooter } from './components'

interface IBoardPaginatedViewProps {
    board: IBoard
    pageNumber: number
}

const threadService = new ThreadService()

const BoardPaginatedView = (props: IBoardPaginatedViewProps) => {
    const {
        board,
        pageNumber
    } = props

    const [paginatedResult, setPaginatedResult] = useState<IPaginationResult<IThread>>()

    useEffect(() => {
        let mounted = true

        threadService.getPaginatedThreadsForBoard(board.id, pageNumber).then(res => {
            if (mounted) {
                setPaginatedResult(res)
            }
        })

        return () => {
            mounted = false
        }
    }, [board.id, pageNumber])

    if (!paginatedResult) {
        return null
    }

    return (
        <>
            <ThreadsView threads={paginatedResult.entities} />
            <ThreadsViewFooter
                boardId={board.id}
                currentPage={paginatedResult.currentPage}
                totalPages={paginatedResult.totalPages}
            />
        </>)
}

export default BoardPaginatedView