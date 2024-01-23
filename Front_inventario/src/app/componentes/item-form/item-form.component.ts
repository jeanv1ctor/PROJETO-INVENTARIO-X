import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-item-form',
  templateUrl: './item-form.component.html',
  styleUrls: ['./item-form.component.scss']
})
export class ItemFormComponent implements OnInit {

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
    
  }
}
