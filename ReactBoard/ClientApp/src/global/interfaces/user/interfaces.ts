import { UserRole } from "../../enums/user/enums";

export interface IUserKey {
    userId: number | null
}

export interface IUser extends IUserKey {
    name: string
    emailAddress: string
}

export interface IUserRoleMapping extends IUserKey {
    role: UserRole
}