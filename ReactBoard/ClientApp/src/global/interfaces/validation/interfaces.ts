import { ValidationCode } from "../../enums/validation/enums";

export interface IValidationRule<T, TProp> extends IValidationExecutable {}

export interface IValidationExecutable {
    execute: () => IValidationFailure[]
}

export interface IValidationFailure {
    code: ValidationCode
    message?: string
}

export interface IValidationRuleBuilder<T, TProp> {
    withPropertySelectionRule: (propertySelectionRule: (src: T) => TProp) => IValidationRuleBuilder<T, TProp>
    withPropertyValidationRule: (propertyValidationRule: (prop: TProp) => boolean) => IValidationRuleBuilder<T, TProp>
    withInnerValidator: (innerValidatorCreationRule: (prop: TProp) => IAbstractValidator) => IValidationRule<T, TProp>
    withCode: (code: ValidationCode) => IValidationRuleBuilder<T, TProp>
    withMessage: (message: string) => IValidationRuleBuilder<T, TProp>
    build: () => IValidationRule<T, TProp>
}

export interface IAbstractValidator {
    execute: () => IValidationFailure[]
}