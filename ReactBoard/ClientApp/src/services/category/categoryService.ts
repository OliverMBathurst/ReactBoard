import axios from "axios"
import { HttpStatusCodes } from "../../global/enums/api/enums"
import { ICategory, ICategoryService } from "../../global/interfaces/category/interfaces"

class CategoriesService implements ICategoryService {
    private endpoint: string = 'category'

    getAll = (): Promise<ICategory[]> => {
        return new Promise<ICategory[]>((resolve, reject) => {
            axios.get<ICategory[]>(this.endpoint).then(res => {
                if (res.status === HttpStatusCodes.Status200OK) {
                    resolve(res.data)
                }

                reject()
            })
        })
    }

    createNew = (category: ICategory): Promise<void> => {
        return new Promise<void>((resolve, reject) => {
            axios.post<ICategory>(this.endpoint).then(res => {
                if (res.status === HttpStatusCodes.Status200OK) {
                    resolve()
                }

                reject()
            })
        })
    }
}

export default CategoriesService