// src/app/services/auth.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
// Import the module as a namespace
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  // Adjust the URL to match your backend address
  private apiUrl = 'http://localhost:5085/api/auth';

  constructor(private http: HttpClient) {}

  // Send login request to backend
  login(username: string, password: string): Observable<{ token: string }> {
    return this.http
      .post<{ token: string }>(`${this.apiUrl}/login`, { username, password })
      .pipe(
        tap((response) => {
          // Save the token on successful login
          localStorage.setItem('authToken', response.token);
        })
      );
  }

  // Get token from local storage
  getToken(): string | null {
    const token = localStorage.getItem('authToken');
    console.log('AuthService.getToken():', token); // Debug log
    return token;
  }

  // Logout by removing the token
  logout(): void {
    localStorage.removeItem('authToken');
  }

  // Optionally, you can add a method to check if the user is logged in
  isLoggedIn(): boolean {
    return !!this.getToken();
  }

  // Check if the JWT token is expired
  isTokenExpired(token?: string): boolean {
    token = token || this.getToken() || '';
    if (!token) {
      return true; // No token means it's expired (or not present)
    }
    try {
      // Decode the token using the nOh. So it doesn't want to do patient. amed import jwtDecode
      const decoded: any = jwtDecode(token);
      const exp = decoded.exp; // exp should be in seconds
      if (exp) {
        const now = Date.now() / 1000; // Convert current time to seconds
        return now > exp;
      }
      return false; // If no exp claim, consider it valid (or handle as needed)
    } catch (error) {
      console.error('Error checking token expiration', error);
      return true; // If an error occurs, treat the token as expired
    }
  }
}
