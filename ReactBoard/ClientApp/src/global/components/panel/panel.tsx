import React from 'react'
import CloseIcon from '../../../assets/closeIcon/closeIcon'
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
            <div className="panel-top-box">
                <span className="panel-top-box-text">
                    {title}
                </span>
                {dismissable &&
                    <CloseIcon
                        onClick={() => onClose && onClose()} />
                }
            </div>
            <div className="panel-description-box">
                {children}
            </div>
        </div>)
}

export default Panel