using Examen.Data;
using Examen.Models.DTO;
using Examen.Models.Many_to_Many;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamControler : ControllerBase
    {
        private readonly ExamContext _examContext;
        public ExamControler(ExamContext examContext) {
            _examContext = examContext;
        }

        [HttpGet("/profesori")]
        public async Task<IActionResult> GetProfesori()
        {
            return Ok(await _examContext.Profesori.ToListAsync());
        }

        [HttpGet("/materii")]
        public async Task<IActionResult> GetMaterii()
        {
            return Ok(await _examContext.Materii.ToListAsync());
        }

        [HttpPost("/add_profesor")]
        public async Task<IActionResult> CreateProf(ProfDTO profesor)
        {
            var newProf = new Profesor
            {
                Id = Guid.NewGuid(),
                Nume = profesor.Nume,
                Prenume = profesor.Prenume,
                Varsta = profesor.Varsta,
                Tip = profesor.Tip
            };

            await _examContext.AddAsync(newProf);
            await _examContext.SaveChangesAsync();

            return Ok(newProf);
        }

        [HttpPost("/add_materie")]
        public async Task<IActionResult> CreateMat(MatDTO materie)
        {
            var newMaterie = new Materie
            {
                Id = Guid.NewGuid(),
                Denumire = materie.Denumire
            };

            await _examContext.AddAsync(newMaterie);
            await _examContext.SaveChangesAsync();

            return Ok(newMaterie);
        }

        [HttpPost("/asign_materie_to_profesor")]
        public async Task<IActionResult> AsignMatToProf(ModelsRelationDTO relation)
        {
            Profesor profById = await _examContext.Profesori.FirstOrDefaultAsync(prof => prof.Id.Equals(relation.ProfId));
            if(profById == null)
            {
                return BadRequest("Profesor does not exist");
            }

            Materie matById = await _examContext.Materii.FirstOrDefaultAsync(mat => mat.Id.Equals(relation.MatId));
            if(matById == null)
            {
                return BadRequest("Materie does not exist");
            }
            var NewRelation = new ModelsRelation
            {
                ProfId = relation.ProfId,
                MatId = relation.MatId
            };
            await _examContext.AddAsync(NewRelation);
            await _examContext.SaveChangesAsync();

            return Ok(NewRelation);
        }
    }
}
