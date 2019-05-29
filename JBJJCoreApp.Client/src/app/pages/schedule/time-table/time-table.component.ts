import { Component, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { ScheduleService } from '../../../@core/http/schedule.service';
import { TimeTable } from '../../../@core/data/models';
import { forkJoin, of } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'ngx-time-table',
  templateUrl: './time-table.component.html',
  styleUrls: ['./time-table.component.scss'],
})
export class TimeTableComponent implements OnInit {
  dayOfWeekOptions: any[] = [];
  classTypeOptions: any[] = [];
  settings: any;
  source: LocalDataSource = new LocalDataSource();

  constructor(private scheduleService: ScheduleService) {}

  ngOnInit() {
    this.loadPage();
  }

  loadPage(): void {
    const serviceHub = forkJoin(
      [
        of([
          {value: 'Monday', title: 'Monday'},
          {value: 'Tuesday', title: 'Tuesday'},
          {value: 'Wednesday', title: 'Wednesday'},
          {value: 'Thursday', title: 'Thursday'},
          {value: 'Friday', title: 'Friday'},
          {value: 'Saturday', title: 'Saturday'},
          {value: 'Sunday', title: 'Sunday'},
        ]),
        this.scheduleService.getClassType().pipe(map(r => r.map(v => ({value: v.id, title: v.name})))),
      ],
    );

    serviceHub.subscribe(responseList => {
      this.dayOfWeekOptions = responseList[0];
      this.classTypeOptions = responseList[1];

      this.settings = {
        add: {
          addButtonContent: '<i class="nb-plus"></i>',
          createButtonContent: '<i class="nb-checkmark"></i>',
          cancelButtonContent: '<i class="nb-close"></i>',
          confirmCreate: true,
        },
        edit: {
          editButtonContent: '<i class="nb-edit"></i>',
          saveButtonContent: '<i class="nb-checkmark"></i>',
          cancelButtonContent: '<i class="nb-close"></i>',
          confirmSave: true,
        },
        delete: {
          deleteButtonContent: '<i class="nb-trash"></i>',
          confirmDelete: true,
        },
        columns: {
          dayofWeek: {
            title: 'Day of Week',
            type: 'string',
            editor: {
              type: 'list',
              config: {
                list: this.dayOfWeekOptions,
              },
            },
            filter: {
              type: 'list',
              config: {
                selectText: 'All',
                list: this.dayOfWeekOptions,
              },
            },
          },
          startTimeHr: {
            title: 'Start Time Hr',
            type: 'number',
          },
          startTimeMin: {
            title: 'Start Time Min',
            type: 'number',
          },
          endTimeHr: {
            title: 'End Time Hr',
            type: 'number',
          },
          endTimeMin: {
            title: 'End Time Min',
            type: 'number',
          },
          'classTypeName': {
            title: 'Class Type',
            type: 'string',
            valuePrepareFunction: (cell: any, row: TimeTable) => {
              if (row.classType)
                return row.classType.name;
            },
            editor: {
              type: 'list',
              config: {
                list: this.classTypeOptions,
              },
            },
          },
        },
      };

      this.loadTimeTable();
    });
  }

  loadTimeTable(): void {
    this.scheduleService.GetTimeTableWithGraph().subscribe((data) => {
      this.source.load(data);
    });
  }

  onCreateConfirm(event): void {
    event.newData.classTypeId = event.newData.classTypeName;
    this.scheduleService.AddTimeTable(event.newData).subscribe(() => {
      event.confirm.resolve();
      this.loadTimeTable();
    });
  }

  onEditConfirm(event): void {
    event.newData.classTypeId = event.newData.classTypeName;
    event.newData.classType = null;
    event.newData.isDirty = true;
    this.scheduleService.UpdateTimeTable(event.newData).subscribe(() => {
      event.confirm.resolve();
      this.loadTimeTable();
    });
  }

  onDeleteConfirm(event): void {
    if (window.confirm('Are you sure you want to delete?')) {
      this.scheduleService.DeleteTimeTable(event.data.id).subscribe(() => {
        event.confirm.resolve();
        this.loadTimeTable();
      });
    } else {
      event.confirm.reject();
    }
  }
}
