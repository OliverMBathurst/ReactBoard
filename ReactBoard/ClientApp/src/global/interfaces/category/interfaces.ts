import { IBoard } from "../board";
import { IEntity } from "../common";

export interface ICategory extends IEntity<number | null> {
    name: string
    boards: IBoard[]
}

export interface ICategoryService {
    createCategory: (newCategory: INewCategory) => Promise<void>
    getAll: () => Promise<ICategory[]>
}

export interface INewCategory {
    name: string
}