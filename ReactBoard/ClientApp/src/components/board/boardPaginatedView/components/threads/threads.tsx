import React from 'react'
import { IThread } from '../../../../../global/interfaces/thread'

interface IThreadsProps {
    boardUrlName: string
    threads: IThread[]
}

const Threads = (props: IThreadsProps) => {
    const {
        boardUrlName,
        threads
    } = props

    return (
        <div className="threads-view">
            {threads.map(thread => {
                return (
                    <>

                    </>)
            })}
        </div>)
}

export default Threads