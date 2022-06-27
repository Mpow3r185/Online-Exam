import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { HomeService } from 'src/app/service/home.service';

@Component({
  selector: 'app-exam-profile',
  templateUrl: './exam-profile.component.html',
  styleUrls: ['./exam-profile.component.css']
})
export class ExamProfileComponent implements OnInit {

  isExpanded: boolean = true;
  private routeSub!: Subscription;

  constructor(public homeService: HomeService, private route: ActivatedRoute) {}

  ngOnInit() {
    this.routeSub = this.route.params.subscribe(async params => {
      await this.homeService.getExamById(Number(params['id']));
    });
  }

  expandExamInformation(): void {
    this.isExpanded = !this.isExpanded;
    if (this.isExpanded) {
        document.getElementById('expandInf')!.style.transform = 'rotate(0deg)';
        document.getElementById('examInfContainer')!.style.transform = 'translateX(0)';
    } else {
        document.getElementById('expandInf')!.style.transform = 'rotate(180deg)';
        document.getElementById('examInfContainer')!.style.transform = 'translateX(-100%)';
    }
  }

  // Unsubscribe to prevent memory leaks
  ngOnDestroy() {
    this.routeSub.unsubscribe();
  }
}
