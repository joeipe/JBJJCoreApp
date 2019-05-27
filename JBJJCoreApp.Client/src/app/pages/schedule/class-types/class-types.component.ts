import { Component, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';

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
      name : {
        title: 'Name',
        type: 'string',
      },
    },
  };
  source: LocalDataSource = new LocalDataSource();

  constructor() { // private service: SmartTableData
    // const data = this.service.getData();
    const data = [
      {
        'name': 'BJJ Gi All Levels',
        'id': 1,
        'isDirty': false,
      },
      {
        'name': 'BJJ Gi Fundamenals',
        'id': 2,
        'isDirty': false,
      },
      {
        'name': 'BJJ No Gi All Levels',
        'id': 3,
        'isDirty': false,
      },
      {
        'name': 'BJJ Gi Biginners',
        'id': 4,
        'isDirty': false,
      },
      {
        'name': 'BJJ Advanced Class',
        'id': 5,
        'isDirty': false,
      },
      {
        'name': 'BJJ Competition Class',
        'id': 6,
        'isDirty': false,
      },
      {
        'name': 'test1',
        'id': 7,
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
