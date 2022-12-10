import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class StatusesService {
  readonly inspectionApiUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}

  getStatusList(): Observable<any[]> {
    return this.http.get<any>(this.inspectionApiUrl + '/status');
  }

  addStatus(data: any) {
    return this.http.post(this.inspectionApiUrl + '/status', data);
  }

  updateStatus(id: number | string, data: any) {
    return this.http.put(
      this.inspectionApiUrl + `/status/${id}`,
      data
    );
  }

  deleteStatus(id: number | string) {
    return this.http.delete(this.inspectionApiUrl + `/status/${id}`);
  }
}
