import React from 'react'
import { IBoard } from '../../../../global/interfaces/board'

interface IBoardRowProps {
    boards: IBoard[]
    onBoardDeleteRequested: (boardId: number) => void
}

const BoardRow = (props: IBoardRowProps) => {
    const { boards, onBoardDeleteRequested } = props


    return (
        <>
            {boards.map(b => {
                return (
                    <div className="board-row">
                        <span className="board-row-id">{`ID: ${b.id}`}</span>
                        <span className="board-row-name">{`Name: ${b.name}`}</span>
                        <span className="board-row-category">{`Category: ${b.category}`}</span>
                        <span className="board-row-description">{`Description: ${b.description}`}</span>
                    </div>)
            })}
        </>)
}

export default BoardRow