import React, { useRef } from 'react'
import { INewCategory } from '../../../../global/interfaces/category/interfaces'
import Input from '../textInput/textInput'
import './styles.scss'

interface ICreateCategoryPanel {
    onCategoryCreate: (category: INewCategory) => void
}

const CreateCategoryPanel = (props: ICreateCategoryPanel) => {
    const { onCategoryCreate } = props

    const inputRef = useRef<HTMLInputElement>(null)

    return (
        <div className="create-category-panel">
            <Input title="Category Name" inputRef={inputRef} />
            <input
                className="submit-category"
                value="Create New Category"
                type="button"
                onClick={() => {
                    const ref = inputRef.current
                    if (ref) {
                        onCategoryCreate({
                            name: ref.value
                        })
                    }
                }} />
        </div>)
}

export default CreateCategoryPanel