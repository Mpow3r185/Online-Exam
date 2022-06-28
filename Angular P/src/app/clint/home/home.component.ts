import { FormControl, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import SwiperCore, {
  Navigation,
  Autoplay,
  EffectCoverflow,
  Pagination,
} from 'swiper';
import { HomeService } from 'src/app/service/home.service';
import { MatDialog } from '@angular/material/dialog';
import { UserService } from 'src/app/service/user.service';
import { Router } from '@angular/router';


SwiperCore.use([Navigation]);
SwiperCore.use([Autoplay]);
SwiperCore.use([EffectCoverflow, Pagination]);

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})

export class HomeComponent implements OnInit {
  loopStatues: boolean = false;
  search!: string;
  searchExams: any = [];
  searchCourses: any = [];
  accountStatus: boolean = false;
  testimonialTextarea = new FormControl('', [Validators.required, Validators.minLength(10)]);

  constructor(
    public homeService: HomeService,
    public dialog: MatDialog,
    public userService: UserService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.homeService.getCourses();
    this.homeService.getExams();
    this.homeService.getTestimonials();
  }
  saveTesti(){
    this.homeService.createTestimonial(this.testimonialTextarea.value);
  }

  currentTestimonialIndex: number = 0;
  animateTestimonial(index: number) {
    document.getElementById(`transporter${this.currentTestimonialIndex}`)!.classList.remove('disable-div');
    let sliderContainer = document.getElementById('testiSlider');

    sliderContainer!.style.transform = `translateX(${index * -sliderContainer!.clientWidth}px)`;
    document.getElementById(`transporter${index}`)!.classList.add('disable-div');
    this.currentTestimonialIndex = index;
  }

  homeSearch() {
    this.searchCourses = [];
    this.searchExams = [];
    const searchContainer = document.getElementById('searchContainer');

    if (this.search) {
      searchContainer!.style.display = 'block';
      const coursesContainer = document.getElementById('coursesContainer');
      const examsContainer = document.getElementById('examsContainer');
      
      for (let obj of this.homeService.courses) {
        let courseName: string = obj.courseName.toLowerCase();
        if (courseName.includes(this.search.toLowerCase())) {
          this.searchCourses.push(obj);
        } 
      }
      
      for (let obj of this.homeService.exams) {
        let title: string = obj.title.toLowerCase();
        if (title.includes(this.search.toLowerCase())) {
          this.searchExams.push(obj);
        }
      }
            
      if (this.searchCourses.length < 1) {
        coursesContainer!.style.display = 'none';
      } else {
        coursesContainer!.style.display = 'flex';
      }

      if (this.searchExams.length < 1) {
        examsContainer!.style.display = 'none';
      } else {
        examsContainer!.style.display = 'flex';
      }
    }
    else {
      searchContainer!.style.display = 'none';
    }
  }
}
