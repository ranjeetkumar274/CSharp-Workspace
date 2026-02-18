import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { NavbarComponent } from './navbar/navbar.component';
import { AdminComponent } from './admin/admin.component';
import { OrganizerComponent } from './organizer/organizer.component';
import { AttendeeComponent } from './attendee/attendee.component';
import { EventComponent } from './event/event.component';
import { HomeComponent } from './home/home.component';
import { ErrorComponent } from './error/error.component';
import { CreateAttendeeComponent } from './attendee/create-attendee/create-attendee.component';
import { CreateEventComponent } from './event/create-event/create-event.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent,
    NavbarComponent,
    AdminComponent,
    OrganizerComponent,
    AttendeeComponent,
    EventComponent,
    HomeComponent,
    ErrorComponent,
    CreateAttendeeComponent,
    CreateEventComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
