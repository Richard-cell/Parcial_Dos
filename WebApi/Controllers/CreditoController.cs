using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Domain.Contracts;
using Infraestructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Application.RegistrarCreditoService;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditoController : ControllerBase
    {
        readonly EntidadContext _context;
        readonly IUnitOfWork _unitOfWork;

        public CreditoController(EntidadContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public ActionResult<RegistrarCreditoResponse> Post(RegistrarCreditoRequest request)
        {
            RegistrarCreditoService _service = new RegistrarCreditoService(_unitOfWork);
            RegistrarCreditoResponse respuestaServicio = _service.EjecutarServicio(request);
            return Ok(respuestaServicio);
        }
    }
}