import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router'
import { withThreadWrapper } from '../../global/HOC'
import { IThread } from '../../global/interfaces/thread'
import { ThreadService } from '../../services'
import { ThreadPost } from './components'
import './styles.scss'

const _threadService = new ThreadService()

const Thread = () => {
    const {
        boardUrlName,
        threadId: id
    } = useParams()

    const threadId = parseInt(id)
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

    return (
        <div className="thread">
            {thread.posts.map(post => <ThreadPost post={post} />)}
        </div>)
}

export default withThreadWrapper(Thread)