import React, { useRef } from 'react'
import { SubmitButton } from '../../../../global/components'
import { INewCategory } from '../../../../global/interfaces/category'
import Input from '../textInput/textInput'
import './styles.scss'

interface ICreateCategoryPanel {
    onCategoryCreate: (category: INewCategory) => void
}

const CreateCategoryPanel = (props: ICreateCategoryPanel) => {
    const { onCategoryCreate } = props

    const inputRef = useRef<HTMLInputElement>(null)

    const onCategoryCreateInternal = () => {
        if (inputRef.current) {
            onCategoryCreate({
                name: inputRef.current.value
            })

            inputRef.current.value = ""
        }
    }

    return (
        <div className="create-category-panel">
            <form>
                <Input
                    title="Category Name"
                    inputRef={inputRef} />
                <SubmitButton
                    value="Create New Category"
                    onClick={() => onCategoryCreateInternal()} />
            </form>            
        </div>)
}

export default CreateCategoryPanel