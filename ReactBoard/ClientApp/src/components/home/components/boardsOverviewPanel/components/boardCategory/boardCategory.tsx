import React from 'react'
import { IBoard } from '../../../../../../global/interfaces/board/interfaces'

interface IBoardCategoryProps {
    key: string
    category: string
    boards: IBoard[]
}

const BoardCategory = (props: IBoardCategoryProps) => {
    const { key, category, boards } = props
    //todo
    return (
        <div key={key}>

        </div>)
}

export default BoardCategory