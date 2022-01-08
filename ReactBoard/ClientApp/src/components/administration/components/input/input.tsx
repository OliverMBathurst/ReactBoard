import React from 'react'
import './styles.scss'

interface IInputProps {
    title: string
    text?: string
}

const Input = (props: IInputProps) => {
    const {
        text,
        title = ""
    } = props

    return (
        <div className="input-box">
            <span className="input-text">{title}</span>
            <input className="input">{text}</input>
        </div>)

}

export default Input