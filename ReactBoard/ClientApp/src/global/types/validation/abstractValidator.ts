import { IAbstractValidator, IValidationFailure, IValidationRule } from "../../interfaces/validation"

abstract class AbstractValidator<T> implements IAbstractValidator<T> {
    private rules: IValidationRule<T>[]

    constructor(rules: IValidationRule<T>[]) {
        this.rules = rules
    }

    execute = (source: T): IValidationFailure[] => {
        return this.rules.map(r => r.execute(source))
            .reduce((a, b) => a.concat(b), [])
    }
}

export default AbstractValidator