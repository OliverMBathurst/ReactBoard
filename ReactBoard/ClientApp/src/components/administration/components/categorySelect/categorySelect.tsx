﻿import React from 'react'
import { ICategory } from '../../../../global/interfaces/category/interfaces'
import './styles.scss'

interface ICategorySelect {
    categories: ICategory[]
    onCategorySelected: (category: ICategory) => void
}

const CategorySelect = (props: ICategorySelect) => {
    const {
        categories,
        onCategorySelected
    } = props

    const onCategoryChangedInternal = (e: React.FormEvent<HTMLSelectElement>) => {
        const category = categories.find(x => x.id === (e.target as any).value as number)
        if (category) {
            onCategorySelected(category)
        }
    }

    return (
        <select className="category-select" onChange={(e: React.FormEvent<HTMLSelectElement>) => onCategoryChangedInternal(e)}>
            <option key={-1} defaultValue>Please select category</option>
            {categories.map(c => {
                return (
                    <option key={`${c.id}-${c.name}`} value={c.id}>
                        {c.name}
                    </option>)
            })}
        </select>)
}

export default CategorySelect