import { Component, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
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

  constructor() { // private service: SmartTableData
    // const data = this.service.getData();
    const data = [
      {
        'dayofWeek': 'Monday',
        'startTimeHr': 6,
        'startTimeMin': 45,
        'endTimeHr': 7,
        'endTimeMin': 45,
        'classTypeId': 1,
        'classType': null,
        'id': 1,
        'isDirty': false,
      },
      {
        'dayofWeek': 'Monday',
        'startTimeHr': 18,
        'startTimeMin': 30,
        'endTimeHr': 19,
        'endTimeMin': 30,
        'classTypeId': 4,
        'classType': null,
        'id': 2,
        'isDirty': false,
      },
      {
        'dayofWeek': 'Monday',
        'startTimeHr': 19,
        'startTimeMin': 30,
        'endTimeHr': 20,
        'endTimeMin': 30,
        'classTypeId': 5,
        'classType': null,
        'id': 3,
        'isDirty': false,
      },
      {
        'dayofWeek': 'Tuesday',
        'startTimeHr': 18,
        'startTimeMin': 30,
        'endTimeHr': 19,
        'endTimeMin': 30,
        'classTypeId': 2,
        'classType': null,
        'id': 4,
        'isDirty': false,
      },
      {
        'dayofWeek': 'Tuesday',
        'startTimeHr': 19,
        'startTimeMin': 30,
        'endTimeHr': 20,
        'endTimeMin': 30,
        'classTypeId': 6,
        'classType': null,
        'id': 5,
        'isDirty': false,
      },
      {
        'dayofWeek': 'Wednesday',
        'startTimeHr': 18,
        'startTimeMin': 30,
        'endTimeHr': 19,
        'endTimeMin': 30,
        'classTypeId': 4,
        'classType': null,
        'id': 6,
        'isDirty': false,
      },
      {
        'dayofWeek': 'Wednesday',
        'startTimeHr': 19,
        'startTimeMin': 30,
        'endTimeHr': 20,
        'endTimeMin': 30,
        'classTypeId': 1,
        'classType': null,
        'id': 7,
        'isDirty': false,
      },
      {
        'dayofWeek': 'Thursday',
        'startTimeHr': 18,
        'startTimeMin': 30,
        'endTimeHr': 19,
        'endTimeMin': 30,
        'classTypeId': 1,
        'classType': null,
        'id': 8,
        'isDirty': false,
      },
      {
        'dayofWeek': 'Thursday',
        'startTimeHr': 19,
        'startTimeMin': 30,
        'endTimeHr': 20,
        'endTimeMin': 30,
        'classTypeId': 3,
        'classType': null,
        'id': 9,
        'isDirty': false,
      },
    ];
    this.source.load(data);
  }

  ngOnInit() {
  }

  onDeleteConfirm(event): void {
    if (window.confirm('Are you sure you want to delete?')) {
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }

}
