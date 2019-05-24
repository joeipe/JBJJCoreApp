import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ScheduleComponent } from './schedule.component';
import { TimeTableComponent } from './time-table/time-table.component';
import { ClassTypesComponent } from './class-types/class-types.component';

const routes: Routes = [{
  path: '',
  component: ScheduleComponent,
  children: [{
    path: 'timetable',
    component: TimeTableComponent,
  }, {
    path: 'classtypes',
    component: ClassTypesComponent,
  }],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ScheduleRoutingModule { }

export const routedComponents = [
  ScheduleComponent,
  TimeTableComponent,
  ClassTypesComponent
];