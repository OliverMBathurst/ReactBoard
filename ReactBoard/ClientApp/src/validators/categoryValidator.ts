import { ValidationCode } from "../global/enums/validation/enums"
import ValidationHelper from "../global/helpers/validationHelper"
import { INewCategory } from "../global/interfaces/category/interfaces"
import { IValidationExecutable } from "../global/interfaces/validation/interfaces"
import AbstractValidator from "../global/types/validation/abstractValidator"
import ValidationRuleBuilder from "../global/types/validation/validationRuleBuilder"

class CategoryValidator extends AbstractValidator {
    constructor(category: INewCategory) {
        const nameRule = new ValidationRuleBuilder(category)
            .withPropertySelectionRule(x => x.name)
            .withPropertyValidationRule(x => ValidationHelper.isTruthy(x))
            .withMessage("Invalid category name")
            .withCode(ValidationCode.CategoryName)
            .build()

        const rules: IValidationExecutable[] = [nameRule]

        super(rules)
    }
}

export default CategoryValidator