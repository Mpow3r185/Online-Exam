import { SpinnerComponent } from './../../spinner/spinner.component';
import { HomeService } from 'src/app/service/home.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-exam',
  templateUrl: './exam.component.html',
  styleUrls: ['./exam.component.css']
})
export class ExamComponent implements OnInit {
  
  filterIsOpened: any;
  filterSection: any;
  coursesSection: any;

  filterByDateIsOpened: any;
  filterByDate: any;
  filterByDateDetails: any;

  filterByExameNameIsOpened: any;
  filterByExamName: any;
  filterByExamNameDetails: any;

  filterByCourseNameIsOpened: any;
  filterByCourseName: any;
  filterByCourseNameDetails: any;

  filterByExameLevelIsOpened: any;
  filterByExamLevel: any;
  filterByExamLevelDetails: any;
  
  exams: any;

  constructor(public home: HomeService) { }

  ngOnInit(): void {
    SpinnerComponent.show();

    this.home.getExams();
    
    this.filterIsOpened = true;
    this.filterSection = document.getElementById('filterSection') as HTMLInputElement;
    this.coursesSection = document.getElementById('coursesSection') as HTMLInputElement;

    this.filterByDateIsOpened = false;
    this.filterByDate = document.getElementById('filterByDate') as HTMLInputElement;
    this.filterByDateDetails = document.getElementById('filterByDateDetails') as HTMLInputElement;

    this.filterByExameNameIsOpened = false;
    this.filterByExamName = document.getElementById('filterByExamName') as HTMLInputElement;
    this.filterByExamNameDetails = document.getElementById('filterByExamNameDetails') as HTMLInputElement;

    this.filterByCourseNameIsOpened = false;
    this.filterByCourseName = document.getElementById('filterByCourseName') as HTMLInputElement;
    this.filterByCourseNameDetails = document.getElementById('filterByCourseNameDetails') as HTMLInputElement;

    this.filterByExameLevelIsOpened = false;
    this.filterByExamLevel = document.getElementById('filterByExamLevel') as HTMLInputElement;
    this.filterByExamLevelDetails = document.getElementById('filterByExamLevelDetails') as HTMLInputElement;

    SpinnerComponent.hide();
  }

  handleFilterFunctionality(): void {    
    this.filterIsOpened = !this.filterIsOpened;
    
    if (this.filterIsOpened) {
        this.filterSection?.classList.remove('close-filter');
        this.coursesSection?.classList.replace('col-12', 'col-9');
    } else {
        this.filterSection?.classList.add('close-filter')
        this.coursesSection?.classList.replace('col-9', 'col-12');
    }
  }

  handleFilterByDate(): void { 
    this.filterByDateIsOpened = !this.filterByDateIsOpened;

    if (this.filterByDateIsOpened) {
        document.getElementById('arrow-1')!.classList.add('rotate-180-deg')
        this.filterByDateDetails.style.display = 'block';
    } else {
        document.getElementById('arrow-1')!.classList.remove('rotate-180-deg')
        this.filterByDateDetails.style.display = 'none';
    }
  }

  handleFilterByCourseName(): void {
    this.filterByCourseNameIsOpened = !this.filterByCourseNameIsOpened;

    if (this.filterByCourseNameIsOpened) {
        document.getElementById('arrow-2')!.classList.add('rotate-180-deg')
        this.filterByCourseNameDetails!.style.display = 'block';
    } else {
        document.getElementById('arrow-2')!.classList.remove('rotate-180-deg')
        this.filterByCourseNameDetails!.style.display = 'none';
    }
  }

  handleFilterByExamName(): void {
    this.filterByExameNameIsOpened = !this.filterByExameNameIsOpened;

    if (this.filterByExameNameIsOpened) {
        document.getElementById('arrow-3')!.classList.add('rotate-180-deg')
        this.filterByExamNameDetails.style.display = 'block';
    } else {
        document.getElementById('arrow-3')!.classList.remove('rotate-180-deg')
        this.filterByExamNameDetails!.style.display = 'none';
    }
  }

  handleFilterByExamLevel(): void {
    this.filterByExameLevelIsOpened = !this.filterByExameLevelIsOpened;

    if (this.filterByExameLevelIsOpened) {
        document.getElementById('arrow-5')!.classList.add('rotate-180-deg')
        this.filterByExamLevelDetails!.style.display = 'block';
    } else {
        document.getElementById('arrow-5')!.classList.remove('rotate-180-deg')
        this.filterByExamLevelDetails!.style.display = 'none';
    }
  }

  async examSearch() {
    SpinnerComponent.show();

    const startDate: any = document.getElementById('startDate');
    const endDate: any = document.getElementById('endDate');
    const courseName: any = document.getElementById('courseName');
    const examName: any = document.getElementById('examName');
    const examLevel: any = document.querySelectorAll('.form-check-input');

    const startDateValue = (startDate.value === '') ? null : startDate.value;
    const endDateValue = (endDate.value === '') ? null : endDate.value;
    const courseNameValue = (courseName.value === '') ? null : courseName.value.toLowerCase();    
    const examNameValue = (examName.value === '') ? null : examName.value.toLowerCase();
    const beginnerExamLevelValue = (!examLevel[0].checked) ? null : 'Beginner';
    const intermediateExamLevelValue = (!examLevel[1].checked) ? null : 'Intermediate';
    const advancedExamLevelValue = (!examLevel[2].checked) ? null : 'Advanced';
    const expertExamLevelValue = (!examLevel[3].checked) ? null : 'Expert';    
    
    const searchBody = {
      stDate: startDateValue,
      enDate: endDateValue,
      courseName: courseNameValue,
      exTitle: examNameValue,
      ExLevelBeginner: beginnerExamLevelValue,
      ExLevelIntermediate: intermediateExamLevelValue,
      ExLevelAdvanced: advancedExamLevelValue,
      ExLevelExpert: expertExamLevelValue
    }    
    await this.home.searchExam(searchBody);

    SpinnerComponent.hide();
  }

  async examClear() {
    SpinnerComponent.show();

    const emptyBody = {};
    await this.home.searchExam(emptyBody);
    
    SpinnerComponent.hide();
  }
}
