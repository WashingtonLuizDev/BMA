import { Component, OnInit } from '@angular/core';
import { PessoasService } from '../pessoas.service';
import { PessoaModel } from './Pessoa.model';

@Component({
  selector: 'app-pessoas',
  templateUrl: './pessoas.component.html',
  styleUrls: ['./pessoas.component.css']
})
export class PessoasComponent implements OnInit {

  pessoa: PessoaModel = new PessoaModel();
  pessoas: Array<any> = new Array();

  constructor(private pessoasService: PessoasService) { }

  ngOnInit(){
    this.listarPessoas();
  }

  cadastrar(){
    this.pessoasService.cadastrarPessoa(this.pessoa).subscribe(pessoa =>{
      this.pessoa = new PessoaModel();
      this.listarPessoas();
    },err => {
      console.log('Erro ao cadastrar a pessoa', err);
    })
  }

  atualizar(id: number){
    this.pessoasService.atualizarPessoa(id, this.pessoa).subscribe( pessoa => {
      this.pessoa = new PessoaModel();
      this.listarPessoas();
    }, err => {
      console.log('Erro ao atualizar a pessoa', err);
    })
  }

  remover(id: number){
    this.pessoasService.removerPessoa(id).subscribe( pessoa =>{
     this.pessoa = new PessoaModel();
     this.listarPessoas();
    }, err => {
      console.log('Erro ao deletar a pessoa.', err);
    })
  }

  listarPessoas(){
    this.pessoasService.listarPessoas().subscribe(pessoas =>{
      this.pessoas = pessoas;
    }, err =>{
      console.log('Erro ao listar as pessoas',err);
    })
  }

  listarIdosos(idoso: boolean){
    this.pessoasService.listarIdosos(idoso).subscribe(pessoas =>{
      this.pessoas = pessoas;
    }, err =>{
      console.log('Erro ao listar as pessoas',err);
    })
  }

  colors = [{ idoso: true, color: "red" }, { idoso: false, color: "black" }]

  colorirGradeIdoso(idoso: boolean) {
    return this.colors.filter(item => item.idoso === idoso)[0].color 
}

}
