import { NgModule } from '@angular/core';
import { Ng2SmartTableModule } from 'ng2-smart-table';

import { ThemeModule } from '../../@theme/theme.module';

import { ScheduleRoutingModule, routedComponents } from './schedule-routing.module';
import { ClassTypesComponent } from './class-types/class-types.component';
import { TimeTableComponent } from './time-table/time-table.component';

@NgModule({
  imports: [
    ThemeModule,
    ScheduleRoutingModule,
    Ng2SmartTableModule,
  ],
  declarations: [
    ...routedComponents,
    ClassTypesComponent,
    TimeTableComponent,
  ],
})
export class ScheduleModule { }
