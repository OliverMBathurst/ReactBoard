import React, { useEffect, useState } from 'react'
import { withBoardWrapper } from '../../../../../global/HOC'
import { IBoard } from '../../../../../global/interfaces/board'
import { IPaginationResult } from '../../../../../global/interfaces/pagination'
import { IThread } from '../../../../../global/interfaces/thread'
import { ThreadService } from '../../../../../services'
import { Threads } from './components'

interface IBoardPaginatedViewProps {
    board: IBoard
    pageNumber: number
}

const _threadService = new ThreadService()

const BoardPaginatedView = (props: IBoardPaginatedViewProps) => {
    const {
        board,
        pageNumber
    } = props

    const [paginatedResult, setPaginatedResult] = useState<IPaginationResult<IThread>>()

    useEffect(() => {
        let mounted = true

        _threadService.getPaginatedThreadsForBoard(board.id, pageNumber).then(res => {
            if (mounted) {
                setPaginatedResult(res)
            }
        })

        return () => {
            mounted = false
        }
    }, [board.id, pageNumber])

    const onAllRequested = () => {
        //todo
    }

    if (!paginatedResult) {
        return null
    }

    return withBoardWrapper(
        () => <Threads boardUrlName={board.urlName} threads={paginatedResult.entities} />,
        {
            board: board,
            currentPage: paginatedResult.currentPage,
            totalPages: paginatedResult.totalPages,
            onAllRequested: onAllRequested
        })
}

export default BoardPaginatedView