import React from 'react'
import { IDropdownOptions } from '../../../../interfaces/misc'
import './styles.scss'

interface IPanelDropdownProps {
    options: IDropdownOptions
}

const PanelDropdown = (props: IPanelDropdownProps) => {
    const {
        options: {
            items,
            defaultValue
        }
    } = props

    const onOptionSelected = (e: React.ChangeEvent<HTMLSelectElement>) => {
        const val = parseInt(e.target.value)
        var matches = items.filter(item => item.id === val)
        if (matches.length > 0) {
            matches[0].onSelect()
        }
    }

    return (
        <select
            className="panel-dropdown"
            onChange={onOptionSelected}
            defaultValue={defaultValue}
        >
            {items.map(item => {
                return (
                    <option className="panel-dropdown__option" key={item.id} value={item.id}>
                        {item.text}
                    </option>)
            })}
        </select>)
}

export default PanelDropdown