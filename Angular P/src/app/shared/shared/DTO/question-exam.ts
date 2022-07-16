import { CorrectAnswer } from './../Data/CorrectAnswer';
import { QuestionOption } from "../Data/QuestionOption";

export class QuestionExamDTO {
    public examId?: number;
    public courseId?: number;
    public courseName?: string;
    public title?: string;
    public questionId?: number;
    public questionContent?: string;
    public type?: string;
    public score?: number;
    public status?: string;
    public options: QuestionOption[] = [];
    public correctAnswers: CorrectAnswer[] = [];
}