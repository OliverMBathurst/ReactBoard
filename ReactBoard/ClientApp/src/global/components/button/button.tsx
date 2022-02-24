import React from 'react'
import './styles.scss'

interface IButtonProps {
    text: string
    onClick: () => void
    className?: string
}

const Button = (props: IButtonProps) => {
    const {
        text,
        onClick,
        className
    } = props

    return (
        <button
            className={`${className || ""} button`}
            type="submit"
            onClick={() => onClick()}
        >
            {text}
        </button>
    )
}

export default Button