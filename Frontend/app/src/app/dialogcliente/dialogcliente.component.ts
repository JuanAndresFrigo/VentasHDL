import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Cliente } from '../models/cliente';
import { ApiclienteService } from '../services/apicliente.service';

@Component({
  selector: 'app-dialogcliente',
  templateUrl: './dialogcliente.component.html',
  styleUrls: ['./dialogcliente.component.scss']
})
export class DialogclienteComponent implements OnInit {

  public nombre:string;

  constructor(public dialogRef: MatDialogRef<DialogclienteComponent>,
              public apiCliente: ApiclienteService,
              public snackBar: MatSnackBar,
              @Inject(MAT_DIALOG_DATA) public cliente: Cliente) { 

                if (this.cliente !== null) {
                  this.nombre = cliente.nombre;
                }
              }

  ngOnInit(): void {
  }

  close(){
    this.dialogRef.close();
  }

  editCliente(){
    const cliente: Cliente={
      id: this.cliente.id,
      nombre: this.nombre
    };

    this.apiCliente.edit(cliente).subscribe(response=>{
      if (response.exito === 1) {
        this.dialogRef.close();
        this.snackBar.open('Cliete editado con exito', '', {duration:2000});
      }
    });
  }


  addCliente(){
    const cliente: Cliente={
      id:0,
      nombre: this.nombre
    };

    this.apiCliente.add(cliente).subscribe(response=>{
      if (response.exito === 1) {
        this.dialogRef.close();
        this.snackBar.open('Cliete insertado con exito', '', {duration:2000});
      }
    });
  }





}
