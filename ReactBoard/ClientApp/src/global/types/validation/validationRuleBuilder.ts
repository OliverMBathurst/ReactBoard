import { ValidationRule } from "."
import { ValidationCode } from "../../enums"
import { IAbstractValidator, IValidationRule, IValidationRuleBuilder } from "../../interfaces/validation"

class ValidationRuleBuilder<T, TProp> implements IValidationRuleBuilder<T, TProp> {
    private code: ValidationCode | undefined
    private propertySelectionRule: ((src: T) => TProp) | undefined
    private propertyValidationRule: ((prop: TProp) => boolean) | undefined
    private message: string | undefined
    private innerValidatorCreationRule: (() => IAbstractValidator<TProp>) | undefined

    withPropertySelectionRule = (propertySelectionRule: (src: T) => TProp): IValidationRuleBuilder<T, TProp> => {
        this.propertySelectionRule = propertySelectionRule
        return this
    }

    withPropertyValidationRule = (propertyValidationRule: (prop: TProp) => boolean): IValidationRuleBuilder<T, TProp> => {
        this.propertyValidationRule = propertyValidationRule
        return this
    }

    withInnerValidator = (innerValidatorCreationRule: () => IAbstractValidator<TProp>): IValidationRule<T> => {
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

    build = (): IValidationRule<T> => {
        if (!this.propertySelectionRule || (!this.innerValidatorCreationRule && (this.code === undefined || !this.propertyValidationRule || !this.message))) {
            throw new Error("One or more properties have not been set.")
        }

        return new ValidationRule<T, TProp>(
            this.code,
            this.propertySelectionRule,
            this.propertyValidationRule,
            this.message,
            this.innerValidatorCreationRule
        )
    }
}

export default ValidationRuleBuilder