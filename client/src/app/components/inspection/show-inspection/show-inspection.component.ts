import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { InspectionApiService } from 'src/app/services/inspection-api.service';
import { InspectionTypesService } from 'src/app/services/inspection-types.service';
import { StatusesService } from 'src/app/services/statuses.service';

@Component({
  selector: 'app-show-inspection',
  templateUrl: './show-inspection.component.html',
  styleUrls: ['./show-inspection.component.css'],
})
export class ShowInspectionComponent implements OnInit {
  inspectionList$!: Observable<any[]>;
  inspectionTypesList$!: Observable<any[]>;
  inspectionTypesList: any = [];

  //Map to display data associate with foreign keys
  inspectionTypesMap: Map<number, string> = new Map();

  constructor(
    private inspectionTypesService: InspectionTypesService,
    private statusesService: StatusesService,
    private inspectionService: InspectionApiService
  ) {}

  ngOnInit(): void {
    this.inspectionList$ = this.inspectionService.getInspectionList();
    this.inspectionTypesList$ =
      this.inspectionTypesService.getInspectionTypesList();
    this.refreshInspectionTypesMap();
  }

  // Variables (properties)
  modalTitle: string = '';
  activateAddEditInspectionComponent: boolean = false;
  inspection: any;

  modalAdd() {
    this.inspection = {
      id: 0,
      status: null,
      commets: null,
      inspectionTypeId: null,
    };
    this.modalTitle = 'Add Inspection';
    this.activateAddEditInspectionComponent = true;
  }

  modalEdit(item: any) {
    (this.inspection = item),
      (this.modalTitle = 'Edit Inspection'),
      (this.activateAddEditInspectionComponent = true);
  }

  delete(item: any) {
    if (confirm(`Are you sure you want to delete inspection ${item.id}`)) {
      this.inspectionService.deleteInspection(item.id).subscribe((res) => {
        var closeModalBtn = document.getElementById('add-edit-modal-close');
        if (closeModalBtn) {
          closeModalBtn.click();
        }

        var showDeleteSuccess = document.getElementById('delete-success-alert');
        if (showDeleteSuccess) {
          showDeleteSuccess.style.display = 'block';
        }
        setTimeout(function () {
          if (showDeleteSuccess) {
            showDeleteSuccess.style.display = 'none';
          }
        }, 4000);
        this.inspectionList$ = this.inspectionService.getInspectionList();
      });
    }
  }

  modalClose() {
    this.activateAddEditInspectionComponent = false;
    this.inspectionList$ = this.inspectionService.getInspectionList();
  }

  refreshInspectionTypesMap() {
    this.inspectionTypesService.getInspectionTypesList().subscribe({
      next: (data) => {
        this.inspectionTypesList = data;

        for (let i = 0; i < data.length; i++) {
          this.inspectionTypesMap.set(
            this.inspectionTypesList[i].id,
            this.inspectionTypesList[i].inspectionName
          );
        }
      },
    });
  }
}
