import { CurrencyPurchase } from './models/currencyPurchase.model';
import { CurrencyQuotation } from './models/currencyQuotation.model';

export interface AppState {
  readonly currentPageId: string;
  readonly currencyCode: string;
  readonly currenciesQuotations: CurrencyQuotation[];
  readonly currencyQuotations: CurrencyQuotation;
  readonly currencyPurchase: CurrencyPurchase;
}
