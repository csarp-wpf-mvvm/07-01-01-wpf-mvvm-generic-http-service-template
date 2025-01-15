using Kreta.Backend.Repos;
using Kreta.Backend.Repos.Base;
using Kreta.Shared.Assamblers;
using Kreta.Shared.Dtos;
using Kreta.Shared.Models;
using Kreta.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Kreta.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        protected SubjectAssambler _assambler;
        protected ISubjectRepo _repo;

        public SubjectController(SubjectAssambler? assambler, ISubjectRepo? repo)
        {
            _assambler = assambler ?? throw new ArgumentNullException(nameof(assambler));
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var entity = (await _repo.FindByConditionAsync(s => s.Id == id)).FirstOrDefault();
            if (entity != null)
                return Ok(_assambler.ToDto(entity));
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubjectAsync()
        {
            var subjects = (await _repo.GetAllAsync()).ToList();
            return Ok(subjects.Select(s => _assambler.ToDto(s)));
        }

        [HttpPut()]
        public async Task<ActionResult> UpdateAsync(SubjectDto subjectDto)
        {
            Response response = response = await _repo.UpdateAsync(_assambler.ToModel(subjectDto));
            if (response.HasError)
            {
                Console.WriteLine(response.Error);
                response.ClearAndAddError("Az entitás adatainak módosítása nem sikerült!");
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            Response response = await _repo.DeleteAsync(id);
            if (response.HasError)
            {
                Console.WriteLine(response.Error);
                response.ClearAndAddError("A entitás adatainak törlése nem sikerült!");
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateAsync(SubjectDto subjectDto)
        {
            Response response = await _repo.CreateAsync(_assambler.ToModel(subjectDto));
            if (response.HasError)
            {
                Console.WriteLine(response.Error);
                response.ClearAndAddError("Új entitáts adatának felvétele nem sikerült!");
                return BadRequest(response);
            }
            else
                return Ok(response);
        }
    }
}
