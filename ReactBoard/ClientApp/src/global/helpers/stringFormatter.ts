export const formatString = (str: string, ...args: any[]): string => {
    var result = str
    for (var j = 0; j < args.length; j++) {
        result = result.replace(`${j}`, args[j])
    }

    return result
}