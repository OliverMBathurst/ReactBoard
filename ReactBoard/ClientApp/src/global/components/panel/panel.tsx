import React, { memo } from 'react'
import { CloseIcon } from '../../../assets'
import './styles.scss'

interface IPanelProps {
    title: string
    children: React.ReactNode
    dismissable?: boolean
    onClose?: () => void
}

const Panel = (props: IPanelProps) => {
    const {
        title,
        children,
        dismissable = false,
        onClose
    } = props

    return (
        <div className="panel">
            <div className="panel__top-box">
                <span className="panel__top-box__text">
                    {title}
                </span>
                {dismissable &&
                    <CloseIcon onClick={() => onClose && onClose()} />
                }
            </div>
            <div className="panel__description-box">
                {children}
            </div>
        </div>)
}

export default memo(Panel)