using Domain.Entidades;
using Domain.Repositorios;
using Infraestructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Repositorios
{
    public class CreditoRepository: GenericRepository<Credito>, ICreditoRepository
    {
        public CreditoRepository(IDbContext context): base(context) { }
    }
}
