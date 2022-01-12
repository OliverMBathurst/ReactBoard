import { ValidationCode } from "../global/enums/validation/enums"
import ValidationHelper from "../global/helpers/validationHelper"
import { INewPost } from "../global/interfaces/post/interfaces"
import { IValidationExecutable } from "../global/interfaces/validation/interfaces"
import AbstractValidator from "../global/types/validation/abstractValidator"
import ValidationRuleBuilder from "../global/types/validation/validationRuleBuilder"

class PostValidator extends AbstractValidator {
    constructor(post: INewPost) {
        const textRule = new ValidationRuleBuilder(post)
            .withPropertySelectionRule(x => x.text)
            .withPropertyValidationRule(x => ValidationHelper.isTruthy(x))
            .withMessage("Invalid Post text")
            .withCode(ValidationCode.PostText)
            .build()

        const rules: IValidationExecutable[] = [textRule]

        super(rules)
    }
}

export default PostValidator