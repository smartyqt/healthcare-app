import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Recommendation {
  id: number;
  patientId: number;
  type: string;
  description: string;
  isCompleted: boolean;
}

@Injectable({
  providedIn: 'root',
})
export class RecommendationService {
  private apiUrl = 'http://localhost:5085/api/recommendations'; // ✅ Update this to match your backend

  constructor(private http: HttpClient) {}

  // ✅ Fetch recommendations for a specific patient
  getRecommendations(patientId: number): Observable<Recommendation[]> {
    return this.http.get<Recommendation[]>(
      `${this.apiUrl}/patient/${patientId}`
    );
  }

  // ✅ Mark a recommendation as completed
  markAsCompleted(id: number): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}/complete`, {});
  }
  addRecommendation(
    recommendation: Recommendation
  ): Observable<Recommendation> {
    return this.http.post<Recommendation>(`${this.apiUrl}`, recommendation);
  }
}
