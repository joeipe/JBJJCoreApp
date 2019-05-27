import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { StudentComponent } from './student.component';
import { GradeComponent } from './grade/grade.component';
import { PeopleComponent } from './people/people.component';

const routes: Routes = [{
  path: '',
  component: StudentComponent,
  children: [{
    path: 'grade',
    component: GradeComponent,
  }, {
    path: 'people',
    component: PeopleComponent,
  }],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class StudentRoutingModule { }

export const routedComponents = [
  StudentComponent,
  GradeComponent,
  PeopleComponent,
];
