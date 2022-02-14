import React, { useEffect, useState } from 'react'
import withGlobalWrapper from '../../global/HOC/globalWrapper'
import { IThread } from '../../global/interfaces/thread'
import { ThreadService } from '../../services'
import { ThreadControls, ThreadPost } from './components'
import './styles.scss'

interface IThreadProps {
    id: number
    boardUrlName: string
}

const threadService = new ThreadService()

const Thread = (props: IThreadProps) => {
    const {
        id: threadId,
        boardUrlName
    } = props

    const [thread, setThread] = useState<IThread>()
    const [autoRefreshEnabled, setAutoRefreshEnabled] = useState<boolean>(false)
    const [autoRefreshTimeout, setAutoRefreshTimeout] = useState<NodeJS.Timeout>()

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

    const onUpdateRequested = async () => {
        if (!thread) {
            return
        }

        if (autoRefreshTimeout) {
            clearTimeout(autoRefreshTimeout)
        }

        const threadCopy: IThread = { ...thread }

        const newPosts = await threadService.getNewPostsForThread(threadId, threadCopy.posts[threadCopy.posts.length - 1].time)
        threadCopy.posts = threadCopy.posts.concat(newPosts)

        setThread(threadCopy)

        if (autoRefreshEnabled) {
            setNewTimeout()
        }
    }

    const onAutoRefreshToggled = () => {
        if (autoRefreshTimeout) {
            clearTimeout(autoRefreshTimeout)
        }

        const toggled = !autoRefreshEnabled
        setAutoRefreshEnabled(toggled)

        if (toggled) {
            setNewTimeout()
        }
    }

    const setNewTimeout = () => {
        setAutoRefreshTimeout(setTimeout(() => {
            //todo
        }, 10000))
    }

    if (!thread) {
        return null
    }

    return (
        <div className="thread">
            <ThreadControls
                thread={thread}
                boardUrlName={boardUrlName}
                onAutoRefreshToggled={onAutoRefreshToggled}
                onUpdateRequested={onUpdateRequested}
                autoRefreshEnabled={autoRefreshEnabled}
            >
                {thread.posts.map(post => <ThreadPost post={post} />)}
            </ThreadControls>
        </div>)
}

export default withGlobalWrapper(Thread)