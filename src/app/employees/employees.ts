import { Component, inject, signal, computed } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { EmployeeService } from '../services/employee.service';
import { Employee } from '../models/employee.interface';

@Component({
  standalone: true,
   selector: 'app-root',
  templateUrl: './employees.html',
  imports: [CommonModule, FormsModule]
})
export class Employees {
  private api = inject(EmployeeService);

  employees = signal<Employee[]>([]);
  showModal = signal(false);
  isEdit = signal(false);
  form: Employee = { firstName: '', lastName: '', isActive: true };

  ngOnInit() { this.load(); }

  load() {
    this.api.list().subscribe(res => this.employees.set(res));
  }

  openCreate() {
    this.form = { firstName: '', lastName: '', email: '', phone: '', title: '', isActive: true };
    this.isEdit.set(false);
    this.showModal.set(true);
  }

  openEdit(e: Employee) {
    this.form = { ...e };
    this.isEdit.set(true);
    this.showModal.set(true);
  }

  close() { this.showModal.set(false); }

  save() {
    if (this.isEdit()) {
      this.api.update(this.form.employeeId!, this.form).subscribe(() => { this.close(); this.load(); });
    } else {
      this.api.create(this.form).subscribe(() => { this.close(); this.load(); });
    }
  }

  remove(e: Employee) {
    if (confirm(`Delete ${e.firstName} ${e.lastName}?`)) {
      this.api.delete(e.employeeId!).subscribe(() => this.load());
    }
  }
}
