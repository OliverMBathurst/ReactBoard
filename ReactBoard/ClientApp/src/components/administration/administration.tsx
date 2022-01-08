import React, { useEffect, useState } from 'react'
import { Redirect } from 'react-router-dom'
import SiteIcon from '../../assets/site-icon'
import Panel from '../../global/components/panel/panel'
import { HomeRoute } from '../../global/constants/routes'
import { IBoard } from '../../global/interfaces/board/interfaces'
import { ICategory } from '../../global/interfaces/category/interfaces'
import BoardService from '../../services/board/boardService'
import CategoriesService from '../../services/category/categoryService'
import CreateBoardPanel from './components/createBoardPanel/createBoardPanel'
import './styles.scss'

const boardService = new BoardService(), categoriesService = new CategoriesService()

const Administration = () => {
    const [redirectToHome, setRedirectToHome] = useState<boolean>(false)
    const [categories, setCategories] = useState<ICategory[]>([])

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

    const onBoardCreate = async (board: IBoard) => boardService.createBoard(board)

    if (redirectToHome) {
        return <Redirect to={HomeRoute} />
    }

    return (
        <div className="admin-page">
            <SiteIcon onClick={() => setRedirectToHome(true)} />
            <Panel dismissable={false} title='Create Categories'>

            </Panel>
            <Panel dismissable={false} title='Create Boards'>
                <CreateBoardPanel
                    categories={categories}
                    onBoardCreate={onBoardCreate}
                />
            </Panel>
            <Panel dismissable={false} title='Boards Overview'>

            </Panel>
        </div>)
}

export default Administration