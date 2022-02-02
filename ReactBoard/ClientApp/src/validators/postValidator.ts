import { ValidationCode } from "../global/enums"
import { ValidationHelper } from "../global/helpers"
import { INewPost } from "../global/interfaces/post"
import { IValidationExecutable } from "../global/interfaces/validation"
import { AbstractValidator, ValidationRuleBuilder } from "../global/types/validation"

class PostValidator extends AbstractValidator<INewPost> {
    constructor() {
        const textRule = new ValidationRuleBuilder<INewPost, string>()
            .withPropertySelectionRule(x => x.text)
            .withPropertyValidationRule(x => ValidationHelper.isTruthy(x))
            .withMessage("Invalid Post text")
            .withCode(ValidationCode.PostText)
            .build()

        const rules: IValidationExecutable<INewPost>[] = [textRule]

        super(rules)
    }
}

export default PostValidator