export interface IImage {
    data: string
    metadata: IImageMetadata
}

export interface INewImage {
    data: File
}

export interface IImageMetadata {
    size: number
    width: number
    height: number
}