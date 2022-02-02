import { IAbstractValidator, IValidationExecutable, IValidationFailure } from "../../interfaces/validation"

abstract class AbstractValidator<T> implements IAbstractValidator<T> {
    private rules: IValidationExecutable<T>[]

    constructor(rules: IValidationExecutable<T>[]) {
        this.rules = rules
    }

    execute = (source: T): IValidationFailure[] => {
        return this.rules.map(r => r.execute(source))
            .reduce((a, b) => a.concat(b), [])
    }
}

export default AbstractValidator