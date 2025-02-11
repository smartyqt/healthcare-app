import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecommendationsDialogComponent } from './recommendations-dialog.component';

describe('RecommendationsDialogComponent', () => {
  let component: RecommendationsDialogComponent;
  let fixture: ComponentFixture<RecommendationsDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RecommendationsDialogComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RecommendationsDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
