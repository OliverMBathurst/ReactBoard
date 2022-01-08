import React from 'react'
import './styles.scss'

interface IPanelProps {
    title: string
    dismissable: boolean
    children?: React.ReactNode
    onClose?: () => void
}

const Panel = (props: IPanelProps) => {
    const {
        title,
        dismissable,
        children,
        onClose
    } = props

    return (
        <div className="panel">
            <div className="panel-top-box">
                <span className="panel-top-box-text">
                    {title}
                </span>
                {dismissable && <></>}
            </div>
            <div className="panel-description-box">
                {children}
            </div>
        </div>)
}

export default Panel