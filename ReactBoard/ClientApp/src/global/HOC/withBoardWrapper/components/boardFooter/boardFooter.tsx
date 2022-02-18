import React, { useMemo } from 'react'
import { Link } from 'react-router-dom'
import { LinkButton } from '../../../../components'
import { getPageNumbers } from '../../../../helpers'
import './styles.scss'

interface IBoardFooterProps {
    boardUrlName: string
    currentPage: number
    totalPages: number
    onAllRequested: () => void
}

const BoardFooter = (props: IBoardFooterProps) => {
    const {
        boardUrlName,
        currentPage,
        totalPages,
        onAllRequested
    } = props

    const pageNumbers = useMemo(() => getPageNumbers(totalPages), [totalPages])

    return (
        <div className="board-footer">
            <div className="board-footer__left-container">
                <span className="board-footer__left-container__bracket-option">
                    [
                    <span className="board-footer__left-container__bracket-option__link" onClick={() => onAllRequested()}>
                        All
                    </span>
                    ]
                </span>
                {pageNumbers.map(num => {
                    return (
                        <span className="board-footer__left-container__bracket-option">
                            [
                            <Link
                                key={num}
                                className={`board-footer__left-container__bracket-option__link${currentPage === num && "--selected"}`}
                                to={num !== currentPage ? `/${boardUrlName}/${num}` : "#"}
                            >
                                {num}
                            </Link>
                            ]
                        </span>)
                })}
                <LinkButton
                    to={`/${boardUrlName}/${currentPage + 1}`}
                    text="Next"
                    visible={currentPage + 1 <= totalPages}
                />
                <Link to={`/${boardUrlName}/catalog`}>
                    Catalog
                </Link>
            </div>
        </div>)
}

export default BoardFooter