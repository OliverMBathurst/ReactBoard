import React, { useEffect, useState } from 'react'
import { IThread } from '../../global/interfaces/thread'
import { ThreadService } from '../../services'
import { ThreadPost } from './components'
import './styles.scss'
import { withThreadWrapper } from '../../global/HOC'

interface IThreadProps {
    threadId: number
    boardUrlName: string
}

const _threadService = new ThreadService()

const Thread = (props: IThreadProps) => {
    const {
        threadId,
        boardUrlName
    } = props

    const [thread, setThread] = useState<IThread>()
    const [autoRefreshEnabled, setAutoRefreshEnabled] = useState<boolean>(false)
    const [autoRefreshTimeout, setAutoRefreshTimeout] = useState<NodeJS.Timeout>()

    useEffect(() => {
        let mounted = true

        _threadService.getThread(threadId).then(res => {
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

        const newPosts = await _threadService.getNewPostsForThread(threadId, threadCopy.posts[threadCopy.posts.length - 1].time)
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

    return (withThreadWrapper(() => {
        return (
            <div className="thread">
                {thread.posts.map(post => <ThreadPost post={post} />)}
            </div>)
    }, {
        thread: thread,
        boardUrlName: boardUrlName,
        onAutoRefreshToggled: onAutoRefreshToggled,
        onUpdateRequested: onUpdateRequested,
        autoRefreshEnabled: autoRefreshEnabled
    }))
}

export default Thread