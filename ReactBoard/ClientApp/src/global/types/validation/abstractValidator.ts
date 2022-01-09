import { IValidationExecutable, IValidationResult } from "./interfaces"

abstract class AbstractValidator {
    private rules: IValidationExecutable[]

    constructor(rules: IValidationExecutable[]) {
        this.rules = rules
    }

    execute = (): IValidationResult[] => {
        return this.rules.map(r => r.execute())
    }
}

export default AbstractValidator