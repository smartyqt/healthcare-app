import { Component, Inject, OnInit } from '@angular/core';
import {
  MatDialog,
  MatDialogModule,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { MatTableModule } from '@angular/material/table';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogActions, MatDialogContent } from '@angular/material/dialog';
import { MatChipsModule } from '@angular/material/chips';
import { CommonModule } from '@angular/common';
import { RecommendationService } from '../../services/recommendation.service';
import { AddRecommendationDialogComponent } from '../add-recommendation-dialog/add-recommendation-dialog.component';

@Component({
  selector: 'app-recommendations-dialog',
  standalone: true,
  imports: [
    CommonModule,
    MatDialogModule,
    MatTableModule,
    MatProgressSpinnerModule,
    MatButtonModule,
    MatChipsModule,
  ],
  templateUrl: './recommendations-dialog.component.html',
  styleUrls: ['./recommendations-dialog.component.css'],
})
export class RecommendationsDialogComponent implements OnInit {
  recommendations: any[] = [];
  loading = true;

  constructor(
    private dialog: MatDialog,
    public dialogRef: MatDialogRef<RecommendationsDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public patientId: number,
    private recommendationService: RecommendationService
  ) {}

  ngOnInit(): void {
    this.loadRecommendations();
  }

  loadRecommendations(): void {
    this.recommendationService.getRecommendations(this.patientId).subscribe(
      (data) => {
        this.recommendations = data;
        this.loading = false;
      },
      (error) => {
        console.error('Error fetching recommendations:', error);
        this.loading = false;
      }
    );
  }

  openAddRecommendationDialog(): void {
    const dialogRef = this.dialog.open(AddRecommendationDialogComponent, {
      width: '400px',
      data: { patientId: this.patientId },
    });

    dialogRef.afterClosed().subscribe((result: any) => {
      if (result) {
        this.loadRecommendations(); // Refresh the list after adding a recommendation
      }
    });
  }

  markCompleted(id: number): void {
    this.recommendationService.markAsCompleted(id).subscribe(() => {
      const recommendation = this.recommendations.find((r) => r.id === id);
      if (recommendation) {
        recommendation.isCompleted = true;
      }
    });
  }

  close(): void {
    this.dialogRef.close();
  }
}
