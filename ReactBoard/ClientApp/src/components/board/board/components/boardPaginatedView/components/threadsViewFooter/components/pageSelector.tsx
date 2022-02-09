import React, { memo } from 'react'
import './styles.scss'

interface IPageSelectorProps {
    pageNumber: number
    selected: boolean
    onClick: () => void
}

const PageSelector = (props: IPageSelectorProps) => {
    const {
        pageNumber,
        selected,
        onClick
    } = props

    return (
        <a className="pageSelector">
            [
            <span className={`pageSelector__text${selected && "--selected"}`} onClick={onClick}>
                {pageNumber}
            </span>
            ]
        </a>)
}

export default memo(PageSelector)