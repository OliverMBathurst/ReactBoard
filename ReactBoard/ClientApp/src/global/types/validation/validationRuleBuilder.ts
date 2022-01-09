import { IValidationRule, IValidationRuleBuilder } from "./interfaces"
import ValidationRule from "./validationRule"

class ValidationRuleBuilder<T, TProp> implements IValidationRuleBuilder<T, TProp> {
    source: T
    propertySelectionRule: ((src: T) => TProp) | undefined
    validationRule: ((prop: TProp) => boolean) | undefined
    message: string | undefined

    constructor(source: T) {
        this.source = source
    }

    withPropertySelectionRule = (propertySelectionRule: (src: T) => TProp): IValidationRuleBuilder<T, TProp> => {
        this.propertySelectionRule = propertySelectionRule
        return this
    }

    withPropertyValidationRule = (propertyValidationRule: (prop: TProp) => boolean): IValidationRuleBuilder<T, TProp> => {
        this.validationRule = propertyValidationRule
        return this
    }

    withMessage = (message: string): IValidationRuleBuilder<T, TProp> => {
        this.message = message
        return this
    }


    build = (): IValidationRule<T, TProp> => {
        if (this.propertySelectionRule === undefined
            || this.validationRule === undefined
            || this.message === undefined) {
            throw new Error("One or more rules have not been set")
        } else {
            return new ValidationRule<T, TProp>(
                this.source,
                this.propertySelectionRule,
                this.validationRule,
                this.message
            )
        }
    }
}

export default ValidationRuleBuilder