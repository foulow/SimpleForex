import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-tab-button',
  templateUrl: './tab-button.component.html',
  styleUrls: ['./tab-button.component.scss'],
})
export class TabButtonComponent implements OnInit {
  @Input() variant?: string;
  @Input() target?: string;
  @Input() content?: string;
  @Input() title?: string;
  @Input() isActive?: boolean;

  constructor() {}

  ngOnInit(): void {}
}
