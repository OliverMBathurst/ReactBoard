export interface IImageKey {
    imageId: number | null
}

export interface IImage extends IImageKey {
    location: string
    metadata: IImageMetadata
}

export interface IImageMetadata extends IImageKey {
    size: number
    width: number
    height: number
}