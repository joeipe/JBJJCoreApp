import { NgModule } from '@angular/core';
import { Ng2SmartTableModule } from 'ng2-smart-table';

import { ThemeModule } from '../../@theme/theme.module';

import { DayAtDojoRoutingModule, routedComponents } from './day-at-dojo-routing.module';
import { OutcomeComponent } from './outcome/outcome.component';
import { AttendanceComponent } from './attendance/attendance.component';
import { SparringDetailsComponent } from './sparring-details/sparring-details.component';

@NgModule({
  imports: [
    ThemeModule,
    DayAtDojoRoutingModule,
    Ng2SmartTableModule,
  ],
  declarations: [
    ...routedComponents,
    OutcomeComponent,
    AttendanceComponent,
    SparringDetailsComponent,
  ],
})
export class DayAtDojoModule { }
