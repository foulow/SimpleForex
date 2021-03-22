import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-link',
  templateUrl: './link.component.html',
  styleUrls: ['./link.component.scss'],
})
export class LinkComponent implements OnInit {
  @Input() variant?: string;
  @Input() url?: string;
  @Input() content?: string;
  @Input() title?: string;

  constructor() {}

  ngOnInit(): void {}
}
