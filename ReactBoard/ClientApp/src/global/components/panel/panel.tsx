import React, { memo } from 'react'
import { CloseIcon } from '../../../assets'
import { IDropdownOptions } from '../../interfaces/misc'
import { PanelDropdown } from './components'
import './styles.scss'

interface IPanelProps {
    title: string
    children: React.ReactNode
    dismissable?: boolean
    dropdownOptions?: IDropdownOptions
    onClose?: () => void
}

const Panel = (props: IPanelProps) => {
    const {
        title,
        children,
        dismissable = false,
        dropdownOptions,
        onClose
    } = props

    return (
        <div className="panel">
            <div className="panel__top-box">
                <span className="panel__top-box__text">
                    {title}
                </span>
                <div className="panel__top-box__options-container">
                    {dropdownOptions &&
                        <PanelDropdown options={dropdownOptions} />
                    }
                    {dismissable &&
                        <CloseIcon onClick={() => onClose && onClose()} />
                    }
                </div>
            </div>
            <div className="panel__description-box">
                {children}
            </div>
        </div>)
}

export default memo(Panel)