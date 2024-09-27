import {ApplicationConfig, isDevMode, provideZoneChangeDetection} from '@angular/core';
import {provideHttpClient} from "@angular/common/http";
import {provideRouter} from '@angular/router';
import {provideEffects} from "@ngrx/effects";
import {provideStore} from '@ngrx/store';
import {provideStoreDevtools} from "@ngrx/store-devtools";

import {routes} from '../routing/app.routes';
import {messagesReducers} from "../features/messages/application/messages.reducers";
import {deleteMessage$} from "../features/messages/application/usecases";

export const appConfig: ApplicationConfig = {
  providers: [
    // Core
    provideHttpClient(),
    provideRouter(routes),
    provideZoneChangeDetection({eventCoalescing: true}),

    // NgRx
    provideEffects({deleteMessage$}),
    provideStore({messages: messagesReducers}),
    provideStoreDevtools({
      maxAge: 41,
      logOnly: !isDevMode(),
      autoPause: true,
      trace: false,
      traceLimit: 75
    })
  ]
};
