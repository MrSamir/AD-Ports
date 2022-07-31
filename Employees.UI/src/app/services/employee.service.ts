import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../models/employee.model';
import { environment } from 'src/environments/environment';


@Injectable({
    providedIn: 'root',
})
export class EmployeeService {

    private readonly Api_Url: string = environment.API_URL;
    private readonly controllerName: string = 'Employees/';
    constructor(private _http: HttpClient) { }

    // getEmployees() {
    //     return this.http.get<Employee[]>(this.baseUrl);
    // }

    // postEmployee(employee: Employee) {
    //     return this.http.post<Employee>(this.baseUrl, employee);
    // }

    // deleteEmployee(id: string) {
    //     return this.http.delete(this.baseUrl + '/' + id);
    // }



    //#region  Employee
    getEmployees() {
        return this._http.get<Employee[]>(this.Api_Url + this.controllerName + 'GetEmployees');
    }

    getEmployee(id: number) {
        return this._http.get<Employee>(this.Api_Url + this.controllerName + 'GetEmployee?id=' + id);
    }

    deleteEmployee(id: number) {
        return this._http.delete<number>(this.Api_Url + this.controllerName + 'DeleteEmployee?id=' + id);
    }


    addEmployee(employee: Employee) {
        return this._http.post(this.Api_Url + this.controllerName + 'AddEmployee', employee);
    }
    updateEmployee(employee: Employee) {
        return this._http.put(this.Api_Url + this.controllerName + 'UpdatEmployee', employee);
    }
    //#endregion

}