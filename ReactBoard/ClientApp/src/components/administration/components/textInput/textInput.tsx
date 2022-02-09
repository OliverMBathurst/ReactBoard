import React from 'react'
import './styles.scss'

interface IInputProps {
    title: string
    required?: boolean
    text?: string
    inputRef?: React.Ref<HTMLInputElement>
    onChange?: (value: string) => void
}

const Input = (props: IInputProps) => {
    const {
        text,
        inputRef,
        onChange,
        required = true,
        title = "",
    } = props

    return (
        <div className="input-box">
            <label className="input-box__text">{title}</label>
            <input
                required={required}
                className="input-box__input"
                ref={inputRef}
                defaultValue={text}
                onChange={e => onChange && onChange(e.target.value)}
            />
        </div>)
}

export default Input