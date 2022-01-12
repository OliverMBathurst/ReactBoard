import { INewPost } from "../global/interfaces/post/interfaces"
import { INewThread } from "../global/interfaces/thread/interfaces"
import { IValidationExecutable } from "../global/interfaces/validation/interfaces"
import AbstractValidator from "../global/types/validation/abstractValidator"
import ValidationRuleBuilder from "../global/types/validation/validationRuleBuilder"
import PostValidator from "./postValidator"

class ThreadValidator extends AbstractValidator {
    constructor(thread: INewThread) {
        const postRule = new ValidationRuleBuilder<INewThread, INewPost>(thread)
            .withPropertySelectionRule(x => x.post)
            .withInnerValidator(x => new PostValidator(x))

        const rules: IValidationExecutable[] = [postRule]

        super(rules)
    }
}

export default ThreadValidator