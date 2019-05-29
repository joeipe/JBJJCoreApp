import { Component, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { StudentService } from '../../../@core/http/student.service';

@Component({
  selector: 'ngx-grade',
  templateUrl: './grade.component.html',
  styleUrls: ['./grade.component.scss'],
})
export class GradeComponent implements OnInit {
  settings = {
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
      name : {
        title: 'Name',
        type: 'string',
      },
    },
  };
  source: LocalDataSource = new LocalDataSource();

  constructor(private studentService: StudentService) {}

  ngOnInit() {
    this.loadGrade();
  }

  loadGrade(): void {
    this.studentService.GetGrade().subscribe((data) => {
      this.source.load(data);
    });
  }

  onCreateConfirm(event): void {
    this.studentService.AddGrade(event.newData).subscribe(() => {
      event.confirm.resolve();
      this.loadGrade();
    });
  }

  onEditConfirm(event): void {
    event.newData.isDirty = true;
    this.studentService.UpdateGrade(event.newData).subscribe(() => {
      event.confirm.resolve();
      this.loadGrade();
    });
  }

  onDeleteConfirm(event): void {
    if (window.confirm('Are you sure you want to delete?')) {
      this.studentService.DeleteGrade(event.data.id).subscribe(() => {
        event.confirm.resolve();
        this.loadGrade();
      });
    } else {
      event.confirm.reject();
    }
  }
}
