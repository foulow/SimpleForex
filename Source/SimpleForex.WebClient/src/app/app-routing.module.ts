import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/organisms/home/home.component';
import { ForexComponent } from './components/organisms/quotation/quotation.component';
import { PurchaseComponent } from './components/organisms/purchase/purchase.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'cotizaciones', component: ForexComponent },
  { path: 'compra', component: PurchaseComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
