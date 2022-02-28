import React, { ComponentType } from "react"
import { BoardsNavBar } from "../../components"
import "./styles.scss"

const withBoardNavigation = (Component: ComponentType) => {
    return () => {
        return (
            <div className="board-navigation-wrapper">
                <BoardsNavBar />
                <Component />
                <BoardsNavBar />
            </div>)
    }
}

export default withBoardNavigation