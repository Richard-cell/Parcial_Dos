using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Credito: Entity<int>
    {
        public Credito() 
        {
        }
        public Credito(long cedula, float valorPrestamo, DateTime fechaPrestamo, int plazoPago)
        {
            Cedula = cedula;
            ValorPrestamo = valorPrestamo;
            FechaPrestamo = fechaPrestamo;
            PlazoPago = plazoPago;
            AlmacenarCuotas();
        }

        public long Cedula { get; private set; }
        public float ValorPrestamo { get; private set; }
        public DateTime FechaPrestamo { get; private set; }
        public int PlazoPago { get; private set; }
        public List<Cuota> Cuotas { get; set; }

        public float CalcularValorCuota() {
            return ValorPrestamo / PlazoPago;
        }

        public bool IsValidarPlazoPago() {
            return PlazoPago > 12 || PlazoPago<=0;
        }

        public string AlmacenarCuotas() {
            string response = "";
            Cuotas = new List<Cuota>();
            try
            {
                for (int i = 0; i < PlazoPago; i++)
                {
                    Cuota cuota = new Cuota(i,CalcularValorCuota(),FechaPrestamo.AddMonths(i));
                    Cuotas.Add(cuota);
                }
                response= "Cuota mensual de "+CalcularValorCuota();
            }
            catch (Exception)
            {
                response = "No se registraron las cuotas";
            }
            return response;
        }
    }
}
