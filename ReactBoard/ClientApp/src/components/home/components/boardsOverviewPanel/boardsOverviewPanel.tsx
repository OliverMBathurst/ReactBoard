import React from 'react'
import { IBoard } from '../../../../global/interfaces/board/interfaces'
import { IKeyValuePair } from '../../../../global/interfaces/types/interfaces'
import BoardCategory from './components/boardCategory/boardCategory'
import './styles.scss'

interface IBoardsOverviewPanelProps {
    boardsGroupedByCategory: IKeyValuePair<string, IBoard[]>[]
}

const BoardsOverviewPanel = (props: IBoardsOverviewPanelProps) => {
    const {
        boardsGroupedByCategory
    } = props

    return (
        <div className="boards-overview-panel">
            <div className="boards-overview-panel-top-box">
                <span className="boards-overview-panel-top-box-text">
                    Boards
                </span>
            </div>
            <div className="boards-overview-panel-top-box-description-box">
                {boardsGroupedByCategory.map(b => {
                    return (
                        <BoardCategory
                            key={`${b.key}-${b.value}`}
                            category={b.key}
                            boards={b.value}
                        />)
                })}
            </div>
        </div>)
}

export default BoardsOverviewPanel