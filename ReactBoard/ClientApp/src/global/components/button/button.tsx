import React from 'react'
import './styles.scss'

interface IButtonProps {
    text: string
    onClick: () => void
}

const Button = (props: IButtonProps) => {
    const {
        text,
        onClick
    } = props

    return (
        <button className="button" type="submit" onClick={() => onClick()}>
            {text}
        </button>
    )
}

export default Button