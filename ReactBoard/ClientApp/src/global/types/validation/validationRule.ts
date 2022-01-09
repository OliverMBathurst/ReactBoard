import { IValidationResult, IValidationRule } from "./interfaces";

class ValidationRule<T, TProp> implements IValidationRule<T, TProp> {
    source: T
    propertySelectionRule: (src: T) => TProp
    propertyValidationRule: (prop: TProp) => boolean
    message: string

    constructor(
        source: T,
        propertySelectionRule: (src: T) => TProp,
        propertyValidationRule: (prop: TProp) => boolean,
        message: string)
    {
        this.source = source
        this.propertySelectionRule = propertySelectionRule
        this.propertyValidationRule = propertyValidationRule
        this.message = message
    }

    execute = (): IValidationResult => {
        const success = this.propertyValidationRule(this.propertySelectionRule(this.source))

        const result: IValidationResult = {
            success: success
        }

        if (!success) {
            result.message = this.message
        }

        return result
    }
}

export default ValidationRule