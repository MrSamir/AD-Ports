import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeComponent } from './employees.component';
import { EmployeesRoutingModule } from './employees-routing.module';
import { httpInterceptorProviders } from 'src/app/http-interceptor';
import { AuthGuard } from 'src/app/http-interceptor/auth-guard';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TableModule } from 'primeng/table';
import { EmployeeModalComponent } from '../employee-modal/employee-modal.component';


@NgModule({
  imports: [
    CommonModule,
    EmployeesRoutingModule,
    ReactiveFormsModule,
    TableModule,
    FormsModule,
  ],
  declarations: [EmployeeComponent, EmployeeModalComponent]
})
export class EmployeesModule { }
