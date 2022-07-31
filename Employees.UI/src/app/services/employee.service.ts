import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Employee } from '../models/employee.model';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';


@Injectable({
    providedIn: 'root',
})
export class EmployeeService {

    private readonly gateway_Url: string = environment.Gateway_URL;
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
        // return this._http.get<Employee[]>(this.Api_Url + this.controllerName + 'GetEmployees');
        return this._http.get<Employee[]>(this.gateway_Url + 'GetEmployees');
    }

    getEmployee(id: number) {
        // return this._http.get<Employee>(this.Api_Url + this.controllerName + 'GetEmployee?id=' + id);
        return this._http.get<Employee>(this.gateway_Url + 'GetEmployeeByID?id=' + id);
    }

    deleteEmployee(id: number): Observable<number> {


        return this._http.delete<number>(this.gateway_Url + 'DeleteEmployee/' + id);
    }

    addEmployee(employee: Employee) {
        const httpHeaders = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
        return this._http.post(this.gateway_Url + 'AddEmployee', employee, httpHeaders);

    }


    // addEmployee(employee: Employee) {
    //     const httpHeaders = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    //     return this.http.post(this.url + 'AddEmployee', employee, httpHeaders);
    // }

    updateEmployee(employee: Employee): Observable<Employee> {
        const httpHeaders = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
        return this._http.put<Employee>(this.gateway_Url + 'UpdateEmployee', employee, httpHeaders);
    }
    //#endregion

}
















