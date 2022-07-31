import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Employee } from 'src/app/models/employee.model';


@Component({
  selector: 'app-employee',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css'],
})
export class EmployeeComponent implements OnInit {
  items: Employee[] = [];

  constructor() {


  }

  ngOnInit(): void {

  }

  edit(item: Employee) {

  }

  confirmDelete(item: Employee) {

  }
  openModal() { }
}