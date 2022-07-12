import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './admin-routing.module';
import { SideBarComponent } from './side-bar/side-bar.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SharedModule } from '../shared/shared/shared.module';
import { AdminProfileComponent } from './admin-profile/admin-profile.component';
import { EditProfileComponent } from './edit-profile/edit-profile.component';
import { UserService } from '../service/user.service';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { UsersComponent } from './users/users.component';
import { DashboardCardComponent } from './dashboard-card/dashboard-card.component';
import { HomeService } from '../service/home.service';
import { AdminService } from '../service/admin.service';
import { AdminCoursesComponent } from './admin-courses/admin-courses.component';
import { AdminTestimonialComponent } from './admin-testimonial/admin-testimonial.component';
import {MatTableModule} from '@angular/material/table';
import {MatSelectModule} from '@angular/material/select';
import { CreateCourseComponent } from './admin-courses/create-course/create-course.component';
import { StudentReportComponent } from './student-report/student-report.component';
import { StdReportDetailsComponent } from './student-report/std-report-details/std-report-details.component';
import { AdminServicesComponent } from './admin-services/admin-services.component';
import { CreateServiceComponent } from './admin-services/create-service/create-service.component';
import { AdminExamsComponent } from './admin-exams/admin-exams.component';
import { CreateExamComponent } from './admin-exams/create-exam/create-exam.component';
import { SiteInfoComponent } from './site-info/site-info.component';
import {MatStepperModule} from '@angular/material/stepper';
import { UpdateExamComponent } from './admin-courses/update-exam/update-exam.component';
import { FullCalendarModule } from '@fullcalendar/angular';
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin from '@fullcalendar/interaction';
import { ProfitReportComponent } from './profit-report/profit-report.component';
import { AdminQuestionsComponent } from './admin-questions/admin-questions.component';
import { CreateQuestionComponent } from './admin-questions/create-question/create-question.component';

FullCalendarModule.registerPlugins([
  dayGridPlugin,
  interactionPlugin
])




@NgModule({
  declarations: [
    SideBarComponent,
    AdminTestimonialComponent,
    DashboardComponent,
    AdminProfileComponent,
    EditProfileComponent,
    NavBarComponent,
    UsersComponent,
    DashboardCardComponent,
    AdminCoursesComponent,
    CreateCourseComponent,
    StudentReportComponent,
    StdReportDetailsComponent,
    AdminServicesComponent,
    CreateServiceComponent,
    AdminExamsComponent,
    CreateExamComponent,
    SiteInfoComponent,
    UpdateExamComponent,
    CreateQuestionsComponent
    ProfitReportComponent,
    AdminQuestionsComponent,
    CreateQuestionComponent,
    
  ],
  imports: [
    SharedModule,
    AdminRoutingModule,
    MatTableModule,
    MatSelectModule,
    MatStepperModule,
    FullCalendarModule
  ],
  providers: [UserService, HomeService,AdminService]
})
export class AdminModule { }
