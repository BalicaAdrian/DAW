import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SetChannelComponent } from './set-channel.component';

describe('SetChannelComponent', () => {
  let component: SetChannelComponent;
  let fixture: ComponentFixture<SetChannelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SetChannelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SetChannelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
