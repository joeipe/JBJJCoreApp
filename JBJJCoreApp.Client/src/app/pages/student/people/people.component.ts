import { Component, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { StudentService } from '../../../@core/http/student.service';
import { Person } from '../../../@core/data/models';
import { forkJoin } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'ngx-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.scss'],
})
export class PeopleComponent implements OnInit {
  gradeOptions: any[] = [];
  settings: any;
  source: LocalDataSource = new LocalDataSource();

  constructor(private studentService: StudentService) {}

  ngOnInit() {
    this.loadPage();
  }

  loadPage(): void {
    const serviceHub = forkJoin(
      [
        this.studentService.GetGrade().pipe(map(r => r.map(v => ({value: v.id, title: v.name})))),
      ],
    );

    serviceHub.subscribe(responseList => {
      this.gradeOptions = responseList[0];

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
          firstName : {
            title: 'First Name',
            type: 'string',
          },
          lastName : {
            title: 'Last Name',
            type: 'string',
          },
          'gradeName' : {
            title: 'Grade',
            type: 'string',
            valuePrepareFunction: (cell: any, row: Person) => {
              if (row.grade)
                return row.grade.name;
            },
            editor: {
              type: 'list',
              config: {
                list: this.gradeOptions,
              },
            },
          },
          stripe : {
            title: 'Stripe',
            type: 'string',
          },
        },
      };

      this.loadPeople();
    });
  }

  loadPeople(): void {
    this.studentService.GetPersonWithGraph().subscribe((data) => {
      this.source.load(data);
    });
  }

  onCreateConfirm(event): void {
    event.newData.gradeId = event.newData.gradeName;
    this.studentService.AddPerson(event.newData).subscribe(() => {
      event.confirm.resolve();
      this.loadPeople();
    });
  }

  onEditConfirm(event): void {
    event.newData.gradeId = event.newData.gradeName;
    event.newData.grade = null;
    event.newData.isDirty = true;
    this.studentService.UpdatePerson(event.newData).subscribe(() => {
      event.confirm.resolve();
      this.loadPeople();
    });
  }

  onDeleteConfirm(event): void {
    if (window.confirm('Are you sure you want to delete?')) {
      this.studentService.DeletePerson(event.data.id).subscribe(() => {
        event.confirm.resolve();
        this.loadPeople();
      });
    } else {
      event.confirm.reject();
    }
  }
}
