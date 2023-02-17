import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Employee } from '../Models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  url: string = "http://localhost:3000/employees";
  constructor(private httpClient: HttpClient) { }

  public getAllEmployees(): Observable<Employee[]> {
    return this.httpClient.get<Employee[]>(this.url);
  }

  public getEmployee(id: string): Observable<Employee> {
    const tempUrl: string = this.url + "/" + id;
    return this.httpClient.get<Employee>(tempUrl);
  }

  public postEmployee(emp: Employee): Observable<Employee> {
    return this.httpClient.post<Employee>(this.url, emp)
  }

  public deleteEmployee(id: number): Observable<string> {
    const tempUrl: string = this.url + "/" + id;
    return this.httpClient.delete<string>(tempUrl);
  }

  public putEmployee(id: number, emp: Employee): Observable<Employee> {
    const tempUrl: string = this.url + "/" + id;
    return this.httpClient.put<Employee>(tempUrl, emp);
  }
}
