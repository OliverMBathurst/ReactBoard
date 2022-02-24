import React from 'react'
import { ILinkItem } from '../../interfaces/link'
import './styles.scss'

interface IBracketedLinkProps {
    link: ILinkItem
}

const BracketedLink = (props: IBracketedLinkProps) => {
    const { link } = props

    return (
        <div className="bracketed-link">
            [{link.element
                ? link.element
                : (
                    <span
                        className="bracketed-link__text"
                        onClick={link.onClick}
                    >
                        {link.title}
                    </span>)
            }]
        </div>)
}

export default BracketedLink