import React, { useMemo } from 'react'

interface IThreadsViewFooterProps {
    boardId: number
    currentPage: number
    totalPages: number
}

const ThreadsViewFooter = (props: IThreadsViewFooterProps) => {
    const {
        boardId,
        currentPage,
        totalPages
    } = props

    const getPageNumbers = useMemo(() => {
        let newNumbers: number[] = []
        for (var i = 1; i <= totalPages; i++) {
            newNumbers.push(i)
        }
        return newNumbers
    }, [totalPages])

    return (
        <>
            {getPageNumbers.map(num => {
                return (
                    <>


                    </>)
            })}
        </>)
}

export default ThreadsViewFooter