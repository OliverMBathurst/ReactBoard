import { IBoard } from "../board/interfaces";
import { IEntity } from "../common/interfaces";

export interface ICategory extends IEntity<number | null> {
    name: string
    boards: IBoard[]
}

export interface ICategoryService {
    getAll: () => Promise<ICategory[]>
}