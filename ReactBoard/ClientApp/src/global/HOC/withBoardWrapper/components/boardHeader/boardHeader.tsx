import React, { useRef, useState } from 'react'
import { Redirect } from 'react-router'
import './styles.scss'

interface IBoardHeaderProps {
    boardUrlName: string
}

const BoardHeader = (props: IBoardHeaderProps) => {
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

    if (redirection) {
        return <Redirect to={{ pathname: redirection }} />
    }

    return (
        <div className="board-header">
            <form onSubmit={onSearchSubmission}>
                <input
                    className="board-header__search-box"
                    ref={inputRef}
                    type="text"
                    placeholder="Search..."
                />
            </form>
        </div>)
}

export default BoardHeader