import { ValidationCode } from "../global/enums"
import { ValidationHelper } from "../global/helpers"
import { INewCategory } from "../global/interfaces/category"
import { IValidationExecutable } from "../global/interfaces/validation"
import { AbstractValidator, ValidationRuleBuilder } from "../global/types/validation"

class CategoryValidator extends AbstractValidator<INewCategory> {
    constructor() {
        const nameRule = new ValidationRuleBuilder<INewCategory, string>()
            .withPropertySelectionRule(x => x.name)
            .withPropertyValidationRule(x => ValidationHelper.isTruthy(x))
            .withMessage("Invalid category name")
            .withCode(ValidationCode.CategoryName)
            .build()

        const rules: IValidationExecutable<INewCategory>[] = [nameRule]

        super(rules)
    }
}

export default CategoryValidator