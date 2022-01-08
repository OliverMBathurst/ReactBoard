import { IEntity } from "../common/interfaces";

export interface IImage extends IEntity<number | null> {
    location: string
    metadata: IImageMetadata
}

export interface IImageMetadata extends IEntity<number | null> {
    size: number
    width: number
    height: number
}