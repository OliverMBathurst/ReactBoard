import React, { createContext, useEffect, useState } from 'react'
import { MessageKeyService } from '../../services'
import { Language, MessageKey } from '../enums'

interface IMessageKeysContextProps {
    children: React.ReactNode
    language?: Language
}

interface IMessageKeyContext {
    messageKeyMap: Map<MessageKey, string>
}

export const MessageKeyContext = createContext<IMessageKeyContext>({ messageKeyMap: new Map<MessageKey, string>() })

const _messageKeyService = new MessageKeyService()

const MessageKeysContext = (props: IMessageKeysContextProps) => {
    const {
        children,
        language = Language.English
    } = props

    const [messageKeyMap, setMessageKeyMap] = useState<Map<MessageKey, string>>(new Map<MessageKey, string>())

    useEffect(() => {
        let mounted = true

        _messageKeyService.getAllMessageKeys(language).then(res => {
            if (mounted) {
                setMessageKeyMap(res)
            }
        })

        return () => {
            mounted = false
        }
    }, [language])

    return (
        <MessageKeyContext.Provider value={{ messageKeyMap: messageKeyMap }}>
            {children}
        </MessageKeyContext.Provider>)
}

export default MessageKeysContext