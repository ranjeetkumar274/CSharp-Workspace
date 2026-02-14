import { Component, OnInit } from '@angular/core';
import { PROMPTS } from 'src/prompts';

@Component({
  selector: 'app-promptdisplay',
  templateUrl: './promptdisplay.component.html',
  styleUrls: ['./promptdisplay.component.css']
})
export class PromptdisplayComponent implements OnInit {
  prompts : string[]=PROMPTS;
  currentPromptIndex:number=0;
  prompt:string;
  constructor(){
    this.nextPrompt();
  }
  nextPrompt(){
    if(this.prompts.length>this.currentPromptIndex)
    {
      this.prompt=this.prompts[this.currentPromptIndex];
      this.currentPromptIndex++;

    }
    else{
      this.currentPromptIndex=0;
      this.prompt=this.prompts[this.currentPromptIndex];
    }
  }

  ngOnInit():void{

  }

}

  
<div class="moal container">
    <h1>Daily Prompts</h1>
    <p [innerText]="prompt"></p>
    <button (click)="nextPrompt()">Next</button>
</div>
