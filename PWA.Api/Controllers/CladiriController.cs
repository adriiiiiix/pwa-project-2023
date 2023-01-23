using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PWA.Api.Data.Models;
using PWA.Api.Services;
using PWA.Shared.DTOs;

namespace PWA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CladiriController: ControllerBase
    {
        private readonly CladiriRepo _cladiriService;
        private readonly IConfiguration _config;

        public CladiriController(CladiriRepo cladiriService, IConfiguration config)
        {
            _cladiriService = cladiriService;
            _config = config;
        }

        [HttpPost("insert")]
        [Authorize]
        public async Task<ActionResult<CladireDto>> Insert([FromBody] CladireDto cladireDto)
        {
            try
            {
                Cladire cladire = new Cladire();
                cladire.Tip_Strada = cladireDto.Tip_Strada;
                cladire.Denumire_Strada = cladireDto.Denumire_Strada;
                cladire.Numar=cladireDto.Numar;
                cladire.Bloc=cladireDto.Bloc;
                cladire.Scara=cladireDto.Scara;
                cladire.Stadiul_Blocului = cladireDto.Stadiul_Blocului;
                cladire.Anul_Construirii = cladireDto.Anul_Construirii;
                cladire.Regim_Inaltime=cladire.Regim_Inaltime;
                cladire.Sistemul_constructiv = cladireDto.Sistemul_constructiv;
                cladire.Numar_apartamente = cladireDto.Numar_apartamente;
                cladire.Longitudine = cladireDto.Longitudine;
                cladire.Latitudine = cladireDto.Latitudine;

                await _cladiriService.AddCladireAsync(cladire);

                cladireDto.Id = cladire.Id;
                return Ok(cladireDto);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get")]
        [Authorize]
        public async Task<ActionResult<List<CladireDto>>> GetCladiri()
        {
            List<Cladire> cladire = await _cladiriService.GetAll();
            List<CladireDto> cladireDto = new(cladire.Count);
            foreach(Cladire cladire1 in cladire)
            {
                cladireDto.Add(new()
                {
                    Id = cladire1.Id,
                    Tip_Strada = cladire1.Tip_Strada,
                    Denumire_Strada = cladire1.Denumire_Strada,
                    Numar = cladire1.Numar,
                    Bloc = cladire1.Bloc,
                    Scara = cladire1.Scara,
                    Stadiul_Blocului = cladire1.Stadiul_Blocului,
                    Anul_Construirii = cladire1.Anul_Construirii,
                    Regim_Inaltime = cladire1.Regim_Inaltime,
                    Sistemul_constructiv = cladire1.Sistemul_constructiv,
                    Numar_apartamente = cladire1.Numar_apartamente,
                    Longitudine = cladire1.Longitudine,
                    Latitudine = cladire1.Latitudine
                });            
            }
            return Ok(cladireDto);
        }
    }
}
