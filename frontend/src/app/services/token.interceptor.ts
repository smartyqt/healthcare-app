import { HttpInterceptorFn } from '@angular/common/http';
import { HttpRequest, HttpHandlerFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from './auth.service';

export const TokenInterceptor: HttpInterceptorFn = (
  req: HttpRequest<any>,
  next: HttpHandlerFn
) => {
  const authService = inject(AuthService);
  const token = authService.getToken();
  const csrfToken = authService.getCsrfToken();

  let headers = req.headers;

  if (token) {
    headers = headers.set('Authorization', `Bearer ${token}`);
  }

  // ✅ Add CSRF Token if available (for state-changing requests)
  if (csrfToken && req.method !== 'GET') {
    headers = headers.set('X-XSRF-TOKEN', csrfToken);
  }

  const clonedRequest = req.clone({ headers });
  return next(clonedRequest);
};
