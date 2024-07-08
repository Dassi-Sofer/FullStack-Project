
import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  intercept(request: HttpRequest<any>, next: HttpHandler) {
    const token = sessionStorage.getItem('token');
    if(token == null)
    return next.handle(request);

    const t = JSON.parse(token??"null").token;
    if (t&&t != "null") {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${t}`
        }
      });
    }
    return next.handle(request);
  }
}

