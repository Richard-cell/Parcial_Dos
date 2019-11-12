using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Cuota: Entity<int>
    {
        public int MesCuota { get; private set; }
        public float ValorCuota { get; private set; }
        public DateTime FechaPagoCuota { get; private set; }
        public int CreditoId { get; private set; }

        public Cuota(int mesCuota, float valorCuota, DateTime fechaPagoCuota)
        {
            MesCuota = mesCuota;
            ValorCuota = valorCuota;
            FechaPagoCuota = fechaPagoCuota;
        }
    }
}
