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
import { MatDialogModule, MatDialog } from '@angular/material/dialog'; // ✅ Added MatDialogModule
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';

import { PatientService, Patient } from '../services/patient.service';
import { EditPatientDialogComponent } from '../components/edit-patient-dialog/edit-patient-dialog.component';
import { RecommendationsDialogComponent } from '../components/recommendations-dialog/recommendations-dialog.component';
import { AddPatientDialogComponent } from '../components/add-patient-dialog/add-patient-dialog.component'; // ✅ Import the missing AddPatientDialogComponent
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-patients',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatPaginatorModule,
    MatButtonModule,
    MatIconModule,
    MatSelectModule,
    MatDialogModule, // ✅ Ensure MatDialogModule is importe
  ],
  templateUrl: './patients.component.html',
  styleUrls: ['./patients.component.scss'],
})
export class PatientsComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = [
    'PatientID',
    'name',
    'dob',
    'gender',
    'contact',
    'actions',
  ];
  dataSource = new MatTableDataSource<Patient>([]);
  searchTerm: string = '';
  loggedInUser: string | null = null;

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
    public dialog: MatDialog,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadPatients();
    this.getLoggedInUser();

    if (!this.authService.isLoggedIn() || this.authService.isTokenExpired()) {
      this.logout();
    }
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  getLoggedInUser(): void {
    const token = this.authService.getToken();
    if (token) {
      try {
        const decoded: any = jwtDecode(token);
        this.loggedInUser = decoded.username || 'User';
      } catch (error) {
        console.error('Error decoding token:', error);
        this.logout();
      }
    }
  }

  openAddPatientDialog(): void {
    const dialogRef = this.dialog.open(AddPatientDialogComponent, {
      width: '400px',
    });

    dialogRef.afterClosed().subscribe((newPatient) => {
      if (newPatient) {
        // ✅ Add new patient directly to dataSource
        const updatedData = [...this.dataSource.data, newPatient];
        this.dataSource.data = updatedData;

        // ✅ Reset pagination (if needed)
        this.paginator.firstPage(); // Ensures the new patient is visible

        // ✅ Force Angular to detect changes (if UI doesn't update immediately)
        this.dataSource.paginator = this.paginator;
      }
    });
  }

  searchPatients(): void {
    const trimmedSearch = this.searchTerm.trim();

    if (!trimmedSearch) {
      this.loadPatients();
      return;
    }

    const isNumeric = /^\d+$/.test(trimmedSearch);

    console.log(
      '🔍 Searching for:',
      trimmedSearch,
      'as',
      isNumeric ? 'ID' : 'Name'
    );

    this.patientService.getPatients(trimmedSearch, isNumeric).subscribe(
      (data) => {
        console.log('✅ API Response:', data);

        this.dataSource = new MatTableDataSource<Patient>(data);
        this.dataSource.paginator = this.paginator;
      },
      (error) => {
        console.error('❌ Error searching patients:', error);
      }
    );
  }

  loadPatients(): void {
    this.patientService.getAllPatients().subscribe(
      (data) => {
        this.dataSource.data = data;
      },
      (error) => {
        console.error('Error fetching patients:', error);
      }
    );
  }

  viewRecommendations(patient: Patient) {
    this.dialog.open(RecommendationsDialogComponent, {
      width: '500px',
      data: patient.id,
    });
  }

  editPatient(patient: Patient): void {
    const dialogRef = this.dialog.open(EditPatientDialogComponent, {
      width: '400px',
      data: { patient },
    });

    dialogRef.afterClosed().subscribe((updatedPatient) => {
      if (updatedPatient) {
        this.patientService.updatePatient(updatedPatient).subscribe(() => {
          this.loadPatients();
        });
      }
    });
  }

  deletePatient(patient: Patient) {
    this.patientService.deletePatient(patient.id).subscribe(() => {
      this.loadPatients();
    });
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
