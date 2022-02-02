import { ValidationCode } from "../../enums"
import { IAbstractValidator, IValidationFailure, IValidationRule } from "../../interfaces/validation"

class ValidationRule<T, TProp> implements IValidationRule<T> {
    private code: ValidationCode | undefined
    private propertySelectionRule: (src: T) => TProp
    private propertyValidationRule: ((prop: TProp) => boolean) | undefined
    private message: string | undefined
    private innerValidatorCreationRule: ((prop: TProp) => IAbstractValidator<TProp>) | undefined

    constructor(
        code: ValidationCode | undefined,
        propertySelectionRule: (src: T) => TProp,
        propertyValidationRule: ((prop: TProp) => boolean) | undefined,
        message: string | undefined,
        innerValidatorCreationRule: ((prop: TProp) => IAbstractValidator<TProp>) | undefined) {
        this.code = code
        this.propertySelectionRule = propertySelectionRule
        this.propertyValidationRule = propertyValidationRule
        this.message = message
        this.innerValidatorCreationRule = innerValidatorCreationRule
    }

    execute = (source: T): IValidationFailure[] => {
        const prop = this.propertySelectionRule(source)

        if (this.innerValidatorCreationRule) {
            return this.innerValidatorCreationRule(prop).execute(prop)
        }

        if (this.propertyValidationRule && this.code && this.message) {
            return this.propertyValidationRule(prop)
                ? []
                : [{
                    code: this.code,
                    message: this.message
                }]
        } else {
            throw new Error("This validation rule has not been correctly configured.")
        }
    }
}

export default ValidationRule