import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../models/employee.interface';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class EmployeeService {
  private http = inject(HttpClient);
  private base = 'https://localhost:44398/api/Employees'; // adjust to your port

  list(): Observable<Employee[]> { return this.http.get<Employee[]>(this.base); }
  get(id: number): Observable<Employee> { return this.http.get<Employee>(`${this.base}/${id}`); }
  create(e: Employee): Observable<Employee> { return this.http.post<Employee>(this.base, e); }
  update(id: number, e: Employee): Observable<void> { return this.http.put<void>(`${this.base}/${id}`, e); }
  delete(id: number): Observable<void> { return this.http.delete<void>(`${this.base}/${id}`); }
}
