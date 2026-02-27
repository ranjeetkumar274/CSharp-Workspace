import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { HeaderComponent } from './header/header.component';
import { ListTrainingprogramsComponent } from './list-trainingprograms/list-trainingprograms.component';
import { ConfirmDeleteComponent } from './confirm-delete/confirm-delete.component';
import { AddTrainingprogramComponent } from './add-trainingprogram/add-trainingprogram.component';
import { UpdateTrainingprogramComponent } from './update-trainingprogram/update-trainingprogram.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ListTrainingprogramsComponent,
    ConfirmDeleteComponent,
    AddTrainingprogramComponent,
    UpdateTrainingprogramComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
