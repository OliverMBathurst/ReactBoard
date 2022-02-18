import React from 'react'
import { BoardLink } from '../../../../global/components'
import { IBoard } from '../../../../global/interfaces/board'
import './styles.scss'

interface IBoardCategoryProps {
    category: string
    boards: IBoard[]
}

const BoardCategory = (props: IBoardCategoryProps) => {
    const { category, boards } = props

    return (
        <div className="board-category">
            <span className="board-category__text">{category}</span>
            <ul className="board-category__boards-list">
                {boards.map(board => {
                    return (
                        <BoardLink
                            key={`${category}-${board.id}`}
                            board={board} />
                    )
                })}
            </ul>
        </div>)
}

export default BoardCategory