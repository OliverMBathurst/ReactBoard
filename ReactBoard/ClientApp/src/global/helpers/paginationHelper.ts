export const getPageNumbers = (count: number): number[] => {
    const numbers: number[] = []
    for (var i = 0; i < count; i++) {
        numbers.push(i + 1)
    }
    return numbers
}