export const formatString = (str: string, ...args: any[]): string => {
    var openBCount = 0;
    for (var i of str) {
        if (i === '{') {
            openBCount++
        }
    }

    if (openBCount !== args.length) {
        throw new Error('Arguments length mismatch')
    }

    var result = str
    for (var j = 0; j < args.length; j++) {
        result = result.replace(`${j}`, args[j])
    }

    return result
}