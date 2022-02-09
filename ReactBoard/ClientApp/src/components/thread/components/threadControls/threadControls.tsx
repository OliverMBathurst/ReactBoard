import React from 'react'
import { IThread } from '../../../../global/interfaces/thread'

interface IThreadControlsProps {
    thread: IThread
    children: React.ReactNode
}

const ThreadControls = (props: IThreadControlsProps) => {
    const {
        thread,
        children
    } = props

    return (
        <>
            {children}
        </>)
}

export default ThreadControls