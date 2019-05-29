import { Component, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { ScheduleService } from '../../../@core/http/schedule.service';

@Component({
  selector: 'ngx-class-types',
  templateUrl: './class-types.component.html',
  styleUrls: ['./class-types.component.scss'],
})
export class ClassTypesComponent implements OnInit {
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

  constructor(private scheduleService: ScheduleService) {}

  ngOnInit() {
    this.loadClassType();
  }

  loadClassType(): void {
    this.scheduleService.getClassType().subscribe((data) => {
      this.source.load(data);
    });
  }

  onCreateConfirm(event): void {
    this.scheduleService.AddClassType(event.newData).subscribe(() => {
      event.confirm.resolve();
      this.loadClassType();
    });
  }

  onEditConfirm(event): void {
    event.newData.isDirty = true;
    this.scheduleService.UpdateClassType(event.newData).subscribe(() => {
      event.confirm.resolve();
      this.loadClassType();
    });
  }

  onDeleteConfirm(event): void {
    if (window.confirm('Are you sure you want to delete?')) {
      this.scheduleService.DeleteClassType(event.data.id).subscribe(() => {
        event.confirm.resolve();
        this.loadClassType();
      });
    } else {
      event.confirm.reject();
    }
  }
}
