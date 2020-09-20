import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Response } from '../models/response';

@Injectable({
  providedIn: 'root'
})
export class ApiclienteService {

  private url: string= 'https://localhost:44380/api/cliente';

  constructor(
    private _http: HttpClient
  ) {  }

  getClientes():Observable<Response>{
    return this._http.get<Response>(this.url);
  }

}
