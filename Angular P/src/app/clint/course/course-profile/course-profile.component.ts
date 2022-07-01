import { HomeService } from 'src/app/service/home.service';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';

@Component({
  selector: 'app-course-profile',
  templateUrl: './course-profile.component.html',
  styleUrls: ['./course-profile.component.css']
})
export class CourseProfileComponent implements OnInit {

  private routeSub!: Subscription;

  constructor(
    public homeService: HomeService,
    private route: ActivatedRoute,
    public router: Router) { 

  }

  ngOnInit(): void {
    SpinnerComponent.show();

    // Get Course And Exams For That Course
    this.routeSub = this.route.params.subscribe(async params => {   
      
         
      let body = {
        cid: Number(params['id'])
      };     
      await this.homeService.searchCourse(body);            // Get Course
      await this.homeService.getExamsByCourseId(body.cid);  // Get Exams
    });

    SpinnerComponent.hide();
  }

  // Unsubscribe to prevent memory leaks
  ngOnDestroy() {
    this.routeSub.unsubscribe();
  }

}
