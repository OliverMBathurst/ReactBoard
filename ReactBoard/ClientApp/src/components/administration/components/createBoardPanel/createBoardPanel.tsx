import React, { useState } from 'react'
import { SubmitButton } from '../../../../global/components'
import { INewBoard } from '../../../../global/interfaces/board'
import { ICategory } from '../../../../global/interfaces/category'
import CategorySelect from '../categorySelect/categorySelect'
import Input from '../textInput/textInput'
import './styles.scss'

interface ICreateBoardPanel {
    onBoardCreate: (board: INewBoard) => void
    categories: ICategory[]
}

const CreateBoardPanel = (props: ICreateBoardPanel) => {
    const { categories, onBoardCreate } = props

    const [board, setBoard] = useState<INewBoard>({
        name: '',
        description: '',
        urlName: '',
        category: categories[0],
        isWorkSafe: false,
        maxThreads: 500
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
            <form>
                <Input title='Name' onChange={text => updateBoard(b => b.name = text)} />
                <Input title='Description' onChange={text => updateBoard(b => b.description = text)} />
                <Input title='Board URL Name (e.g g for /g/)' onChange={text => updateBoard(b => b.urlName = text)} />
                <CategorySelect
                    categories={categories}
                    onCategorySelected={category => updateBoard(b => b.category = category)}
                />
                <SubmitButton
                    value="Create New Board"
                    onClick={() => onBoardCreate(board)}
                />
            </form>
        </div>)
}

export default CreateBoardPanel