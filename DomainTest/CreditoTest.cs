using Domain.Entidades;
using NUnit.Framework;

namespace DomainTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RegistroExitosoCuotas() {
            Credito credito = new Credito
            (
                1065842658,
                1200000,
                new System.DateTime(2019, 05, 05),
                12
            );
            Assert.AreEqual("Cuota mensual de 100000", credito.AlmacenarCuotas());
        }

        [Test]
        public void PlazoPagoMaximoIncorrecto()
        {
            Credito credito = new Credito
            (
                1065842658,
                1200000,
                new System.DateTime(2019, 05, 05),
                13
            );
            credito.AlmacenarCuotas();
            Assert.AreEqual(true, credito.IsValidarPlazoPago());
        }

        [Test]
        public void PlazoPagoMinimoIncorrecto()
        {
            Credito credito = new Credito
            (
                1065842658,
                1200000,
                new System.DateTime(2019, 05, 05),
                0
            );
            credito.AlmacenarCuotas();
            Assert.AreEqual(true, credito.IsValidarPlazoPago());
        }

        [Test]
        public void CalculoCuotaCorrecto()
        {
            Credito credito = new Credito
            (
                1065842658,
                1200000,
                new System.DateTime(2019, 05, 05),
                12
            );
            credito.AlmacenarCuotas();
            Assert.AreEqual(100000, credito.CalcularValorCuota());
        }

    }
}