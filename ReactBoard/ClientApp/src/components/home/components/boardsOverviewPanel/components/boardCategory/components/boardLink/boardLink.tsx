import React, { useState } from 'react'
import { Redirect, RouteComponentProps, withRouter } from 'react-router-dom'
import { IBoard } from '../../../../../../../../global/interfaces/board/interfaces'
import './styles.scss'

interface IBoardLinkProps {
    board: IBoard
    location: Location
}

const BoardLink: React.FC<IBoardLinkProps & RouteComponentProps> = (props: IBoardLinkProps) => {
    const {
        board: {
            name,
            urlName
        },
        location: {
            protocol,
            host
        }
    } = props

    const [redirect, setRedirect] = useState<string>('')

    if (redirect) {
        return <Redirect to={redirect} />
    }

    return (
        <span className="board-link" onClick={() => setRedirect(`${protocol}${host}/${urlName}`)}>
            {name}
        </span>)
}

export default withRouter(BoardLink)