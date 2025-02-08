import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import {
  RecommendationService,
  Recommendation,
} from '../../services/recommendation.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatDialogModule } from '@angular/material/dialog';

@Component({
  selector: 'app-add-recommendation-dialog',
  templateUrl: './add-recommendation-dialog.component.html',
  styleUrls: ['./add-recommendation-dialog.component.css'],
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatDialogModule,
  ],
})
export class AddRecommendationDialogComponent {
  recommendation: Recommendation;
  constructor(
    public dialogRef: MatDialogRef<AddRecommendationDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { patientId: number },
    private recommendationService: RecommendationService
  ) {
    this.recommendation = {
      id: 0,
      patientId: this.data.patientId,
      type: '',
      description: '',
      isCompleted: false,
    };
  }

  save(): void {
    if (!this.recommendation.type || !this.recommendation.description) {
      return;
    }

    this.recommendationService
      .addRecommendation(this.recommendation)
      .subscribe(() => {
        this.dialogRef.close(true); // Close modal and signal success
      });
  }

  close(): void {
    this.dialogRef.close();
  }
}
