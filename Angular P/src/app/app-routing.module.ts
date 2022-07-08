import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizationGuard } from './authorization.guard';

const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () =>
      import('./authentication/authentication.module').then(
        (m) => m.AuthenticationModule
      ),
  },
  {
    path: '',
    loadChildren: () => import('./clint/clint.module').then(
      (m) => m.ClintModule,
    )
  },
  {
    path: 'admin',
    loadChildren: () => import('./admin/admin.module').then(
      (m) => m.AdminModule,
    ),
    canActivate: [AuthorizationGuard]
  },
    {
    path: 'profile',
    loadChildren: () => import('./user-profile/user-profile.module').then(
      (m) => m.UserProfileModule,
    ),
     canActivate: [AuthorizationGuard]
  },
  {
    path:'exam',
    loadChildren: () => import('./exam/exam.module').then(
      (m) => m.ExamModule
    ),
    canActivate: [AuthorizationGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
