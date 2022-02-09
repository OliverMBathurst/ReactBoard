import React from 'react'
import { ICategory } from '../../../../global/interfaces/category'
import BoardCategory from './components/boardCategory/boardCategory'
import './styles.scss'

interface IBoardsOverviewPanelProps {
    categories: ICategory[]
}

const BoardsOverviewPanel = (props: IBoardsOverviewPanelProps) => {
    const { categories } = props

    return (
        <div className="boards-overview-panel">
            <div className="boards-overview-panel__top-box">
                <span className="boards-overview-panel__top-box__text">
                    Boards
                </span>
            </div>
            <div className="boards-overview-panel__description-box">
                {categories.map(category => {
                    return (
                        <BoardCategory
                            key={category.id}
                            category={category.name}
                            boards={category.boards}
                        />)
                })}
            </div>
        </div>)
}

export default BoardsOverviewPanel