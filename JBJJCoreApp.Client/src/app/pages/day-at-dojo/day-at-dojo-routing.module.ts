import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DayAtDojoComponent } from './day-at-dojo.component';
import { OutcomeComponent } from './outcome/outcome.component';
import { AttendanceComponent } from './attendance/attendance.component';
import { SparringDetailsComponent } from './sparring-details/sparring-details.component';

const routes: Routes = [{
  path: '',
  component: DayAtDojoComponent,
  children: [{
    path: 'outcome',
    component: OutcomeComponent,
  }, {
    path: 'attendance',
    component: AttendanceComponent,
  }, {
    path: 'sparringdetails',
    component: SparringDetailsComponent,
  }],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DayAtDojoRoutingModule { }

export const routedComponents = [
    DayAtDojoComponent,
    OutcomeComponent,
    AttendanceComponent,
    SparringDetailsComponent,
];
