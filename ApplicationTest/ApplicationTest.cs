using Application;
using Infraestructure;
using Infraestructure.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using static Application.RegistrarCreditoService;

namespace ApplicationTest
{
    public class Tests
    {
        EntidadContext _contextInMemory, _context;
        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<EntidadContext>().UseInMemoryDatabase("Bancoc").Options;
            var optionsSqlServer = new DbContextOptionsBuilder<EntidadContext>()
             .UseSqlServer("Server = (localdb)\\MSSQLLocalDB;Database=Bancoc;Trusted_Connection=True;MultipleActiveResultSets=true")
             .Options;

            _context = new EntidadContext(optionsSqlServer);
            _contextInMemory = new EntidadContext(optionsInMemory);
        }

        [Test]
        public void RegistrarCreditoInMemoryTest()
        {
            var request = new RegistrarCreditoRequest { Cedula=1065842658, FechaPrestamo= new DateTime(2019,05,05), ValorPrestamo=1200000, PlazoPago=12 };
            RegistrarCreditoService _service = new RegistrarCreditoService(new UnitOfWork(_contextInMemory));
            var response = _service.EjecutarServicio(request);
            Assert.AreEqual($"Crédito registrado correctamente, Cuota mensual de 100000", response.Mensaje);
        }

        [Test]
        public void ValidarCreditoExistenteTest()
        {
            var request = new RegistrarCreditoRequest { Cedula = 1065842658, FechaPrestamo = new DateTime(2019, 05, 05), ValorPrestamo = 1200000, PlazoPago = 12 };
            RegistrarCreditoService _service = new RegistrarCreditoService(new UnitOfWork(_contextInMemory));
            var response = _service.EjecutarServicio(request);

            var requestDos = new RegistrarCreditoRequest { Cedula = 1065842658, FechaPrestamo = new DateTime(2019, 06, 01), ValorPrestamo = 1300000, PlazoPago = 2 };
            RegistrarCreditoService _serviceDos = new RegistrarCreditoService(new UnitOfWork(_contextInMemory));
            var responseDos = _service.EjecutarServicio(requestDos);
            Assert.AreEqual($"El Credito ya existe", responseDos.Mensaje);
        }

        //[Test]
        //public void RegistrarCreditoInBdTest()
        //{
        //    var request = new RegistrarCreditoRequest { Cedula = 1065842658, FechaPrestamo = new DateTime(2019, 05, 05), ValorPrestamo = 1200000, PlazoPago = 12 };
        //    RegistrarCreditoService _service = new RegistrarCreditoService(new UnitOfWork(_context));
        //    var response = _service.EjecutarServicio(request);
        //    Assert.AreEqual($"Crédito registrado correctamente, Cuota mensual de 100000", response.Mensaje);
        //}
    }
}