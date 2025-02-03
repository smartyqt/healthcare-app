import { HttpInterceptorFn } from '@angular/common/http';
import { HttpRequest, HttpHandlerFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from './auth.service';

export const TokenInterceptor: HttpInterceptorFn = (
  req: HttpRequest<any>,
  next: HttpHandlerFn
) => {
  console.log('TokenInterceptor triggered.');

  const authService = inject(AuthService);
  const token = authService.getToken();
  console.log('TokenInterceptor triggered. Token from storage:', token);

  if (token) {
    const clonedRequest = req.clone({
      setHeaders: { Authorization: `Bearer ${token}` },
    });
    console.log('Modified Request with Authorization:', clonedRequest);
    return next(clonedRequest);
  }

  console.log('No token found, sending original request');
  return next(req);
};
