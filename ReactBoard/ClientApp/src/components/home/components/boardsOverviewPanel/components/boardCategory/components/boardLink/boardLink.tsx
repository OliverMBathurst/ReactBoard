import React, { useState } from 'react'
import { Redirect } from 'react-router-dom'
import { IBoard } from '../../../../../../../../global/interfaces/board'
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
        <span className="board-link" onClick={() => setRedirect(urlName)}>
            {name}
        </span>)
}

export default BoardLink