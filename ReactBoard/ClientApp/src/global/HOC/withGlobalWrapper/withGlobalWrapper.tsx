import React from 'react'


interface IGlobalWrapperProps {

}

const withGlobalWrapper = <P extends object>(component: React.ComponentType<P>, props: IGlobalWrapperProps) => {
    //todo
    return component
}

export default withGlobalWrapper