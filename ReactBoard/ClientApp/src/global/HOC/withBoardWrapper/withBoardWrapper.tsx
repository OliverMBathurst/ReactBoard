import React, { useContext, useState } from 'react'
import { Redirect, useParams } from 'react-router'
import { SiteIcon } from '../../../assets'
import { BoardFooter } from '../../../components/board/boardPaginatedView/components'
import { BoardsNavBar } from '../../components'
import { BoardContext } from '../../context/boardsContext'
import { BoardOptionsHeader } from './components'
import './styles.scss'

interface IBoardWrapperParams {
    boardUrlName: string
}

interface IBoardWrapperProps {
    pageNumber: number
    totalPages: number
    onAllRequested: () => void
    onNewThreadRequested: () => void
}

const withBoardWrapper = (Component: any) => {
    return (props: IBoardWrapperProps) => {
        const {
            pageNumber,
            totalPages,
            onAllRequested,
            onNewThreadRequested
        } = props

        const { boardUrlName } = useParams<IBoardWrapperParams>()
        const { boardsMappedByUrlName } = useContext(BoardContext)
        const [redirect, setRedirect] = useState<string>('')

        const board = boardsMappedByUrlName.get(boardUrlName)

        if (redirect) {
            return <Redirect to={redirect} />
        }

        if (!board) {
            return null
        }

        return (
            <div className="board-wrapper">
                <div className="board-wrapper__boards-nav-bar">
                    <BoardsNavBar />
                </div>
                <div className="board-wrapper__board-intro">
                    <SiteIcon onClick={() => setRedirect("/")} />
                    <span className="board-wrapper__board-intro__board-descriptor">
                        {`/${board.urlName}/ - ${board.name}`}
                    </span>
                    <div className="board-wrapper__board-intro__start-thread">
                        <span className="board-wrapper__board-intro__start-thread__separator">
                            [
                        </span>
                        <span
                            className="board-wrapper__board-intro__start-thread__text highlightable-link"
                            onClick={onNewThreadRequested}
                        >
                            Start A New Thread
                        </span>
                        <span className="board-wrapper__board-intro__start-thread__separator">
                            ]
                        </span>
                    </div>
                </div>
                <BoardOptionsHeader boardUrlName={boardUrlName} />
                <Component />
                <BoardFooter
                    boardUrlName={boardUrlName}
                    currentPage={pageNumber}
                    totalPages={totalPages}
                    onAllRequested={onAllRequested}
                />
            </div>)
    }
}

export default withBoardWrapper