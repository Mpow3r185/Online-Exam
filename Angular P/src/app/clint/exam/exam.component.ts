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


  /* Data For Test Purpose */
  exams = [
    {
      examName: 'Python 111',
      courseName: 'Python',
      dsecription: 'Python basics (print, list, generators, selection statements, for, while and functions',
      cost: 0,
      examImage: 'slider-2.jpg',
      numberOfUsersRegistered: 10,
      startDate: '20/6/2022',
      endDate: '20/6/2022',
      startHour: '13:30',
      endHour: '14:30',
      duration: 60,
      successMark: 50,
      examLevel: 'Beginner'
    },

    {
      examName: 'Python 210',
      courseName: 'Python',
      dsecription: 'Python object oriented programming (OOP) (functions, classes, inheritence, polymorphism and aggregation',
      cost: 100,
      examImage: 'slider-2.jpg',
      numberOfUsersRegistered: 484561,
      startDate: '20/6/2022',
      endDate: '20/6/2022',
      startHour: '13:00',
      endHour: '14:50',
      duration: 170,
      successMark: 80,
      examLevel: 'Intermediate'
    }
  ];


  constructor() { }

  ngOnInit(): void {
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
  }

  handleFilterFunctionality(): void {
    this.filterIsOpened = !this.filterIsOpened;
    console.log(this.filterSection);
    
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

}
