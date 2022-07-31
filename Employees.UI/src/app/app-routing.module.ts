import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [

  { path: '', pathMatch: 'full', redirectTo: 'Home' },
  { path: 'Home', component: HomeComponent },
  {
    path: 'Employees',
    loadChildren: () => import('./components/employees/employees.module').then(m => m.EmployeesModule)
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
