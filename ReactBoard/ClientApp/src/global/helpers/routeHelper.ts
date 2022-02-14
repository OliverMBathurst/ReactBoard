export const getBoardRoute = (boardUrlName: string) => {
    return `${prefix}/${boardUrlName}`
}

export const getBoardCatalogRoute = (boardUrlName: string) => {
    return `${prefix}/${boardUrlName}/catalog`
}

const prefix = `${window.location.protocol}//${window.location.hostname}`