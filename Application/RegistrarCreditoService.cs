using Domain.Contracts;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class RegistrarCreditoService
    {
        readonly IUnitOfWork _unitOfwork;
        public RegistrarCreditoService(IUnitOfWork unitOfWork)
        {
            _unitOfwork = unitOfWork;
        }


        public RegistrarCreditoResponse EjecutarServicio(RegistrarCreditoRequest request) {
            Credito credito = _unitOfwork.CreditoRepository.FindFirstOrDefault(x => x.Cedula == request.Cedula);
            if (credito==null) {
                credito = new Credito(
                    request.Cedula,
                    request.ValorPrestamo,
                    request.FechaPrestamo,
                    request.PlazoPago
                    );
                if (credito.IsValidarPlazoPago()==true)
                {
                    return new RegistrarCreditoResponse() { Mensaje = "El Plazo de pago debe ser menor o igual a 12" };
                }
                else {
                    _unitOfwork.CreditoRepository.Add(credito);
                    _unitOfwork.Commit();
                    return new RegistrarCreditoResponse() { Mensaje = $"Crédito registrado correctamente, Cuota mensual de {credito.CalcularValorCuota()}" };
                }   
            }
            else{
                return new RegistrarCreditoResponse() { Mensaje = $"El Credito ya existe" };
            }
            
        }



        public class RegistrarCreditoRequest
        {
            public long Cedula { get; set; }
            public float ValorPrestamo { get; set; }
            public DateTime FechaPrestamo { get; set; }
            public int PlazoPago { get; set; }
        }

        public class RegistrarCreditoResponse
        {
            public string Mensaje { get; set; }
        }
    }
}
