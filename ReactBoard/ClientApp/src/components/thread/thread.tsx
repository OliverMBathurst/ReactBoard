import React, { useEffect, useState } from 'react'
import { IThread } from '../../global/interfaces/thread'
import { ThreadService } from '../../services'
import './styles.scss'
import { ThreadPost, ThreadControls } from './components'
import withGlobalWrapper from '../../global/HOC/globalWrapper'

interface IThreadProps {
    id: number
}

const threadService = new ThreadService()

const Thread = (props: IThreadProps) => {
    const { id: threadId } = props
    const [thread, setThread] = useState<IThread>()

    useEffect(() => {
        let mounted = true

        threadService.getThread(threadId).then(res => {
            if (mounted) {
                setThread(res)
            }
        })

        return () => {
            mounted = false
        }
    }, [threadId])

    if (!thread) {
        return null
    }

    return (
        <div className="thread">
            <ThreadControls thread={thread}>
                {thread.posts.map(post => <ThreadPost post={post} />)}
            </ThreadControls>
        </div>)
}

export default withGlobalWrapper(Thread)