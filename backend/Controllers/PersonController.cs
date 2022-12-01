using Microsoft.AspNetCore.Mvc;
using desafio_rsm.Repository;
using desafio_rsm.Models;
using desafio_rsm.Wrappers;
using desafio_rsm.Dtos;
using desafio_rsm.Helpers;
using System;

namespace desafio_rsm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repository;

        public PersonController(IPersonRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var people = await _repository.GetPeople();

            return people.Any() ? Ok(new Response<IEnumerable<Person>>(people)) : NoContent();
        }

        [HttpGet("Paginated")]
        public async Task<IActionResult> GetPeoplePaginated([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var people = await _repository.GetPeoplePaginated(validFilter);

            var totalRecords = await _repository.CountPeople();

            var paginatedResponse = PaginationHelpers.CreatePaginatedResponse<Person>(people, validFilter, totalRecords);

            return Ok(paginatedResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var person = await _repository.GetPerson(id);

            return person != null ? Ok(new Response<Person>(person)) : NotFound("Pessoa não encontrado");
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreatePersonDTO dto)
        {
            var person = new Person
            {
                Name = dto.Name,
                Document = dto.Document,
                ReferenceDate = dto.ReferenceDate
            };

            var addresses = new List<Address>();

            foreach (var dtoAddress in dto.Addresses)
            {
                var address = new Address
                {
                    Cep = dtoAddress.Cep,
                    Street = dtoAddress.Street,
                    Number = dtoAddress.Number,
                    Complement = dtoAddress.Complement,
                    Neighborhood = dtoAddress.Neighborhood,
                    City = dtoAddress.City,
                    Uf = dtoAddress.Uf
                };

                addresses.Append(address);
            }

            person.Addresses = addresses;

            _repository.CreatePerson(person);

            return await _repository.SaveChangesAsync() ? Ok("Pessoa adicionada com sucesso") : BadRequest("Erro ao salvar a pessoa");
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(long id, Person person)
        {
            var p = await _repository.GetPerson(id);

            if (p == null) return NotFound("Pessoa não encontrada");

            p.Name = person.Name ?? p.Name;
            p.Document = person.Document ?? p.Document;
            p.ReferenceDate = person.ReferenceDate != new DateTime() ? person.ReferenceDate : p.ReferenceDate;

            _repository.UpdatePerson(p);

            return await _repository.SaveChangesAsync() ? Ok("Pessoa editada com sucesso") : BadRequest("Erro ao editar a pessoa");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var p = await _repository.GetPerson(id);

            if (p == null) return NotFound("Pessoa não encontrada");

            _repository.DeletePerson(p);

            return await _repository.SaveChangesAsync() ? Ok("Pessoa deletada com sucesso") : BadRequest("Erro ao deletar a pessoa");
        }
    }
}