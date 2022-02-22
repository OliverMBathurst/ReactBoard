import React, { useCallback, useEffect, useState } from 'react'
import { Redirect } from 'react-router-dom'
import { SiteIcon } from '../../assets'
import { Panel } from '../../global/components'
import { HomeRoute } from '../../global/constants/routes'
import { IBoard, INewBoard } from '../../global/interfaces/board'
import { ICategory, INewCategory } from '../../global/interfaces/category'
import { BoardService, CategoryService } from '../../services'
import { BoardValidator, CategoryValidator } from '../../validators'
import { BoardRow, CreateBoardPanel, CreateCategoryPanel } from './components'
import './styles.scss'

const _boardService = new BoardService(), categoryService = new CategoryService()
const _boardValidator = new BoardValidator(), categoryValidator = new CategoryValidator()

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

        _boardService.getAll().then(b => {
            if (mounted) {
                setBoards(b)
            }
        })

        return () => {
            mounted = false
        }
    }, [])

    const redirectToHomeCallback = useCallback(() => setRedirectToHome(true), [])

    const onBoardCreate = (board: INewBoard): void => {
        const validationResult = _boardValidator.execute(board)

        if (validationResult.length > 0) {

        } else {
            _boardService.createBoard(board).then(() =>
                _boardService.getAll()
                    .then(b => setBoards(b))
                    .catch(err => console.error(err))
            ).catch(err => console.error(err))
        }
    }

    const onCategoryCreate = (category: INewCategory): void => {
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

    const onBoardDeleteRequested = (boardId: number): void => {
        //todo
    }

    if (redirectToHome) {
        return <Redirect to={HomeRoute} />
    }

    return (
        <div className="admin-page">
            <SiteIcon onClick={redirectToHomeCallback} />
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
                {categories.map(category => {
                    return (
                        <Panel title={category.name}>
                            {category.boards.map(board => {
                                return (
                                    <BoardRow
                                        key={`${category.name}-${board.name}`}
                                        categories={categories}
                                        board={board}
                                        onBoardDeleteRequested={() => onBoardDeleteRequested(board.id)} />)
                            })}
                        </Panel>)
                })}
            </Panel>
        </div>)
}

export default Administration