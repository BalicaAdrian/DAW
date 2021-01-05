import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RemoveChannelComponent } from './remove-channel.component';

describe('RemoveChannelComponent', () => {
  let component: RemoveChannelComponent;
  let fixture: ComponentFixture<RemoveChannelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RemoveChannelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RemoveChannelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
