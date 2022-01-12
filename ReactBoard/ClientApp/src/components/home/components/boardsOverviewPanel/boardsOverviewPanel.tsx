import React from 'react'
import { ICategory } from '../../../../global/interfaces/category/interfaces'
import BoardCategory from './components/boardCategory/boardCategory'
import './styles.scss'

interface IBoardsOverviewPanelProps {
    categories: ICategory[]
}

const BoardsOverviewPanel = (props: IBoardsOverviewPanelProps) => {
    const {
        categories
    } = props

    return (
        <div className="boards-overview-panel">
            <div className="boards-overview-panel-top-box">
                <span className="boards-overview-panel-top-box-text">
                    Boards
                </span>
            </div>
            <div className="boards-overview-panel-description-box">
                {categories.map(b => {
                    return (
                        <BoardCategory
                            key={b.id}
                            category={b.name}
                            boards={b.boards}
                        />)
                })}
            </div>
        </div>)
}

export default BoardsOverviewPanel