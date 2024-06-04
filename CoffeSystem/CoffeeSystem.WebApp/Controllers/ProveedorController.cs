using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Newtonsoft.Json;
using CoffeeSystem.BLL.Interfaces;
using CoffeeSystem.Entity;
using CoffeeSystem.WebApp.Models.ViewModels;
using CoffeeSystem.WebApp.Utilidades;


namespace CoffeeSystem.WebApp.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProveedorService _proveedorServicio;
        
        public ProveedorController(IProveedorService proveedorServicio, IMapper mapper)
        {
            _mapper = mapper;
            _proveedorServicio = proveedorServicio;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<VMProveedor> vmProveedorLista = _mapper.Map<List<VMProveedor>>(await _proveedorServicio.Lista());
            return StatusCode(StatusCodes.Status200OK, new { data = vmProveedorLista });
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromForm] string modelo)
        {
            GenericResponse<VMProveedor> gResponse = new GenericResponse<VMProveedor>();

            try
            {
                VMProveedor vmProveedor = JsonConvert.DeserializeObject<VMProveedor>(modelo);

                Proveedor proveedorCreado = await _proveedorServicio.Registrar(_mapper.Map<Proveedor>(vmProveedor));                

                vmProveedor = _mapper.Map<VMProveedor>(proveedorCreado);

                gResponse.Estado = true;
                gResponse.Objeto = vmProveedor;
            }
            catch (Exception ex)
            {
                gResponse.Estado = false;
                gResponse.Mensaje = ex.Message;
            }

            return StatusCode(StatusCodes.Status200OK, gResponse);

        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromForm] string modelo)
        {
            GenericResponse<VMProveedor> gResponse = new GenericResponse<VMProveedor>();

            try
            {
                VMProveedor vmProveedor = JsonConvert.DeserializeObject<VMProveedor>(modelo);

                Proveedor proveedorEditado = await _proveedorServicio.Editar(_mapper.Map<Proveedor>(vmProveedor));

                vmProveedor = _mapper.Map<VMProveedor>(proveedorEditado);

                gResponse.Estado = true;
                gResponse.Objeto = vmProveedor;
            }
            catch (Exception ex)
            {
                gResponse.Estado = false;
                gResponse.Mensaje = ex.Message;
            }

            return StatusCode(StatusCodes.Status200OK, gResponse);

        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int IdProveedor)
        {
            GenericResponse<string> gResponse = new GenericResponse<string>();

            try
            {
                gResponse.Estado = await _proveedorServicio.Eliminar(IdProveedor);
            }
            catch (Exception ex)
            {
                gResponse.Estado = false;
                gResponse.Mensaje = ex.Message;
            }

            return StatusCode(StatusCodes.Status200OK, gResponse);
        }

    }
}
