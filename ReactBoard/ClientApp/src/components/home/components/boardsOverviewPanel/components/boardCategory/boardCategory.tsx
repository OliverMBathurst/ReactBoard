import React from 'react'
import { IBoard } from '../../../../../../global/interfaces/board/interfaces'
import BoardLink from './components/boardLink/boardLink'
import './styles.scss'

interface IBoardCategoryProps {
    category: string
    boards: IBoard[]
}

const BoardCategory = (props: IBoardCategoryProps) => {
    const {
        category,
        boards
    } = props

    return (
        <div className="board-category">
            <span className="board-category-text">{category}</span>
            {boards.map(x => <BoardLink key={`${category}-${x.id}`} board={x} />)}
        </div>)
}

export default BoardCategory