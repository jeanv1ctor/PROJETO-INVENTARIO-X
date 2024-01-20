import { Component, OnInit } from '@angular/core';
import { Item } from 'src/app/Models/Item';
import { ItemService } from 'src/app/services/item.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit{

  items: Item[] = [];
  itemGeral: Item[] = [];

  constructor(private itemService: ItemService){}

  ngOnInit(): void {
    
    this.itemService.GetItem().subscribe(data =>{
      const dados = data;

      dados.map(
        (item)=>{
          item.DataDeCriacao = new Date(item.DataDeCriacao!).toLocaleDateString('pt-BR')

        })
      

      this.items = dados;
      this.itemGeral = dados;
    });
  }

  Search(event : Event ){

    const target = event.target as HTMLInputElement;
    const value = target.value.toLocaleLowerCase();

    this.items = this.itemGeral.filter(item => {
      return item.nome.toLowerCase().includes(value);
    })
  }
}
