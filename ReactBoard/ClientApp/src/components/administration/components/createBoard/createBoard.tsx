import React, { useState } from 'react'
import { IBoard } from '../../../../global/interfaces/board/interfaces'
import { ICategory } from '../../../../global/interfaces/category/interfaces'
import CategorySelect from '../categorySelect/categorySelect'
import Input from '../input/input'

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

    const onCategorySelected = (category: ICategory) => setBoard((b: INewBoard) => b.category = category)

    return (
        <div className="create-board-panel">
            <Input title='Name' />
            <Input title='Description' />
            <Input title='Board URL Name (e.g g for /g/)' />
            <CategorySelect
                categories={categories}
                onCategorySelected={onCategorySelected}
            />
        </div>)
}

export default CreateBoardPanel