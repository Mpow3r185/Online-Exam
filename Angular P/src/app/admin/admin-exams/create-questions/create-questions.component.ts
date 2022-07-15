import { SpinnerComponent } from './../../../spinner/spinner.component';
import { FormControl, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AdminService } from 'src/app/service/admin.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-create-questions',
  templateUrl: './create-questions.component.html',
  styleUrls: ['./create-questions.component.css']
})
export class CreateQuestionsComponent implements OnInit {

  private routeSub!: Subscription;
  private questions: Question[] = [];
  private exid?: number;

  public selectedType: string = 'Single';
  public Qcounter: number = 0;
  public Ocounter: number = 0;
  
  public typeControl: FormControl = new FormControl('Single', Validators.required);
  public statusControl: FormControl = new FormControl('DISABLE', Validators.required);
  public scoreControl: FormControl = new FormControl(1, [Validators.min(1), Validators.required]);

  constructor(
    public adminService: AdminService,
    private toastr: ToastrService,
    private route: ActivatedRoute,
    private router: Router
  ) { 
    this.routeSub = this.route.params.subscribe(async params => {
      await this.adminService.getExamById(Number(params['id']));
      this.exid = Number(params['id']);
    });    
   }

  ngOnInit(): void {
  }

  addOption(n: number) {
    // If Text Area is Empty
    if ((<HTMLInputElement>document.getElementById(`optionTextarea-${this.Qcounter}`)).value == '') {
      this.toastr.error('Option Text Can\'t Be Empty');
      return;
    }

    const parentContainer = document.getElementById(`div-par`);    

    // Option Label
    const optionLabel = document.createElement('label');
    optionLabel.classList.add('pl-3');
    optionLabel.classList.add('mb-0');
    optionLabel.setAttribute('for', `q${this.Qcounter}-op${this.Ocounter}`);
    optionLabel.innerText = (<HTMLInputElement>document.getElementById(`optionTextarea-${this.Qcounter}`)).value;
    optionLabel.style.wordBreak = "break-all";

    // Option Type
    let option: any;
    option = document.createElement('input');
    option.setAttribute('name', `q${this.Qcounter }`);
    option.setAttribute('id', `q${this.Qcounter}-op${this.Ocounter}`);
    option.setAttribute('value', (<HTMLInputElement>document.getElementById(`optionTextarea-${this.Qcounter}`)).value);
    option.classList.add('d-block');
    
    if (this.selectedType == 'Single') {
      option.setAttribute('type', 'radio');
    } else if (this.selectedType == 'Multiple') {
      option.setAttribute('type', 'checkbox');
    }

    const rowDiv = document.createElement('div');
    rowDiv.classList.add('row');
    rowDiv.appendChild(option);
    rowDiv.appendChild(optionLabel);

    // Option Container
    const optionContainer = document.createElement('div');
    optionContainer.classList.add('col-10');
    optionContainer.setAttribute('name', 'optionConta');
    optionContainer.appendChild(rowDiv);

    parentContainer?.insertBefore(optionContainer, document.getElementById(`textarea-cont${this.Qcounter}${this.Ocounter}`));

    (<HTMLInputElement>document.getElementById(`optionTextarea-${this.Qcounter}`)).value = '';
        
    this.Ocounter++;
  }

  addQuestion() {
    // Check If Question Text is Empty
    if (((<HTMLInputElement>document.getElementById('questionTextarea')).value) == '') {
      this.toastr.error('Question Text Can\'t Be Empty');
      return;
    }

    // Get Question Type
    let type: string = this.selectedType;;
    /*switch (this.selectedType) {
      case 'Single':
        type = questionType.Single;
        break;
      
      case 'Multiple':
        type = questionType.Multiple;
        break;

      case 'Fill':
        type = questionType.Fill;
        break;
    } */ 

    const question: Question = new Question((<HTMLInputElement>document.getElementById('questionTextarea')).value, type);
    question.score = this.scoreControl.value;
    question.status = this.statusControl.value;
    
    const options = document.getElementsByName(`q${this.Qcounter}`);
    if (options.length == 0 && (type == 'Fill' && (<HTMLInputElement>document.getElementById(`optionTextarea-${this.Qcounter}`)).value == '')) {
      this.toastr.error('There Is No Options');
      return;
    }
    
    if (type == 'Single' || type == 'Multiple') {
      
      let thereIsCorrectOption: boolean = false;
      options.forEach((element) => {
        if ((<HTMLInputElement>element).checked) { thereIsCorrectOption = true; }
        
        const isCorrectOption = ((<HTMLInputElement>element).checked) ? true : false;
        const option: ChooseOption = new ChooseOption((<HTMLInputElement>element).value, isCorrectOption);
  
        question.options?.push(option);
      });
      
      // Check If There Correct Option
      if (!thereIsCorrectOption) {
        this.toastr.error('There Is No Correct Option');
        return;
      }
    }
    
    else {
      question.fillOption = new FillOption((<HTMLInputElement>document.getElementById(`optionTextarea-${this.Qcounter}`)).value);
    }
    
    this.questions.push(question);
    
    this.toastr.success('The Question Is Saved');
    this.toastr.warning('The question saved on your session, press Save Questions to save them in the server');

    this.submitQuestion();
  }

