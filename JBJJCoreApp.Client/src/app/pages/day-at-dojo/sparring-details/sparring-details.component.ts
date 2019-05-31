import { Component, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { DayAtDojoService } from '../../../@core/http/day-at-dojo.service';
import { StudentService } from '../../../@core/http/student.service';
import { forkJoin } from 'rxjs';
import { map } from 'rxjs/operators';
import {  SparringDetails, AttendanceDetailed } from '../../../@core/data/models';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'ngx-sparring-details',
  templateUrl: './sparring-details.component.html',
  styleUrls: ['./sparring-details.component.scss'],
})
export class SparringDetailsComponent implements OnInit {
  attendanceId: number;
  attendanceDetailed: AttendanceDetailed;
  outcomeOptions: any[] = [];
  peopleOptions: any[] = [];
  settings: any;
  source: LocalDataSource = new LocalDataSource();

  constructor(
    private dayAtDojoService: DayAtDojoService,
    private studentService: StudentService,
    private route: ActivatedRoute,
    private location: Location) {}

  ngOnInit() {
    this.attendanceId = this.route.snapshot.params.id;
    this.loadPage();
  }

  loadPage(): void {
    const serviceHub = forkJoin(
      [
        this.dayAtDojoService.getOutcome().pipe(map(r => r.map(v => ({value: v.id, title: v.name})))),
        this.studentService.GetPersonWithGraph().pipe(map(r =>
          r.map(v =>
            ({value: v.id,
              title: `${v.firstName} ${v.lastName} (${v.grade.name} ${v.stripe})`}),
          ),
        )),
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
          'personName': {
            title: 'Person',
            type: 'string',
            valuePrepareFunction: (cell: any, row: SparringDetails) => {
              if (row.personSparringPartner)
                return `${row.personSparringPartner.fullName}
                  (${row.personSparringPartner.grade}   ${row.personSparringPartner.stripe})`;
            },
            editor: {
              type: 'list',
              config: {
                list: this.peopleOptions,
              },
            },
          },
          'outcomeName': {
            title: 'Outcome',
            type: 'string',
            valuePrepareFunction: (cell: any, row: SparringDetails) => {
              if (row.outcome)
                return row.outcome.name;
            },
            editor: {
              type: 'list',
              config: {
                list: this.outcomeOptions,
              },
            },
          },
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
    this.dayAtDojoService.getAttendanceWithGraphById(this.attendanceId).subscribe((data) => {
      this.attendanceDetailed = data;
      this.source.load(data.sparringDetails);
    });
  }

  onCreateConfirm(event): void {
    event.newData.attendanceId = this.attendanceDetailed.id;
    event.newData.personId = event.newData.personName;
    event.newData.outcomeId = event.newData.outcomeName;
    this.dayAtDojoService.addSparringDetails(event.newData).subscribe(() => {
      event.confirm.resolve();
      this.loadAttendanceWithSparringDetails();
    });
  }

  onEditConfirm(event): void {
    event.newData.personId = event.newData.personName;
    event.newData.outcomeId = event.newData.outcomeName;
    event.newData.personSparringPartner = null;
    event.newData.outcome = null;
    event.newData.attendance = null;
    event.newData.isDirty = true;
    this.dayAtDojoService.updateSparringDetails(event.newData).subscribe(() => {
      event.confirm.resolve();
      this.loadAttendanceWithSparringDetails();
    });
  }

  onDeleteConfirm(event): void {
    if (window.confirm('Are you sure you want to delete?')) {
      this.dayAtDojoService.deleteSparringDetails(event.data.id).subscribe(() => {
        event.confirm.resolve();
        this.loadAttendanceWithSparringDetails();
      });
    } else {
      event.confirm.reject();
    }
  }

  onBackClick(): void {
    this.location.back();
  }
}
