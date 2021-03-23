import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ToastrModule } from 'ngx-toastr';
import { LottieModule } from 'ngx-lottie';

import { NavigationComponent } from './components/molecules/navigation/navigation.component';
import { LinkComponent } from './components/atoms/link/link.component';
import { TitleComponent } from './components/atoms/title/title.component';
import { FooterComponent } from './components/molecules/footer/footer.component';
import { MainComponent } from './components/templates/main/main.component';

import { HomeComponent } from './components/organisms/home/home.component';
import { ForexComponent } from './components/organisms/quotation/quotation.component';
import { PurchaseComponent } from './components/organisms/purchase/purchase.component';
import { CardLinkComponent } from './components/molecules/card-link/card-link.component';
import { TabButtonComponent } from './components/atoms/tab-button/tab-button.component';

//ngrx
import { StoreModule } from '@ngrx/store';
import { pageIdReducer } from './reducers/pageId.reducer';
import {
  currenciesQuotationReducer,
  currencyQuotationReducer,
} from './reducers/currencyQuotation.reducer';
import { currencyCodeReducer } from './reducers/currencyCode.reducer';
import { currencyPurchaseReducer } from './reducers/currencyPurchase.reducer';

// Note we need a separate function as it's required
// by the AOT compiler.
export function playerFactory() {
  return import(/* webpackChunkName: 'lottie-web' */ 'lottie-web');
}

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    LinkComponent,
    TitleComponent,
    FooterComponent,
    MainComponent,
    HomeComponent,
    ForexComponent,
    PurchaseComponent,
    CardLinkComponent,
    TabButtonComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    ToastrModule.forRoot(),
    LottieModule.forRoot({ player: playerFactory }),
    StoreModule.forRoot({
      pageId: pageIdReducer,
      currencyCode: currencyCodeReducer,
      currenciesQuotation: currenciesQuotationReducer,
      currencyQuotation: currencyQuotationReducer,
      currencyPurchase: currencyPurchaseReducer,
    }),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
