import React, { useRef, useState } from 'react'
import { Redirect } from 'react-router'
import './styles.scss'
import { BracketedLink } from '../../../../components'

interface IBoardHeaderProps {
    boardUrlName: string
}

const BoardOptionsHeader = (props: IBoardHeaderProps) => {
    const { boardUrlName } = props

    const [redirection, setRedirection] = useState<string>("")
    const inputRef = useRef<HTMLInputElement>(null)

    const onSearchSubmission = (e: React.FormEvent<HTMLFormElement>): void => {
        e.preventDefault();

        if (!inputRef.current || !inputRef.current.value) {
            return
        }

        setRedirection(`/${boardUrlName}/catalog?search=${inputRef.current.value}`)
    }

    const onCatalogRequested = () => {


    }

    const onArchiveRequested = () => {


    }

    if (redirection) {
        return <Redirect to={redirection} />
    }

    return (
        <div className="board-header">
            <form className="board-header__search-form" onSubmit={onSearchSubmission}>
                <input
                    className="board-header__search-form__search-box"
                    ref={inputRef}
                    type="text"
                    placeholder="Search..."
                />
            </form>
            <BracketedLink link={{ title: "Catalog", onClick: onCatalogRequested }} />
            <BracketedLink link={{ title: "Archive", onClick: onArchiveRequested }} />
        </div>)
}

export default BoardOptionsHeader