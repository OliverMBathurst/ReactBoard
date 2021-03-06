export const toMap = <T, K, V>(collection: T[], keySelector: (obj: T) => K, valueSelector: (obj: T) => V): Map<K, V> => {
    if (collection.length === 0) {
        return new Map<K, V>()
    }

    const map = new Map<K, V>()

    for (var elem of collection) {
        const key = keySelector(elem)

        if (map.get(key)) {
            throw new Error("Key is already present in the map")
        }

        map.set(key, valueSelector(elem))
    }

    return map
}