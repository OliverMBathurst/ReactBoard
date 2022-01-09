export interface IValidationRule<T, TProp> extends IValidationExecutable {}

export interface IValidationExecutable {
    execute: () => IValidationResult
}

export interface IValidationResult {
    success: boolean
    message?: string
}

export interface IValidationRuleBuilder<T, TProp> {
    withPropertySelectionRule: (propertySelectionRule: (src: T) => TProp) => IValidationRuleBuilder<T, TProp>
    withPropertyValidationRule: (propertyValidationRule: (prop: TProp) => boolean) => IValidationRuleBuilder<T, TProp>
    withMessage: (message: string) => IValidationRuleBuilder<T, TProp>
    build: () => IValidationRule<T, TProp>
}