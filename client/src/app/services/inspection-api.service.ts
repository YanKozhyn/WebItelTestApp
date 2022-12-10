import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class InspectionApiService {
  readonly inspectionApiUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getInspectionList():Observable<any[]> {
    return this.http.get<any>(this.inspectionApiUrl + '/inspections')
  }

  addInspection(data: any) {
    return this.http.post(this.inspectionApiUrl + '/inspections', data)
  }

  updateInspection(id: number | string, data: any) {
    return this.http.put(this.inspectionApiUrl + `/inspections/${id}`, data);
  } 

  deleteInspection(id: number | string) {
    return this.http.delete(this.inspectionApiUrl + `/inspections/${id}`)
  }

}
