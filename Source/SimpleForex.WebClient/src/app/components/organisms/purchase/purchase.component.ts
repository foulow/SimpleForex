import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CurrencyPurchase } from 'src/app/models/currencyPurchase.model';
import {
  CurrencyService,
  CurrencyServiceMock,
} from 'src/app/services/currencyService';

@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.scss'],
})
export class PurchaseComponent implements OnInit {
  form: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private _currencyService: CurrencyServiceMock,
    private _toastr: ToastrService
  ) {
    this.form = this.formBuilder.group({
      code: [
        '',
        Validators.required,
        Validators.minLength(7),
        Validators.maxLength(7),
      ],
      userId: [
        '',
        Validators.required,
        Validators.minLength(5),
        Validators.maxLength(25),
      ],
      amount: ['', Validators.required, Validators.max(300)],
    });
  }

  ngOnInit(): void {}

  purchaseCurrency() {
    const currencyPurchase: CurrencyPurchase = {
      amount: this.form.value.amount,
      userId: this.form.value.userId,
      currencyId: this.form.value.currencyId,
    };

    this._currencyService.postCurrencyPurchase(currencyPurchase).subscribe(
      (event) => {
        if (event.valueOf())
          this._toastr.success(
            'Transacción completada',
            'Transacción realizada exitosamente.'
          );
        this.form.reset();
      },
      (error) => {
        this._toastr.error(
          'Opps.. ocurrió un error',
          'Vuelva a intentarlo más tarde.'
        );
        console.error(error);
      }
    );
  }
}
