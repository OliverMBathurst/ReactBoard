import React, { useEffect, useState } from 'react'
import { Redirect } from 'react-router-dom'
import SiteIcon from '../../assets/siteIcon/siteIcon'
import Panel from '../../global/components/panel/panel'
import { HomeRoute } from '../../global/constants/routes'
import { IBoard, INewBoard } from '../../global/interfaces/board/interfaces'
import { ICategory, INewCategory } from '../../global/interfaces/category/interfaces'
import BoardService from '../../services/boardService'
import CategoryService from '../../services/categoryService'
import CategoryValidator from '../../validators/categoryValidator'
import CreateBoardPanel from './components/createBoardPanel/createBoardPanel'
import CreateCategoryPanel from './components/createCategoryPanel/createCategoryPanel'
import './styles.scss'

const boardService = new BoardService(), categoriesService = new CategoryService()

const Administration = () => {
    const [redirectToHome, setRedirectToHome] = useState<boolean>(false)
    const [categories, setCategories] = useState<ICategory[]>([])
    const [boards, setBoards] = useState<IBoard[]>([])

    useEffect(() => {
        let mounted = true

        categoriesService.getAll().then(c => {
            if (mounted) {
                setCategories(c)
            }
        })

        return () => {
            mounted = false
        }
    }, [])

    useEffect(() => {
        let mounted = true

        boardService.getAll().then(b => {
            if (mounted) {
                setBoards(b)
            }
        })

        return () => {
            mounted = false
        }
    }, [])

    const onBoardCreate = async (board: INewBoard) => boardService.createBoard(board)

    const onCategoryCreate = async (category: INewCategory) => {
        const categoryValidationResult = new CategoryValidator(category).execute()

        if (categoryValidationResult.length > 0) {

        } else {
            await categoriesService.createCategory(category)
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