import { Component, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { SmartTableData } from '../../../@core/data/smart-table';
import { DayAtDojoService } from '../../../@core/http/day-at-dojo.service';

@Component({
  selector: 'ngx-outcome',
  templateUrl: './outcome.component.html',
  styleUrls: ['./outcome.component.scss'],
})
export class OutcomeComponent implements OnInit {
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

  constructor(private dayAtDojoService: DayAtDojoService) {}

  ngOnInit() {
    this.loadOutcome();
  }

  loadOutcome(): void {
    this.dayAtDojoService.getOutcome().subscribe((data) => {
      this.source.load(data);
    });
  }

  onCreateConfirm(event): void {
    this.dayAtDojoService.addOutcome(event.newData).subscribe(() => {
      event.confirm.resolve();
      this.loadOutcome();
    });
  }

  onEditConfirm(event): void {
    event.newData.isDirty = true;
    this.dayAtDojoService.updateOutcome(event.newData).subscribe(() => {
      event.confirm.resolve();
      this.loadOutcome();
    });
  }

  onDeleteConfirm(event): void {
    if (window.confirm('Are you sure you want to delete?')) {
      this.dayAtDojoService.deleteOutcome(event.data.id).subscribe(() => {
        event.confirm.resolve();
        this.loadOutcome();
      });
    } else {
      event.confirm.reject();
    }
  }
}