  submitQuestion() {
    const questionsNavigatocrContainter = document.getElementsByClassName('questions-navigator-containter')[0];

    const questionNaviContainer = document.createElement('div');
    questionNaviContainer.classList.add('question-container');
    questionNaviContainer.classList.add('border-1px');
    questionNaviContainer.classList.add('m-1');
    questionNaviContainer.classList.add('p-2');
    questionNaviContainer.id = `q${this.Qcounter}`;
    
    
    const questionNumber = document.createElement('p');
    questionNumber.classList.add('text-center');
    questionNumber.classList.add('font-weight-bold');
    questionNumber.classList.add('m-0');
    questionNumber.classList.add('font-family-tahoma');
    questionNumber.innerText = `Q${this.Qcounter+1}`;

    questionNaviContainer.appendChild(questionNumber);
    questionsNavigatocrContainter.appendChild(questionNaviContainer);


    this.displaySubmitedQuestion();
  }

  displaySubmitedQuestion() {
    const submitedQuestionContainer = document.getElementById('submitedQuestionContainer');

    // Question Container
    const questionContainer = document.createElement('div');
    questionContainer.setAttribute('id', `q${ this.Qcounter }Cont`);
    questionContainer.style.height = 'fit-content';
    questionContainer.classList.add('col-12');
    questionContainer.classList.add('border-3px');
    questionContainer.classList.add('mb-5');
    questionContainer.classList.add('mt-sm-5');
    questionContainer.classList.add('mt-md-5');
    questionContainer.classList.add('mt-lg-0');
    questionContainer.classList.add('questionCard');

    const questionNaviContainer = document.getElementById(`q${this.Qcounter}`);
    questionNaviContainer!.onclick = () => {
      questionContainer.scrollIntoView({behavior: "smooth"});
    }

    // Row Container 1
    const rowContainer1 = document.createElement('div');
    rowContainer1.classList.add('row');

    // Questions Text Container
    const questionTextContainer = document.createElement('div');
    questionTextContainer.classList.add('container');
    questionTextContainer.classList.add('m-3');

    // Row Container 2
    const rowContainer2 = document.createElement('div');
    rowContainer2.classList.add('justify-content-start');
    rowContainer2.classList.add('row');

    // Question Number Text
    const questionNumberText = document.createElement('div');

    const questionNumberParaghraph = document.createElement('p');
    questionNumberParaghraph.classList.add('font-family-tahoma');
    questionNumberParaghraph.classList.add('font-weight-bold');
    questionNumberParaghraph.innerText = `Q${ this.Qcounter+1 }:`;

    questionNumberText.appendChild(questionNumberParaghraph);

    // Question Content Text
    const questionContentText = document.createElement('div');
    questionContentText.classList.add('col-10');

    // Question Content Paraghraph
    const questionContentParaghraph = document.createElement('p');
    questionContentParaghraph.innerText = ((<HTMLInputElement>document.getElementById('questionTextarea')).value);

    // Question Score Text
    const questionScoreText = document.createElement('div');
    questionScoreText.classList.add('col-1');
    questionScoreText.classList.add('justify-content-center');

    // Question Score Paraghraph
    const questionScoreParaghraph = document.createElement('p');
    questionScoreParaghraph.innerText = this.scoreControl.value;

    questionContentText.appendChild(questionContentParaghraph);
    questionScoreText.appendChild(questionScoreParaghraph);
    rowContainer2.appendChild(questionNumberText);
    rowContainer2.appendChild(questionContentText);
    rowContainer2.appendChild(questionScoreText); 
    questionTextContainer.appendChild(rowContainer2);
    
    const hr = document.createElement('hr');
    hr.classList.add('mt-0');

    questionTextContainer.appendChild(hr);

    // Option Row Container
    const rowContainer3 = document.createElement('div');
    rowContainer3.classList.add('row');

    const question = this.questions[this.questions.length - 1];
    if (question.type == 'Fill') {
      const optionContainer = document.createElement('div');
      optionContainer.classList.add('col-12');

      const label = document.createElement('label');
      label.setAttribute('for', `q${ this.Qcounter }-f`);
      label.innerText = 'The correct answer is: ';

      const textarea = document.createElement('textarea');
      textarea.classList.add('form-control');
      textarea.setAttribute('id', `q${ this.Qcounter }-f`);
      textarea.name = `q${ this.Qcounter }`;
      textarea.rows = 3;
      textarea.innerText = (<HTMLInputElement>document.getElementById(`optionTextarea-${ this.Qcounter }`)).value;
      textarea.disabled = true;

      optionContainer.appendChild(label);
      optionContainer.appendChild(textarea);
      rowContainer3.appendChild(optionContainer);
    }
    else {
      const inputType = (question.type == 'Single') ? 'radio' : 'checkbox';
      for (let i=0; i<question.options.length; i++) {

        const optionContainer = document.createElement('div');
        optionContainer.classList.add('col-12');

        const input = document.createElement('input');
        input.id = `q${ this.Qcounter }-op${ i }`;
        input.name = `q${ this.Qcounter }`;
        input.type = inputType;
        input.disabled = true;

        if (question.options[i].isCorrectOption) {
          input.checked = true;
        }

        const label = document.createElement('label');
        label.classList.add('px-2');
        label.setAttribute('for', `q${ this.Qcounter }-op${ i }`);
        label.innerText = question.options[i].optionContent;

        optionContainer.appendChild(input);
        optionContainer.appendChild(label);
        rowContainer3.appendChild(optionContainer);
      }
    }
    
    questionTextContainer.appendChild(rowContainer3);
    rowContainer1.appendChild(questionTextContainer);
    questionContainer.appendChild(rowContainer1);
    submitedQuestionContainer?.appendChild(questionContainer);

      this.clearQuestionForm();

    this.Qcounter++;
    this.Ocounter = 0;
  }

