import { NgModule } from '@angular/core';
import { Ng2SmartTableModule } from 'ng2-smart-table';

import { ThemeModule } from '../../@theme/theme.module';

import { StudentRoutingModule, routedComponents } from './student-routing.module';
import { GradeComponent } from './grade/grade.component';
import { PeopleComponent } from './people/people.component';

@NgModule({
  imports: [
    ThemeModule,
    StudentRoutingModule,
    Ng2SmartTableModule,
  ],
  declarations: [
    ...routedComponents,
    GradeComponent,
    PeopleComponent,
  ],
})
export class StudentModule { }