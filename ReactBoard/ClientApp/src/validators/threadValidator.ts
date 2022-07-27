import { PostValidator } from "."
import { INewPost } from "../global/interfaces/post"
import { INewThread } from "../global/interfaces/thread"
import { AbstractValidator, ValidationRuleBuilder } from "../global/types/validation"

class ThreadValidator extends AbstractValidator<INewThread> {
    constructor() {
        const postRule = new ValidationRuleBuilder<INewThread, INewPost>()
            .withPropertySelectionRule(x => x.post)
            .withInnerValidator(() => new PostValidator())

        super([postRule])
    }
}

export default ThreadValidator