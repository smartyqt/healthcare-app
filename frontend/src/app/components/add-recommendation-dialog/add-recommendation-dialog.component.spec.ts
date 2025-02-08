import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRecommendationDialogComponent } from './add-recommendation-dialog.component';

describe('AddRecommendationDialogComponent', () => {
  let component: AddRecommendationDialogComponent;
  let fixture: ComponentFixture<AddRecommendationDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddRecommendationDialogComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddRecommendationDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
