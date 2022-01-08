import React from 'react'
import './styles.scss'

interface IFooterTextProps {
    text: string
}

const FooterText = (props: IFooterTextProps) => {
    const { text } = props

    return (
        <>
            <span className="footer-text-period">
                •
            </span>
            <span className="footer-text">
                {text}
            </span>
        </>
    )
}

export default FooterText