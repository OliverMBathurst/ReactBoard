import { UserRole } from "../../enums";
import { IEntity } from "../common";

export interface IUser extends IEntity<number | null> {
    name: string
    emailAddress: string
}

export interface IUserRoleMapping extends IEntity<number | null> {
    userId: number
    role: UserRole
}