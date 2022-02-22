export interface ISiteStatistics {
    totalPosts: number
    totalUsers: number
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