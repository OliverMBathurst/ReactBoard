import React, { useEffect, useState } from 'react'
import { BoardService } from '../../../services'
import { IBoardCatalogItem } from '../../../global/interfaces/board'

interface IBoardCatalogViewProps {
    boardUrlName: string
}

const boardService = new BoardService()

const BoardCatalogView = (props: IBoardCatalogViewProps) => {
    const { boardUrlName } = props

    const [catalogItems, setCatalogItems] = useState<IBoardCatalogItem[]>([])

    useEffect(() => {
        let mounted = true

        boardService.getCatalog(boardUrlName).then(res => {
            if (mounted) {
                setCatalogItems(res.items)
            }
        })

        return () => {
            mounted = false
        }
    }, [boardUrlName])

    //todo
    return (
        <>


        </>)
}

export default BoardCatalogView