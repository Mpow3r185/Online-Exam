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
import { SpinnerComponent } from 'src/app/spinner/spinner.component';
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
  adData: any = [];
  accountStatus: boolean = false;
  testimonialTextarea = new FormControl('', [Validators.required, Validators.minLength(10)]);


// Test Data 
  courses:any=[{
    courseName:'React',
    courseImage:'assets/images/reactcourse.png'
  },
  {
    courseName:'Angular',
    courseImage:'assets/images/angular.png'
  },
  {
    courseName:'Data Base',
    courseImage:'assets/images/dbcourse.jpg'
  }];

  sliderImages: any = [
    {
      imagePath: 'slider-1.jpg'
    },
    {
      imagePath: 'slider-2.jpg'
    },
    {
      imagePath: 'slider-3.jpg'
    }
  ];

    testimonials: any = [
    {
      profileImage: 'slider-1.jpg',
      name: 'Abd Al Hameed Al-Dalgamouni',
      title: 'Admin',
      message: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Incidunt
      illo quo doloribus quas iure quod expedita eius, labore optio nesciunt nostrum tempore
      eveniet recusandae repellat. Provident asperiores accusamus illum? Architecto tempore
      libero quisquam dignissimos, ipsa dicta, rem accusamus quam et eum vero.`
    },

    {
      profileImage: 'slider-2.jpg',
      name: 'Yazeed Bani Ata',
      title: 'Student Failer',
      message: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Incidunt
      illo quo doloribus quas iure quod expedita eius, labore optio nesciunt nostrum tempore
      eveniet recusandae repellat. Provident asperiores accusamus illum? Architecto tempore
      libero quisquam dignissimos, ipsa dicta, rem accusamus quam et eum vero.`
    },

    {
      profileImage: 'slider-3.jpg',
      name: 'Mohammed Hamarsheh',
      title: 'Successfull Arabic 102',
      message: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Incidunt
      illo quo doloribus quas iure quod expedita eius, labore optio nesciunt nostrum tempore
      eveniet recusandae repellat. Provident asperiores accusamus illum? Architecto tempore
      libero quisquam dignissimos, ipsa dicta, rem accusamus quam et eum vero.`
    },

    {
      profileImage: 'slider-1.jpg',
      name: 'Haneen Momaniah',
      title: 'Teacher',
      message: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Incidunt
      illo quo doloribus quas iure quod expedita eius, labore optio nesciunt nostrum tempore
      eveniet recusandae repellat. Provident asperiores accusamus illum? Architecto tempore
      libero quisquam dignissimos, ipsa dicta, rem accusamus quam et eum vero.`
    },

    {
      profileImage: 'slider-2.jpg',
      name: 'Munther Al-Jodah',
      title: 'Blocked User',
      message: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Incidunt
      illo quo doloribus quas iure quod expedita eius, labore optio nesciunt nostrum tempore
      eveniet recusandae repellat. Provident asperiores accusamus illum? Architecto tempore
      libero quisquam dignissimos, ipsa dicta, rem accusamus quam et eum vero.`
    }
];

  constructor(
    public homeService: HomeService,
    public dialog: MatDialog,
    public userService: UserService,
    private router: Router
  ) {
    
  }

  people = [{
    name: {
      firstName: 'Jesse',
      lastName: 'Bowen',
    },
    state: 'Seattle',
  }];

  ngOnInit(): void {
    SpinnerComponent.show();
    this.homeService.getAllTestimonials();
    if (localStorage.getItem('token')) {
    this.userService.getUserById();
    setTimeout(() => this.homeService.getFirstTestimonial(), 1500);

    
    }

    let token = localStorage.getItem('token');

    if (token) {
      this.accountStatus = true;
    }

    setTimeout(() => SpinnerComponent.hide(), 2000);
  }

  currentTestimonialIndex: number = 0;
  animateTestimonial(index: number) {
    document.getElementById(`transporter${this.currentTestimonialIndex}`)!.classList.remove('disable-div');

    document.getElementById('testiSlider')!.style.transform = `translateX(${index * -1110}px)`;
    document.getElementById(`transporter${index}`)!.classList.add('disable-div');
    this.currentTestimonialIndex = index;
  }
}
