import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { PatientService, Patient } from '../services/patient.service'; // Import service
import { FormsModule } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { EditPatientDialogComponent } from '../components/edit-patient-dialog/edit-patient-dialog.component';

@Component({
  selector: 'app-patients',
  standalone: true, // Indicates this is a standalone component
  imports: [
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatPaginatorModule,
    MatButtonModule,
    MatIconModule,
    MatSelectModule,
    FormsModule,
  ],
  templateUrl: './patients.component.html',
  styleUrls: ['./patients.component.css'],
})
export class PatientsComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['name', 'dob', 'gender', 'contact', 'actions'];
  dataSource = new MatTableDataSource<Patient>([]);
  newPatient: Patient = {
    id: 0,
    name: '',
    dateOfBirth: '',
    gender: 'Female',
    contactInfo: '0',
  };
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private patientService: PatientService,
    public dialog: MatDialog
  ) {}
  ngOnInit(): void {
    this.loadPatients();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  // Fetch patients from API
  loadPatients(): void {
    this.patientService.getPatients().subscribe(
      (data) => {
        this.dataSource.data = data;
      },
      (error) => {
        console.error('Error fetching patients:', error);
      }
    );
  }

  // Filtering Functionality
  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  // Placeholder Methods for Actions
  viewRecommendations(patient: Patient) {
    console.log('View recommendations for:', patient.name);
  }

  addPatient(): void {
    if (
      !this.newPatient.name ||
      !this.newPatient.contactInfo ||
      !this.newPatient.dateOfBirth ||
      !this.newPatient.gender
    ) {
      return;
    }
    this.patientService.addPatient(this.newPatient).subscribe((newPatient) => {
      this.dataSource.data = [...this.dataSource.data, newPatient];
      this.newPatient = {
        id: 0,
        name: '',
        dateOfBirth: '',
        gender: '',
        contactInfo: '',
      };
    });
  }

  editPatient(patient: any): void {
    const dialogRef = this.dialog.open(EditPatientDialogComponent, {
      width: '400px',
      data: { patient }, // Pass selected patient to dialog
    });

    dialogRef.afterClosed().subscribe((updatedPatient) => {
      if (updatedPatient) {
        this.patientService.updatePatient(updatedPatient).subscribe(() => {
          this.loadPatients(); // Refresh table after update
        });
      }
    });
  }

  deletePatient(patient: Patient) {
    console.log('Delete patient:', patient.name);
  }
}
