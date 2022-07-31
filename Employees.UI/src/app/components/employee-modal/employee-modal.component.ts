import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Employee } from 'src/app/models/employee.model';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-employee-modal',
  templateUrl: './employee-modal.component.html',
  styleUrls: ['./employee-modal.component.css']
})
export class EmployeeModalComponent implements OnInit {



  //#region Declarations
  _submit: boolean = false;


  @Output() _eventEmitterModalValues: EventEmitter<any> = new EventEmitter();
  @Output() _add_or_update: EventEmitter<string> = new EventEmitter();
  @Input() _ItemForEdit: Employee = new Employee();
  EmployeeForm: FormGroup = new FormGroup({});
  //#endregion
  constructor(public formBuilder: FormBuilder, public activeModal: NgbActiveModal,
    private srvEmployees: EmployeeService
  ) { }

  ngOnInit() {
    this.initiate_Form();


    if (this._ItemForEdit !== null && this._ItemForEdit.id !== 0) {
      this.setFormValuesForEdit(this._ItemForEdit)

    }

  }



  get form() {
    return this.EmployeeForm.controls;


  }
  private initiate_Form() {
    this.EmployeeForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      age: ['', Validators.required],
      id: [0],
    });
  }


  close() {
    this.activeModal.close();
  }

  setFormValuesForEdit(item: Employee) {


    this.EmployeeForm.patchValue(item); //path value can exclude some controls

  }
  save() {
    //This submit flag is used in validation
    this._submit = true;
    if (this.EmployeeForm.valid) {
      let x: Employee = new Employee()
      x = this.EmployeeForm.value;


      //Emit FormValues to the parent (Output)
      this._eventEmitterModalValues.emit(x);






      //Reset submit flag after successful saving
      this._submit = false;
      this.close();
    }
  }

}
