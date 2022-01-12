import React from 'react'
import './styles.scss'

interface ISubmitButtonProps {
    value: string
    onClick: () => void
}

const SubmitButton = (props: ISubmitButtonProps) => {
    const { value, onClick } = props

    return (
        <input
            className="submit-button"
            type="submit"
            value={value}
            onClick={() => onClick()}
        />)
}

export default SubmitButton