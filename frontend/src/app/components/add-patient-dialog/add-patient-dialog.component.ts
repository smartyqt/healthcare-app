import { Component } from '@angular/core';
import { MatDialogRef, MatDialogModule } from '@angular/material/dialog';
import { PatientService } from '../../services/patient.service';
import { Patient } from '../../services/patient.service';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-patient-dialog',
  templateUrl: './add-patient-dialog.component.html',
  styleUrls: ['./add-patient-dialog.component.css'],
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatDialogModule,
  ],
  standalone: true,
})
export class AddPatientDialogComponent {
  newPatient: Patient = {
    id: 0,
    name: '',
    dateOfBirth: '',
    gender: 'Female',
    contactInfo: '',
  };

  constructor(
    public dialogRef: MatDialogRef<AddPatientDialogComponent>,
    private patientService: PatientService
  ) {}

  addPatient(): void {
    if (
      !this.newPatient.name ||
      !this.newPatient.contactInfo ||
      !this.newPatient.dateOfBirth
    )
      return;

    this.patientService.addPatient(this.newPatient).subscribe((response) => {
      this.dialogRef.close(response); // ✅ Close the modal and return new patient data
    });
  }

  closeDialog(): void {
    this.dialogRef.close(); // Closes modal without adding
  }
}
