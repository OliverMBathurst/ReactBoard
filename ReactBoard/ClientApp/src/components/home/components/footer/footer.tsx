import React from 'react'
import { SITE_COPYRIGHT_NOTICE } from '../../../../global/constants/strings'
import FooterText from './components/footerText/footerText'
import './styles.scss'

const Footer = () => {
    return (
        <div className="footer">
            <a className="footer__link" href="/">
                <FooterText text='Link1' />
            </a>
            <a className="footer__link" href="/">
                <FooterText text='Link2' />
            </a>
            <a className="footer__link" href="/">
                <FooterText text='Link3' />
            </a>
            <a className="footer__link" href="/">
                <FooterText text='Link4' />
            </a>
            <span className="footer__copyright-notice">{SITE_COPYRIGHT_NOTICE}</span>
        </div>)
}

export default Footer