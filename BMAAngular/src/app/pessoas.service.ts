import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PessoaModel } from './pessoas/Pessoa.model';

@Injectable({
  providedIn: 'root'
})
export class PessoasService {
  httpOptions = {  
    headers: new HttpHeaders({  
      'Content-Type': 'application/json'  
    })  
  } 
  constructor(private http: HttpClient) { }

  listarPessoas(): Observable<any>{
    return this.http.get(environment.apiUrl);
  }

  listarIdosos(idoso: any): Observable<any>{
    return this.http.get(environment.apiUrl.concat('idoso?idoso=',idoso));
  }

  cadastrarPessoa(pessoa: PessoaModel): Observable<any>{
    return this.http.post(environment.apiUrl,pessoa);
  }

  atualizarPessoa(id: any, pessoa: PessoaModel):Observable<any>{
    return this.http.put(environment.apiUrl.concat(id),pessoa);
  }

  removerPessoa(id: any): Observable<any>{
    return this.http.delete(environment.apiUrl.concat(id));
  }
}
