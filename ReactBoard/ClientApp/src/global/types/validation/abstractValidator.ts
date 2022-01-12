import { IAbstractValidator, IValidationExecutable, IValidationFailure } from "../../interfaces/validation/interfaces"

abstract class AbstractValidator implements IAbstractValidator {
    private rules: IValidationExecutable[]

    constructor(rules: IValidationExecutable[]) {
        this.rules = rules
    }

    execute = (): IValidationFailure[] => {
        return this.rules.map(r => r.execute()).reduce((a, b) => a.concat(b), [])
    }
}

export default AbstractValidator