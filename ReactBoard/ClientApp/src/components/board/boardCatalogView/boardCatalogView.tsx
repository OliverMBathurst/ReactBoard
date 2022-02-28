import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router'
import { IBoardCatalogItem } from '../../../global/interfaces/board'
import { BoardService } from '../../../services'

const boardService = new BoardService()

const BoardCatalogView = () => {
    const { boardUrlName } = useParams()
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