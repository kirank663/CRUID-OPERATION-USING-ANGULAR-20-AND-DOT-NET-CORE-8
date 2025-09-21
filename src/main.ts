import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import 'Zone.js'
import { Employees } from './app/employees/employees';


bootstrapApplication(Employees,appConfig)
  .catch((err) => console.error(err));
