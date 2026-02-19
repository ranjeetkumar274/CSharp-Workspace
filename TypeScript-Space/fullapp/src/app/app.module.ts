import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListFeedbackComponent } from './list-feedback/list-feedback.component';
import { FormsModule } from '@angular/forms';
import { HeaderComponent } from './header/header.component';
import { HttpClientModule } from '@angular/common/http';
import { AddFeedbackComponent } from './add-feedback/add-feedback.component';
import { ConfirmDeleteComponent } from './confirm-delete/confirm-delete.component';

@NgModule({
  declarations: [
    AppComponent,
    ListFeedbackComponent,
    HeaderComponent,
    AddFeedbackComponent,
    ConfirmDeleteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
