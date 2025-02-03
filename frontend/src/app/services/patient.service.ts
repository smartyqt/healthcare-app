import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Patient {
  id: number;
  name: string;
  dateOfBirth: string;
  gender: string;
  contactInfo: string;
}

@Injectable({
  providedIn: 'root', // This makes the service available app-wide
})
export class PatientService {
  private apiUrl = 'http://localhost:5085/api/patients'; // Update this URL if needed

  constructor(private http: HttpClient) {}

  // GET: Fetch all patients
  getPatients(): Observable<Patient[]> {
    return this.http.get<Patient[]>(this.apiUrl);
  }

  // POST: Add a new patient
  addPatient(patient: Patient): Observable<Patient> {
    return this.http.post<Patient>(this.apiUrl, patient);
  }

  // PUT: Update an existing patient
  updatePatient(patient: Patient): Observable<Patient> {
    return this.http.put<Patient>(`${this.apiUrl}/${patient.id}`, patient);
  }

  // DELETE: Remove a patient by ID
  deletePatient(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
