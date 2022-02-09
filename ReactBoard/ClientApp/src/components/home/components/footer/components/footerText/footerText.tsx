import React from 'react'
import './styles.scss'

interface IFooterTextProps {
    text: string
}

const FooterText = (props: IFooterTextProps) => {
    const { text } = props

    return (
        <div className="footer-text">
            <span className="footer-text__period">
                •
            </span>
            <span className="footer-text__text">
                {text}
            </span>
        </div>
    )
}

export default FooterText