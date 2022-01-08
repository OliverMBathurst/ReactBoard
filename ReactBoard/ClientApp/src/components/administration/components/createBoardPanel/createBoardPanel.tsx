import React, { useState } from 'react'
import { IBoard } from '../../../../global/interfaces/board/interfaces'
import { ICategory } from '../../../../global/interfaces/category/interfaces'
import CategorySelect from '../categorySelect/categorySelect'
import Input from '../input/input'
import './styles.scss'

interface INewBoard {
    name: string
    description: string
    category?: ICategory
    boardUrlName: string
}

interface ICreateBoardPanel {
    onBoardCreate: (board: IBoard) => void
    categories: ICategory[]
}

const CreateBoardPanel = (props: ICreateBoardPanel) => {
    const { categories, onBoardCreate } = props

    const [board, setBoard] = useState<INewBoard>({
        name: '',
        description: '',
        boardUrlName: ''
    })

    const updateBoard = (func: (b: INewBoard) => void) => {
        setBoard(b => {
            const updated = { ...b }
            func(updated)
            return updated
        })
    }

    return (
        <div className="create-board-panel">
            <Input title='Name' onChange={text => updateBoard(b => b.name = text)} />
            <Input title='Description' onChange={text => updateBoard(b => b.description = text)} />
            <Input title='Board URL Name (e.g g for /g/)' onChange={text => updateBoard(b => b.boardUrlName = text)} />
            <CategorySelect
                categories={categories}
                onCategorySelected={category => updateBoard(b => b.category = category)}
            />
            <input />
        </div>)
}

export default CreateBoardPanel