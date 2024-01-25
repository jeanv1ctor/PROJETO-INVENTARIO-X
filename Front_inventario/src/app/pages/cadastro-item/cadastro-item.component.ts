import { Component } from '@angular/core';
import { Route, Router } from '@angular/router';
import { Item } from 'src/app/Models/Item';
import { ItemService } from 'src/app/services/item.service';

@Component({
  selector: 'app-cadastro-item',
  templateUrl: './cadastro-item.component.html',
  styleUrls: ['./cadastro-item.component.scss']
})
export class CadastroItemComponent {

  constructor(private itemService: ItemService, private router: Router){

  }

  createItem(item: Item){

    this.itemService.PostItem(item).subscribe((data) =>{
      this.router.navigate(['/']);
    });
  }
}
