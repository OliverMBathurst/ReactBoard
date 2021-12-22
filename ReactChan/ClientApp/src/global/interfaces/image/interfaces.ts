import { IEntity } from "../common/interfaces";

export interface IImage extends IEntity<string> {
    location: string
    metadata: IImageMetadata
}

export interface IImageMetadata extends IEntity<string> {
    size: number
    width: number
    height: number
}