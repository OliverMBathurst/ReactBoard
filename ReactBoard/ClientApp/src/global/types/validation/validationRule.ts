import { ValidationCode } from "../../enums/validation/enums"
import { IAbstractValidator, IValidationFailure, IValidationRule } from "../../interfaces/validation/interfaces"

class ValidationRule<T, TProp> implements IValidationRule<T, TProp> {
    private source: T
    private code: ValidationCode | undefined
    private propertySelectionRule: (src: T) => TProp
    private propertyValidationRule: ((prop: TProp) => boolean) | undefined
    private message: string | undefined
    private innerValidatorCreationRule: ((prop: TProp) => IAbstractValidator) | undefined

    constructor(
        source: T,
        code: ValidationCode | undefined,
        propertySelectionRule: (src: T) => TProp,
        propertyValidationRule: ((prop: TProp) => boolean) | undefined,
        message: string | undefined,
        innerValidatorCreationRule: ((prop: TProp) => IAbstractValidator) | undefined) {
        this.source = source
        this.code = code
        this.propertySelectionRule = propertySelectionRule
        this.propertyValidationRule = propertyValidationRule
        this.message = message
        this.innerValidatorCreationRule = innerValidatorCreationRule
    }

    execute = (): IValidationFailure[] => {
        const prop = this.propertySelectionRule(this.source)

        if (this.innerValidatorCreationRule) {
            return this.innerValidatorCreationRule(prop).execute()
        }

        if (this.propertyValidationRule && this.code && this.message) {
            return this.propertyValidationRule(prop)
                ? []
                : [{
                    code: this.code,
                    message: this.message
                }]
        } else {
            throw new Error("Code and/or message is undefined for validation rule")
        }
    }
}

export default ValidationRule