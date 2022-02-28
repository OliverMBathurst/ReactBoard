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
            <span className="bracketed-link__divider">
                [
            </span>
            {link.element
                ? link.element
                : (
                    <span
                        className="bracketed-link__text highlightable-link"
                        onClick={link.onClick}
                    >
                        {link.title}
                    </span>)
            }
            <span className="bracketed-link__divider">
                ]
            </span>
        </div>)
}

export default BracketedLink