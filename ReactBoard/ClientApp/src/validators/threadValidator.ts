import { PostValidator } from "."
import { INewPost } from "../global/interfaces/post"
import { INewThread } from "../global/interfaces/thread"
import { IValidationExecutable } from "../global/interfaces/validation"
import { AbstractValidator, ValidationRuleBuilder } from "../global/types/validation"

class ThreadValidator extends AbstractValidator<INewThread> {
    constructor() {
        const postRule = new ValidationRuleBuilder<INewThread, INewPost>()
            .withPropertySelectionRule(x => x.post)
            .withInnerValidator(() => new PostValidator())

        const rules: IValidationExecutable<INewThread>[] = [postRule]

        super(rules)
    }
}

export default ThreadValidator