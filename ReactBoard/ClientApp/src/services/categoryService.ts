import axios from "axios"
import { HttpStatusCode } from "../global/enums"
import { ICategory, ICategoryService, INewCategory } from "../global/interfaces/category"

class CategoryService implements ICategoryService {
    private endpoint: string = 'category'

    getAll = (): Promise<ICategory[]> => {
        return new Promise<ICategory[]>((resolve, reject) => {
            axios.get<ICategory[]>(this.endpoint).then(res => {
                if (res.status === HttpStatusCode.Status200OK) {
                    resolve(res.data)
                }

                reject()
            })
        })
    }

    createCategory = (category: INewCategory): Promise<void> => {
        return new Promise<void>((resolve, reject) => {
            axios.post<INewCategory>(this.endpoint, category).then(res => {
                if (res.status === HttpStatusCode.Status200OK) {
                    resolve()
                }

                reject()
            })
        })
    }
}

export default CategoryService