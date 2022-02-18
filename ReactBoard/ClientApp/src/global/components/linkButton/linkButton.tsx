import React from 'react'
import { Link } from 'react-router-dom'

interface ILinkButtonProps {
    to: string
    text: string
    visible?: boolean
}

const LinkButton = (props: ILinkButtonProps) => {
    const {
        to,
        text,
        visible = true
    } = props

    if (!visible) {
        return null
    }

    return (
        <Link to={to}>
            {text}
        </Link>)
}

export default LinkButton