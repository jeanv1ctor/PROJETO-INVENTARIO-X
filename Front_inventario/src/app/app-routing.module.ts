import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastroItemComponent } from './pages/cadastro-item/cadastro-item.component';
import { HomeComponent } from './pages/home/home.component';

const routes: Routes = [
  {path: 'cadastro-item', component: CadastroItemComponent},
  {path: '', component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 

}
