import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { InspectionComponent } from './components/inspection/inspection.component';
import { ShowInspectionComponent } from './components/inspection/show-inspection/show-inspection.component';
import { AddEditInspectionComponent } from './components/inspection/add-edit-inspection/add-edit-inspection.component';
import { InspectionApiService } from './services/inspection-api.service';
import { InspectionTypesService } from './services/inspection-types.service';

@NgModule({
  declarations: [
    AppComponent,
    InspectionComponent,
    ShowInspectionComponent,
    AddEditInspectionComponent,
  ],
  imports: [BrowserModule, HttpClientModule, FormsModule, ReactiveFormsModule],
  providers: [InspectionApiService, InspectionTypesService],
  bootstrap: [AppComponent],
})
export class AppModule {}
