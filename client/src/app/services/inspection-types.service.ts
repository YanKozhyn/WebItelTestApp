import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class InspectionTypesService {
  readonly inspectionApiUrl = 'https://localhost:7153/api';
  constructor(private http: HttpClient) {}

  getInspectionTypesList(): Observable<any[]> {
    return this.http.get<any>(this.inspectionApiUrl + '/InspectionTypes');
  }

  addInspectionTypes(data: any) {
    return this.http.post(this.inspectionApiUrl + '/InspectionTypes', data);
  }

  updateInspectionTypes(id: number | string, data: any) {
    return this.http.put(this.inspectionApiUrl + `/InspectionTypes/${id}`, data);
  }

  deleteInspectionTypes(id: number | string) {
    return this.http.delete(this.inspectionApiUrl + `/InspectionTypes/${id}`);
  }
}
