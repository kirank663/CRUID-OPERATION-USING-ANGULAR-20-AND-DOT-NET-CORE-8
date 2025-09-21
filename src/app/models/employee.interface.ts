export interface Employee {
  employeeId?: number;
  firstName: string;
  lastName: string;
  email?: string | null;
  phone?: string | null;
  title?: string | null;
  isActive: boolean;
  insertedOn?: string;
  modifiedOn?: string | null;
}