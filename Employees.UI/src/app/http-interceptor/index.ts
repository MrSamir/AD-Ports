import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthGuard } from './auth-guard';
import { ErrorInterceptor } from './error.interceptor';
import { WinAuthInterceptor } from './winauth-interceptor';

export const httpInterceptorProviders = [

  { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  { provide: HTTP_INTERCEPTORS, useClass: WinAuthInterceptor, multi: true },



];
