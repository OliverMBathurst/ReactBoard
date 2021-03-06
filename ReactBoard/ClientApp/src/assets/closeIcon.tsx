import React, { memo } from 'react'

interface ICloseIconProps {
    onClick: () => void
}

const CloseIcon = (props: ICloseIconProps) => {
    const { onClick } = props

    return (
        <svg
            id="closeIcon"
            onClick={() => onClick()}
            fill="#FFFFFF"
            viewBox="0 0 50 50"
            width="1rem"
            height="1rem">
            <path d="M 7.71875 6.28125 L 6.28125 7.71875 L 23.5625 25 L 6.28125 42.28125 L 7.71875 43.71875 L 25 26.4375 L 42.28125 43.71875 L 43.71875 42.28125 L 26.4375 25 L 43.71875 7.71875 L 42.28125 6.28125 L 25 23.5625 Z" />
        </svg>)
}

export default memo(CloseIcon)