import React, { useContext, useState } from 'react'
import { Redirect } from 'react-router'
import { BoardContext } from '../../context/boardsContext'
import './styles.scss'

const BoardsNavBar = () => {
    const { boards } = useContext(BoardContext)

    const [redirect, setRedirect] = useState<string>('')

    if (redirect) {
        return <Redirect to={redirect} />
    }

    return (
        <div className="boards-nav-bar">
            <span className="boards-nav-bar__brace">
                [
            </span>
            {boards.map((board, idx) => {
                return (
                    <div className="boards-nav-bar__container" key={board.id}>
                        <span
                            key={`boards-nav-${board.urlName}`}
                            className="boards-nav-bar__container__link highlightable-link"
                            onClick={() => setRedirect(`/${board.urlName}`)}>
                            {`${board.urlName}`}
                        </span>
                        <span
                            key={`boards-nav-${board.urlName}__separator`}
                            className="boards-nav-bar__container__separator">
                            {idx !== boards.length - 1 ? "/" : ""}
                        </span>
                    </div>)
            })}
            <span className="boards-nav-bar__brace">
                ]
            </span>
        </div>)
}

export default BoardsNavBar