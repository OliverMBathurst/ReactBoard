import React, { useState } from 'react'
import { Redirect } from 'react-router-dom'
import { IBoard } from '../../interfaces/board'
import './styles.scss'

interface IBoardLinkProps {
    board: IBoard
}

const BoardLink = (props: IBoardLinkProps) => {
    const {
        board: {
            name,
            urlName
        }
    } = props

    const [redirect, setRedirect] = useState<string>('')

    if (redirect) {
        return <Redirect to={redirect} />
    }

    return (
        <li className="board-link" onClick={() => setRedirect(urlName)}>
            {name}
        </li>)
}

export default BoardLink