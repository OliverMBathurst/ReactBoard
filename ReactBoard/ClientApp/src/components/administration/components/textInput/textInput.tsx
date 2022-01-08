import React from 'react'
import './styles.scss'

interface IInputProps {
    title: string
    text?: string
    inputRef?: React.Ref<HTMLInputElement>
    onChange?: (value: string) => void
}

const Input = (props: IInputProps) => {
    const {
        text,
        title = "",
        inputRef,
        onChange
    } = props

    return (
        <div className="input-box">
            <span className="input-text">{title}</span>
            <input
                className="input"
                ref={inputRef}
                defaultValue={text}
                onChange={e => {
                    if (onChange) {
                        onChange(e.target.value)
                    }
                }}
            />
        </div>)
}

export default Input