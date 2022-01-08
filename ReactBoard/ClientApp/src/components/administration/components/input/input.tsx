import React from 'react'
import './styles.scss'

interface IInputProps {
    title: string
    text?: string
    onChange: (value: string) => void
}

const Input = (props: IInputProps) => {
    const {
        text,
        title = "",
        onChange
    } = props

    return (
        <div className="input-box">
            <span className="input-text">{title}</span>
            <input className="input" onChange={e => onChange(e.target.value)} defaultValue={text} />
        </div>)
}

export default Input