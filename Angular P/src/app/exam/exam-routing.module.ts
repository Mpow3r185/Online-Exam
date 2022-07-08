import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExamContentComponent } from './exam-content/exam-content.component';

const routes: Routes = [
  {
    path:'exam/:id',
    component: ExamContentComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExamRoutingModule { }
