import React from 'react'
import { BoardFooter } from '../../../components/board/board/components/boardPaginatedView/components'
import { IBoard } from '../../interfaces/board'
import { BoardHeader } from './components'
import './styles.scss'

interface IBoardWrapperProps {
    board: IBoard
    currentPage: number
    totalPages: number
    onAllRequested: () => void
}

const withBoardWrapper = <P extends object>(component: React.ComponentType<P>, props: IBoardWrapperProps) => {
    const {
        board,
        currentPage,
        totalPages,
        onAllRequested
    } = props

    return (
        <div className="board-wrapper">
            <BoardHeader boardUrlName={board.urlName} />
            {component}
            <BoardFooter
                boardUrlName={board.urlName}
                currentPage={currentPage}
                totalPages={totalPages}
                onAllRequested={onAllRequested}
            />
        </div>)
}

export default withBoardWrapper