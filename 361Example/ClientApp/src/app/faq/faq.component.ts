import { Component, OnInit, OnDestroy} from '@angular/core';


@Component({
  selector: 'app-faq',
  templateUrl: './faq.component.html',
  styleUrls: ['./bg.component.scss']
})
export class FaqComponent {
  ngOnInit() {
    document.body.classList.add('bg');
  }
  ngOnDestroy() {
    document.body.classList.remove('bg');
  }
}
