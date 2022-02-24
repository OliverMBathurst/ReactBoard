import React, { useMemo } from 'react'
import { Button } from '../../../../global/components'
import { IBoard } from '../../../../global/interfaces/board'
import { ICategory } from '../../../../global/interfaces/category'
import './styles.scss'

interface IBoardRowProps {
    board: IBoard
    categories: ICategory[]
    onBoardDeleteRequested: () => void
}

const BoardRow = (props: IBoardRowProps) => {
    const {
        board: {
            id,
            name,
            categoryId,
            description
        },
        categories,
        onBoardDeleteRequested
    } = props

    const categoryName = useMemo(() => {
        if (categories.length === 0)
            return ""

        const filtered = categories.filter(category => category.id === categoryId)
        return filtered.length > 0 ? filtered[0].name : ""
    }, [categories, categoryId])

    return (
        <div className="board-row">
            <ul className="board-row__list">
                <li className="board-row__list__entry">{`ID: ${id}`}</li>
                <li className="board-row__list__entry--bold">{`Name: ${name}`}</li>
                <li className="board-row__list__entry">{`Category: ${categoryName} (${categoryId})`}</li>
                <li className="board-row__list__entry">{`Description: ${description}`}</li>
            </ul>
            <Button
                className="board-row__delete-button"
                text="Delete"
                onClick={onBoardDeleteRequested} />
        </div>)
}

export default BoardRow