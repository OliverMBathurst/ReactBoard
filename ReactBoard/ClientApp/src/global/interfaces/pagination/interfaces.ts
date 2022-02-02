export interface IPaginationResult<T> {
    currentPage: number
    totalPages: number
    entities: T[]
}