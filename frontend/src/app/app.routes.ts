import { Routes } from '@angular/router';
import { PatientsComponent } from './patients/patients.component';
import { LoginComponent } from './components/login/login.component';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
  { path: 'patients', component: PatientsComponent, canActivate: [authGuard] },
  { path: 'login', component: LoginComponent },
  { path: '', redirectTo: '/patients', pathMatch: 'full' },
];
