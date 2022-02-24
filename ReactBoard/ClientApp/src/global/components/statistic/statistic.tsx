import React from 'react'
import { IStatisticItem } from '../../interfaces/statistic'
import './styles.scss'

interface IStatisticProps {
    item: IStatisticItem
    isLast: boolean
}

const Statistic = (props: IStatisticProps) => {
    const {
        item: {
            dataTip,
            value
        },
        isLast
    } = props

    return (
        <span
            className="statistic"
            key={`${dataTip}-${value}`}
            data-tip={dataTip}
        >
            {`${value}${!isLast && "/"}`}
        </span>)
}

export default Statistic