import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { Employee } from 'src/app/models/employee.model';
import { empService } from 'src/app/services/emp.service';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeModalComponent } from '../employee-modal/employee-modal.component';
import { ConfirmationComponent } from '../shared/confirmation/confirmation.component';


@Component({
  selector: 'app-employee',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css'],
})
export class EmployeeComponent implements OnInit {
  employees: Employee[] = [];
  errorMessage: any;
  constructor(private srvEmployee: EmployeeService, private modalService: NgbModal) {


  }

  ngOnInit(): void {
    this.getEmployees();
  }

  //#region CRUD
  getEmployees() {
    this.srvEmployee.getEmployees().subscribe(

      {
        next: (res) => { this.employees = res; console.log(res) },
        error: (e) => { this.errorMessage = <any>e }
      }

    )

  }




  addEmployee(item: Employee) {
    //Validate If Area is already added before
    const _isExisted = this.CheckIfExist(item)
    if (!_isExisted) {
      // this.groups.push(item);

      this.srvEmployee.addEmployee(item).subscribe(
        {
          next: (res) => { this.employees.push(item); },
          error: (e) => { this.errorMessage = <any>e }
        }
      )

    }
    else {
      //Emit text message and sent it as output to parent (New-Request)
      //  this.ErrorMsgEvent.emit('account type already exists');

      this.showErrorToaster('already exists');
    }

  }





  deleteEmployee(item: Employee) {
    return this.srvEmployee.deleteEmployee(item.id).subscribe({
      next: (res) => {
        const index = this.employees.indexOf(item);
        if (index > -1) {
          this.employees.splice(index, 1);
        }

      },
      error: (e) => { this.errorMessage = <any>e }
    })




  }





  edit(item: Employee) {

    let _modalRef: NgbModalRef;
    // _modalRef = this.modalService.open(EmployeeModalComponent, this._helper.modalConfiguration());
    _modalRef = this.modalService.open(EmployeeModalComponent);
    _modalRef.componentInstance._ItemForEdit = item;

    //ChildAllowance Emitter to save the values (the save function is on parent)
    _modalRef.componentInstance._eventEmitterModalValues.subscribe((_list: Employee) => {


      this.updateEmployee(_list);



    });
  }

  updateEmployee(item: Employee) {


    this.srvEmployee.updateEmployee(item).subscribe(

      data => {

        this.getEmployees();


      },
      (err) => { this.errorMessage = <any>err }
    )
  }



  showUpdatedItem(newItem: Employee) {
    let updateItem = this.employees.find(x => x.id == newItem.id);

    let index = this.employees.indexOf(newItem);


    this.employees[index] = newItem;

  }




  openModal() {

    let _modalRef: NgbModalRef;

    // _modalRef = this.modalService.open(EmployeeModalComponent, this._helper.modalConfiguration());
    _modalRef = this.modalService.open(EmployeeModalComponent);


    //ChildAllowance Emitter to save the values (the save function is on parent)
    _modalRef.componentInstance._eventEmitterModalValues.subscribe((_list: Employee) => {



      this.addEmployee(_list)






    });
  }
  //#endregion



  confirmDelete(item: Employee) {
    let _modalRef: NgbModalRef;
    const index = this.employees.indexOf(item);
    // _modalRef = this.modalService.open(ConfirmationComponent, this._helper.modalConfiguration('small'));
    _modalRef = this.modalService.open(ConfirmationComponent);



    _modalRef.componentInstance.childConfirm.subscribe((IsConfirm: boolean) => {
      if (IsConfirm) {
        // if (index > -1) {
        //   this.items.splice(index, 1);

        this.deleteEmployee(item);
      }
      // }
    })

  }
  //#region 'Helper Methods'
  showErrorToaster(_errormessage: string) {
    // this.toastService.show(_errormessage, _errormessage, {
    //   classname: 'bg-danger text-light',
    // });
  }
  CheckIfExist(item: Employee): boolean {
    let _IsExist: boolean = false;
    for (let index = 0; index < this.employees.length; index++) {
      const element = this.employees[index];
      if (item.firstName == element.firstName && item.lastName == element.lastName) {
        _IsExist = true;
        break;
      }
    }
    return _IsExist;
  }
  //#endregion

}