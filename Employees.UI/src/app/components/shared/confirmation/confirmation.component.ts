import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-confirmation',
  templateUrl: './confirmation.component.html',
  styleUrls: ['./confirmation.component.css']
})
export class ConfirmationComponent implements OnInit {
  @Output() childConfirm: EventEmitter<boolean> = new EventEmitter();

  constructor(public activeModal: NgbActiveModal) { }

  ngOnInit() {
  }

  ClickNo() {
    // this.childConfirm.emit(false);
    this.close()
  }

  ClickYes() {
    this.childConfirm.emit(true);
    this.close();
  }


  close() {
    this.activeModal.close();
  }
}
