import { Component, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { DayAtDojoService } from '../../../@core/http/day-at-dojo.service';
import { StudentService } from '../../../@core/http/student.service';
import { forkJoin } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'ngx-sparring-details',
  templateUrl: './sparring-details.component.html',
  styleUrls: ['./sparring-details.component.scss'],
})
export class SparringDetailsComponent implements OnInit {
  outcomeOptions: any[] = [];
  peopleOptions: any[] = [];
  settings: any;
  source: LocalDataSource = new LocalDataSource();

  constructor(private dayAtDojoService: DayAtDojoService, private studentService: StudentService) {}

  ngOnInit() {
    this.loadPage();
  }

  loadPage(): void {
    const serviceHub = forkJoin(
      [
        this.dayAtDojoService.getOutcome().pipe(map(r => r.map(v => ({value: v.id, title: v.name})))),
        this.studentService.getPerson().pipe(map(r => r.map(v => ({value: v.id, title: `${v.firstName} ${v.lastName}`})))),
      ],
    );

    serviceHub.subscribe(responseList => {
      this.outcomeOptions = responseList[0];
      this.peopleOptions = responseList[1];

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
          techniqueUsed: {
            title: 'Technique Used',
            type: 'string',
          },
        },
      };

      this.loadAttendanceWithSparringDetails();
    });
  }

  loadAttendanceWithSparringDetails(): void {
    this.dayAtDojoService.getAttendanceWithGraphById(1).subscribe((data) => {
      this.source.load(data.sparringDetails);
    });
  }

  onCreateConfirm(event): void {
    event.newData.timeTableId = event.newData.timeTableConcat;
    this.dayAtDojoService.addAttendance(event.newData).subscribe(() => {
      event.confirm.resolve();
      this.loadAttendanceWithSparringDetails();
    });
  }

  onEditConfirm(event): void {
    event.newData.timeTableId = event.newData.timeTableConcat;
    event.newData.timeTableClassAttended = null;
    event.newData.isDirty = true;
    this.dayAtDojoService.updateAttendance(event.newData).subscribe(() => {
      event.confirm.resolve();
      this.loadAttendanceWithSparringDetails();
    });
  }

  onDeleteConfirm(event): void {
    if (window.confirm('Are you sure you want to delete?')) {
      this.dayAtDojoService.deleteAttendance(event.data.id).subscribe(() => {
        event.confirm.resolve();
        this.loadAttendanceWithSparringDetails();
      });
    } else {
      event.confirm.reject();
    }
  }
}
