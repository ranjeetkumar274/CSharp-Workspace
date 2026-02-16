import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GameTrackerComponent } from './game-tracker/game-tracker.component';
import { HeaderComponent } from './header/header.component';
import { FormsModule } from '@angular/forms';
import { TravelBucketlistComponent } from './travel-bucketlist/travel-bucketlist.component';

@NgModule({
  declarations: [
    AppComponent,
    GameTrackerComponent,
    HeaderComponent,
    TravelBucketlistComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
