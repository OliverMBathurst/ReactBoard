export interface ISiteStatistic {
    placeholder: string
    value: string
}

export interface IDropdownOptions {
    items: IDropdownOption[]
    defaultValue: number
}

export interface IDropdownOption {
    id: number
    text: string
    onSelect: () => void
}