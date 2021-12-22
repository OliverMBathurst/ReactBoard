import { UserRole } from "../../enums/user/enums";
import { IEntity } from "../common/interfaces";

export interface IUser extends IEntity<string> {
    name: string
    emailAddress: string
}

export interface IUserRoleMapping extends IEntity<string> {
    userId: string
    role: UserRole
}