import { CorrectAnswer } from '../Data/CorrectAnswer';
import { QuestionOption } from '../Data/QuestionOption';
import { QuestionExamDTO } from './question-exam';


export class QuestionsDetailsDTO {
    public questionsExamsDTO: QuestionExamDTO[] = [];
    public questionsOptions: QuestionOption[] = [];
    public correctAnswers: CorrectAnswer[] = [];
}