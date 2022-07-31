import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from 'src/app/http-interceptor/auth-guard';
import { EmployeeComponent } from './employees.component';



const routes: Routes = [


  // { path: 'List', component: EmployeesComponent, canActivate: [AuthGuard] },
  { path: 'List', component: EmployeeComponent },






];

export const EmployeesRoutingModule = RouterModule.forChild(routes);
