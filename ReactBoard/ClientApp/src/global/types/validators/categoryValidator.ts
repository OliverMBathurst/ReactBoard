import { INewCategory } from "../../interfaces/category/interfaces";
import AbstractValidator from "../validation/abstractValidator";
import { isTruthy } from "../validation/checks";
import { IValidationExecutable } from "../validation/interfaces";
import ValidationRuleBuilder from "../validation/validationRuleBuilder";

class CategoryValidator extends AbstractValidator {
    constructor(src: INewCategory) {
        const rule = new ValidationRuleBuilder<INewCategory, string>(src)
            .withPropertySelectionRule(x => x.name)
            .withPropertyValidationRule(x => isTruthy(x))
            .withMessage("Invalid category name")
            .build()

        const validationRules: IValidationExecutable[] = [
            rule
        ]

        super(validationRules)
    }
}

export default CategoryValidator