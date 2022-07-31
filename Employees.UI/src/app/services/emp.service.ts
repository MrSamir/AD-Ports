import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';



import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Employee } from '../models/employee.model';
import { environment } from 'src/environments/environment';
@Injectable({
    providedIn: 'root'
})
export class empService {


    private readonly url: string = environment.Gateway_URL;

    constructor(private http: HttpClient) { }
    getEmployees(): Observable<Employee[]> {
        return this.http.get<Employee[]>(this.url + 'GetEmployees');
    }
    addEmployee(employee: Employee) {
        const httpHeaders = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
        return this.http.post(this.url + 'AddEmployee', employee, httpHeaders);
    }

    updateEmployee(employee: Employee): Observable<Employee> {
        const httpHeaders = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
        return this.http.put<Employee>(this.url + 'UpdateEmployee', employee, httpHeaders);
    }
    deleteEmployee(id: number): Observable<number> {
        return this.http.delete<number>(this.url + 'DeleteEmployee/' + id);
    }

}