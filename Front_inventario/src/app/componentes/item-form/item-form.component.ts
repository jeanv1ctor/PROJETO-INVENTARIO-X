import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Item } from 'src/app/Models/Item';

@Component({
  selector: 'app-item-form',
  templateUrl: './item-form.component.html',
  styleUrls: ['./item-form.component.scss']
})
export class ItemFormComponent implements OnInit {

  @Output() onSubmit = new EventEmitter<Item>();
  
  itemForm!: FormGroup;
  constructor(){}

  ngOnInit(): void {
    this.itemForm = new FormGroup(
      {
        id: new FormControl(0),
        codPatrimonio: new FormControl(''),
        nome: new FormControl(''),
        modelo: new FormControl(''),
        descricao: new FormControl(''),
        quantidade: new FormControl(''),
        createdAt: new FormControl(new Date()),
      });
  }

  submit(){
    console.log(this.itemForm.value)

    this.onSubmit.emit(this.itemForm.value);
  }
}
