import { Component, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { ScheduleService } from '../../../@core/http/schedule.service';
// import { SmartTableData } from '../../../@core/data/smart-table';

@Component({
  selector: 'ngx-time-table',
  templateUrl: './time-table.component.html',
  styleUrls: ['./time-table.component.scss'],
})
export class TimeTableComponent implements OnInit {
  settings = {
    add: {
      addButtonContent: '<i class="nb-plus"></i>',
      createButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
    },
    edit: {
      editButtonContent: '<i class="nb-edit"></i>',
      saveButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
    },
    delete: {
      deleteButtonContent: '<i class="nb-trash"></i>',
      confirmDelete: true,
    },
    columns: {
      dayofWeek: {
        title: 'ID',
        type: 'number',
      },
      startTimeHr: {
        title: 'StartTimeHr',
        type: 'string',
      },
      startTimeMin: {
        title: 'StartTimeMin',
        type: 'string',
      },
      endTimeHr: {
        title: 'EndTimeHr',
        type: 'string',
      },
      endTimeMin: {
        title: 'EndTimeMin',
        type: 'string',
      },
    },
  };
  source: LocalDataSource = new LocalDataSource();

  constructor(private scheduleService: ScheduleService) {}

  ngOnInit() {
    this.scheduleService.GetTimeTable().subscribe((data)=>{
      this.source.load(data);
    });
  }

  onDeleteConfirm(event): void {
    if (window.confirm('Are you sure you want to delete?')) {
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }
}