  async saveAllQuestions() {
    SpinnerComponent.show();

    this.adminService.CreateExamQuestions(this.questions, this.exid);
  
    await delay(10000);
    this.router.navigate(['/admin/exams']);
    SpinnerComponent.hide();
  }

  clearQuestionForm() {
    (<HTMLInputElement>document.getElementById('questionTextarea')).value = '';
    (<HTMLInputElement>document.getElementById(`optionTextarea-${this.Qcounter}`)).value = '';

    const divPar = document.getElementById('div-par');
    if (divPar != null) {
      for (let i = 0; i < divPar.children.length; i++) {
        if (divPar.children[i].getAttribute('name') == 'optionConta') {
          divPar.removeChild(divPar.children[i--]);
        }
      }
    }
  }

}

enum questionType {
  Single,
  Multiple,
  Fill
}

enum status {
  ENABLE,
  DISABLE
}

class Option {
  public optionContent: string = '';
  
  constructor(optionContent: string) {
    this.optionContent = optionContent;
  }
}

class ChooseOption extends Option  {

  public isCorrectOption: boolean;

  constructor (optionContent: string, isCorrectOption=false) {
    super(optionContent);
    this.isCorrectOption = isCorrectOption;
  }
}

class FillOption extends Option {

  constructor(optionContent: string) {
    super(optionContent);
  }
  
}

export class Question {
  public text: string = 'Unavailable';
  public type: string = 'Single';
  public status: string = 'DISBALE';
  public score: number = 1;
  public options: ChooseOption[];
  public fillOption?: FillOption;

  constructor(text: string, type: string = 'Single') {
    this.text = text;
    this.type = type;
    this.options = [];
    this.fillOption;
  }
}


function delay(ms: number) {
  return new Promise( resolve => setTimeout(resolve, ms) );
}