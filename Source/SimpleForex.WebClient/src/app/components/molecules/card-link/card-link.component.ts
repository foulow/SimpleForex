import { Component, Input, OnInit } from '@angular/core';
import { AnimationItem } from 'lottie-web';
import { AnimationOptions } from 'ngx-lottie';

@Component({
  selector: 'app-card-link',
  templateUrl: './card-link.component.html',
  styleUrls: ['./card-link.component.scss'],
})
export class CardLinkComponent implements OnInit {
  options: AnimationOptions | null = null;
  animationItem?: AnimationItem;

  constructor() {}

  @Input() imageVariant: string | null = null;
  @Input() width: string | null = null;
  @Input() height: string | null = null;
  @Input() variant?: string;
  @Input() cardVariant?: string;
  @Input() url?: string;
  @Input() title?: string;
  @Input() text?: string;
  @Input() animation?: string;

  ngOnInit(): void {
    this.options = {
      path: this.getLottieAnimation(),
      autoplay: true,
      loop: true,
    };
  }

  animationCreated(animationItem: AnimationItem): void {
    this.animationItem = animationItem;
  }

  getCardVariant() {
    return this.cardVariant ? this.cardVariant : '';
  }

  getLottieAnimation() {
    return this.animation;
  }
}
