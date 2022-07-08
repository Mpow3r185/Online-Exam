import { ClintModule } from './../clint/clint.module';
import { SharedModule } from './../shared/shared/shared.module';
import { ExamContentComponent } from './exam-content/exam-content.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ExamRoutingModule } from './exam-routing.module';
import { MultipleOptionComponent } from './exam-content/question/multiple-option/multiple-option.component';
import { FillOptionComponent } from './exam-content/question/fill-option/fill-option.component';
import { QuestionComponent } from './exam-content/question/question.component';
import { SingleOptionComponent } from './exam-content/question/single-option/single-option.component';


@NgModule({
  declarations: [
    ExamContentComponent,
    QuestionComponent,
    SingleOptionComponent,
    MultipleOptionComponent,
    FillOptionComponent
  ],
  imports: [
    CommonModule,
    ExamRoutingModule,
    SharedModule,
    ClintModule
  ]
})
export class ExamModule { }
