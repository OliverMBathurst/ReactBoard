import { UserRole } from "../../enums/user/enums";
import { IEntity } from "../common/interfaces";

export interface IUser extends IEntity<number | null> {
    name: string
    emailAddress: string
}

export interface IUserRoleMapping extends IEntity<number | null> {
    userId: number
    role: UserRole
}