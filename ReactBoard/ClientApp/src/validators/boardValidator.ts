import { CategoryValidator } from "."
import { ValidationCode } from "../global/enums"
import { ValidationHelper } from "../global/helpers"
import { INewBoard } from "../global/interfaces/board/interfaces"
import { ICategory } from "../global/interfaces/category/interfaces"
import { IValidationExecutable } from "../global/interfaces/validation"
import { AbstractValidator, ValidationRuleBuilder } from "../global/types/validation"

class BoardValidator extends AbstractValidator<INewBoard> {
    constructor() {
        const nameRule = new ValidationRuleBuilder<INewBoard, string>()
            .withPropertySelectionRule(x => x.name)
            .withPropertyValidationRule(x => ValidationHelper.isTruthy(x))
            .withMessage("Board name not specified")
            .withCode(ValidationCode.BoardName)
            .build()

        const descriptionRule = new ValidationRuleBuilder<INewBoard, string>()
            .withPropertySelectionRule(x => x.description)
            .withPropertyValidationRule(x => ValidationHelper.isTruthy(x))
            .withMessage("Board description is invalid")
            .withCode(ValidationCode.BoardDescription)
            .build()

        const boardUrlRule = new ValidationRuleBuilder<INewBoard, string>()
            .withPropertySelectionRule(x => x.urlName)
            .withPropertyValidationRule(x => ValidationHelper.isTruthy(x))
            .withMessage("Board URL Name is invalid")
            .withCode(ValidationCode.BoardUrlName)
            .build()

        const categoryRule = new ValidationRuleBuilder<INewBoard, ICategory>()
            .withPropertySelectionRule(x => x.category)
            .withInnerValidator(() => new CategoryValidator())

        const maxThreadsRule = new ValidationRuleBuilder<INewBoard, number>()
            .withPropertySelectionRule(x => x.maxThreads)
            .withPropertyValidationRule(x => x > 0)
            .withMessage("Max number of threads must be greater than zero")
            .withCode(ValidationCode.BoardMaxThreads)
            .build()

        const rules: IValidationExecutable<INewBoard>[] = [
            nameRule,
            descriptionRule,
            boardUrlRule,
            categoryRule,
            maxThreadsRule
        ]

        super(rules)
    }
}

export default BoardValidator