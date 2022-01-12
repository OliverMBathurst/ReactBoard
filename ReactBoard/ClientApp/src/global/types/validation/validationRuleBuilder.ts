import { IAbstractValidator, IValidationRule, IValidationRuleBuilder } from "../../interfaces/validation/interfaces"
import ValidationRule from "./validationRule"
import { ValidationCode } from "../../enums/validation/enums"

class ValidationRuleBuilder<T, TProp> implements IValidationRuleBuilder<T, TProp> {
    private source: T
    private code: ValidationCode | undefined
    private propertySelectionRule: ((src: T) => TProp) | undefined
    private propertyValidationRule: ((prop: TProp) => boolean) | undefined
    private message: string | undefined
    private innerValidatorCreationRule: ((prop: TProp) => IAbstractValidator) | undefined

    constructor(source: T) {
        this.source = source
    }

    withPropertySelectionRule = (propertySelectionRule: (src: T) => TProp): IValidationRuleBuilder<T, TProp> => {
        this.propertySelectionRule = propertySelectionRule
        return this
    }

    withPropertyValidationRule = (propertyValidationRule: (prop: TProp) => boolean): IValidationRuleBuilder<T, TProp> => {
        this.propertyValidationRule = propertyValidationRule
        return this
    }

    withInnerValidator = (innerValidatorCreationRule: (prop: TProp) => IAbstractValidator): IValidationRule<T, TProp> => {
        this.innerValidatorCreationRule = innerValidatorCreationRule
        return this.build()
    }

    withMessage = (message: string): IValidationRuleBuilder<T, TProp> => {
        this.message = message
        return this
    }

    withCode = (code: ValidationCode): IValidationRuleBuilder<T, TProp> => {
        this.code = code
        return this
    }

    build = (): IValidationRule<T, TProp> => {
        if (!this.propertySelectionRule || (!this.innerValidatorCreationRule && (!this.code || !this.propertyValidationRule || !this.message))) {
            throw new Error("One or more properties have not been set")
        }

        return new ValidationRule<T, TProp>(
            this.source,
            this.code,
            this.propertySelectionRule,
            this.propertyValidationRule,
            this.message,
            this.innerValidatorCreationRule
        )
    }
}

export default ValidationRuleBuilder