import { ValidationCode } from "../../enums";

export interface IValidationRule<T> {
    execute: (source: T) => IValidationFailure[]
}

export interface IValidationFailure {
    code: ValidationCode
    message?: string
}

export interface IValidationRuleBuilder<T, TProp> {
    withPropertySelectionRule: (propertySelectionRule: (src: T) => TProp) => IValidationRuleBuilder<T, TProp>
    withPropertyValidationRule: (propertyValidationRule: (prop: TProp) => boolean) => IValidationRuleBuilder<T, TProp>
    withInnerValidator: (innerValidatorCreationRule: () => IAbstractValidator<TProp>) => IValidationRule<T>
    withCode: (code: ValidationCode) => IValidationRuleBuilder<T, TProp>
    withMessage: (message: string) => IValidationRuleBuilder<T, TProp>
    build: () => IValidationRule<T>
}

export interface IAbstractValidator<T> {
    execute: (source: T) => IValidationFailure[]
}