import { IKeyValuePair } from "../interfaces/types/interfaces";

export function groupBy<T, K>(arr: T[], keySelector: (obj: T) => K): IKeyValuePair<K, T[]>[] {
    var groupings: IKeyValuePair<K, T[]>[] = []
    for (var entry of arr) {
        const key = keySelector(entry), idx = groupings.findIndex(x => x.key === key)
        if (idx !== -1) {
            groupings[idx].value.push(entry)
        } else {
            groupings.push({ key: key, value: [entry] })
        }
    }

    return groupings
}