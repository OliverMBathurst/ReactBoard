import React, { useEffect, useState } from 'react'
import { Redirect } from 'react-router-dom'
import { SiteIcon } from '../../assets'
import { Panel } from '../../global/components'
import { HomeRoute } from '../../global/constants/routes'
import { IBoard, INewBoard } from '../../global/interfaces/board'
import { ICategory, INewCategory } from '../../global/interfaces/category'
import { BoardService, CategoryService } from '../../services'
import { BoardValidator, CategoryValidator } from '../../validators'
import { CreateBoardPanel, CreateCategoryPanel } from './components'
import './styles.scss'

const boardService = new BoardService(), categoryService = new CategoryService()
const boardValidator = new BoardValidator(), categoryValidator = new CategoryValidator()

const Administration = () => {
    const [redirectToHome, setRedirectToHome] = useState<boolean>(false)
    const [categories, setCategories] = useState<ICategory[]>([])
    const [boards, setBoards] = useState<IBoard[]>([])

    useEffect(() => {
        let mounted = true

        categoryService.getAll().then(c => {
            if (mounted) {
                setCategories(c)
            }
        })

        boardService.getAll().then(b => {
            if (mounted) {
                setBoards(b)
            }
        })

        return () => {
            mounted = false
        }
    }, [])

    const onBoardCreate = async (board: INewBoard) => {
        const validationResult = boardValidator.execute(board)

        if (validationResult.length > 0) {

        } else {
            boardService.createBoard(board).then(() =>
                boardService.getAll()
                    .then(b => setBoards(b))
                    .catch(err => console.error(err))
            ).catch(err => console.error(err))
        }
    }

    const onCategoryCreate = (category: INewCategory)=> {
        const categoryValidationResult = categoryValidator.execute(category)

        if (categoryValidationResult.length > 0) {

        } else {
            categoryService.createCategory(category).then(() =>
                categoryService.getAll()
                    .then(c => setCategories(c))
                    .catch(err => console.error(err))
            ).catch(err => console.error(err))
        }
    }

    if (redirectToHome) {
        return <Redirect to={HomeRoute} />
    }

    return (
        <div className="admin-page">
            <SiteIcon onClick={() => setRedirectToHome(true)} />
            <Panel title='Create Categories'>
                <CreateCategoryPanel
                    onCategoryCreate={onCategoryCreate} />
            </Panel>
            <Panel title='Create Boards'>
                <CreateBoardPanel
                    categories={categories}
                    onBoardCreate={onBoardCreate}
                />
            </Panel>
            <Panel title='Boards Overview'>

            </Panel>
        </div>)
}

export default Administration