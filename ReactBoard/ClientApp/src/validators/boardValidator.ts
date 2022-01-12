import { ValidationCode } from "../global/enums/validation/enums"
import { INewBoard } from "../global/interfaces/board/interfaces"
import { IValidationExecutable } from "../global/interfaces/validation/interfaces"
import AbstractValidator from "../global/types/validation/abstractValidator"
import ValidationRuleBuilder from "../global/types/validation/validationRuleBuilder"
import ValidationHelper from "../global/helpers/validationHelper"

class BoardValidator extends AbstractValidator {
    constructor(board: INewBoard) {
        const nameRule = new ValidationRuleBuilder(board)
            .withPropertySelectionRule(x => x.name)
            .withPropertyValidationRule(x => ValidationHelper.isTruthy(x))
            .withMessage("Board name not specified")
            .withCode(ValidationCode.BoardName)
            .build()

        const descriptionRule = new ValidationRuleBuilder(board)
            .withPropertySelectionRule(x => x.description)
            .withPropertyValidationRule(x => ValidationHelper.isTruthy(x))
            .withMessage("Board description is invalid")
            .withCode(ValidationCode.BoardDescription)
            .build()

        const boardUrlRule = new ValidationRuleBuilder(board)
            .withPropertySelectionRule(x => x.urlName)
            .withPropertyValidationRule(x => ValidationHelper.isTruthy(x))
            .withMessage("Board URL Name is invalid")
            .withCode(ValidationCode.BoardUrlName)
            .build()

        const categoryRule = new ValidationRuleBuilder(board)
            .withPropertySelectionRule(x => x.category)
            .withPropertyValidationRule(x => ValidationHelper.isTruthy(x))
            .withMessage("Invalid category")
            .withCode(ValidationCode.BoardCategory)
            .build()

        const maxThreadsRule = new ValidationRuleBuilder<INewBoard, number>(board)
            .withPropertySelectionRule(x => x.maxThreads)
            .withPropertyValidationRule(x => x > 0)
            .withMessage("Max number of threads must be greater than zero")
            .withCode(ValidationCode.BoardMaxThreads)
            .build()

        const rules: IValidationExecutable[] = [
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