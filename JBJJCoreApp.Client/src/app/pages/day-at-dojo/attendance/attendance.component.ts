import { Component, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { DayAtDojoService } from '../../../@core/http/day-at-dojo.service';
import { forkJoin } from 'rxjs';
import { map } from 'rxjs/operators';
import { ScheduleService } from '../../../@core/http/schedule.service';
import { Attendance } from '../../../@core/data/models';

@Component({
  selector: 'ngx-attendance',
  templateUrl: './attendance.component.html',
  styleUrls: ['./attendance.component.scss'],
})
export class AttendanceComponent implements OnInit {
  timeTableOptions: any[] = [];
  settings: any;
  source: LocalDataSource = new LocalDataSource();

  constructor(private dayAtDojoService: DayAtDojoService, private scheduleService: ScheduleService) {}

  ngOnInit() {
    this.loadPage();
  }

  loadPage(): void {
    const serviceHub = forkJoin(
      [
        this.scheduleService.GetTimeTableWithGraph()
          .pipe(
            map(r =>
              r.map(v =>
                (
                  {
                    value: v.id,
                    title: `${v.dayofWeek} ${v.startTimeHr}:${v.startTimeMin}
                    to ${v.endTimeHr}:${v.endTimeMin} (${v.classType.name})`,
                  }
                ),
              ),
            )),
      ],
    );

    serviceHub.subscribe(responseList => {
      this.timeTableOptions = responseList[0];

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
          attendedOn : {
            title: 'Attended Date',
            type: 'string',
            valuePrepareFunction: (cell: any, row: Attendance) => {
              if (row.attendedOn)
                return row.attendedOn;
            },
          },
          techniqueOfTheDay : {
            title: 'Technique Of The Day',
            type: 'string',
          },
          'timeTableConcat' : {
            title: 'Time Table',
            type: 'string',
            valuePrepareFunction: (cell: any, row: Attendance) => {
              const v = row.timeTableClassAttended;
              if (v)
                return `${v.dayofWeek} ${v.startTimeHr}:${v.startTimeMin}
                to ${v.endTimeHr}:${v.endTimeMin} (${v.classType})`;
            },
            editor: {
              type: 'list',
              config: {
                list: this.timeTableOptions,
              },
            },
          },
        },
      };

      this.loadAttendance();
    });
  }

  loadAttendance(): void {
    this.dayAtDojoService.getAttendanceWithTimeTableGraph().subscribe((data) => {
      this.source.load(data);
    });
  }

  onCreateConfirm(event): void {
    event.newData.timeTableId = event.newData.timeTableConcat;
    this.dayAtDojoService.addAttendance(event.newData).subscribe(() => {
      event.confirm.resolve();
      this.loadAttendance();
    });
  }

  onEditConfirm(event): void {
    event.newData.timeTableId = event.newData.timeTableConcat;
    event.newData.timeTableClassAttended = null;
    event.newData.isDirty = true;
    this.dayAtDojoService.updateAttendance(event.newData).subscribe(() => {
      event.confirm.resolve();
      this.loadAttendance();
    });
  }

  onDeleteConfirm(event): void {
    if (window.confirm('Are you sure you want to delete?')) {
      this.dayAtDojoService.deleteAttendance(event.data.id).subscribe(() => {
        event.confirm.resolve();
        this.loadAttendance();
      });
    } else {
      event.confirm.reject();
    }
  }
}
