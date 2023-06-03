using CamelDev.CamelApi.Api.AutoMapper;
using CamelDev.CamelApi.Api.DTO;
using CamelDev.CamelApi.Api.Filters;
using CamelDev.CamelApi.DAO.Context;
using CamelDev.CamelApi.Domain_;
using CamelDev.CamelApi.Repositorios.Ef;
using CamelDev.Comum.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace CamelDev.CamelApi.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/alunos")]
    public class AlunosController : ApiController
    {
        private IRepositorioCamelDev<Aluno, int> _repositorioAlunos = new RepositorioAlunos(new CamelApiDbContext());

        public IHttpActionResult Get()
        {
            List<Aluno> alunos = _repositorioAlunos.Selecionar();
            List<AlunoDTO> alunoDTOs = AutoMapperManager.Instance.Mapper.Map<List<Aluno>, List<AlunoDTO>>(alunos);
            return Ok(alunoDTOs);
        }

        public IHttpActionResult Get(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            Aluno aluno = _repositorioAlunos.SelecionarPorId(id.Value);
            if (aluno == null)
            {
                return NotFound();
            }

            AlunoDTO alunoDTO = AutoMapperManager.Instance.Mapper.Map<Aluno, AlunoDTO>(aluno);
            return Content(HttpStatusCode.OK, alunoDTO);
        }

        [Route("por-nome/{nomeAluno}")]
        public IHttpActionResult Get(string nomeAluno)
        {
            List<Aluno> alunos = _repositorioAlunos.Selecionar(s => s.Name.ToLower().Contains(nomeAluno.ToLower()));
            List<AlunoDTO> dtos = AutoMapperManager.Instance.Mapper.Map<List<Aluno>, List<AlunoDTO>>(alunos);            
            return Ok(dtos);
        }

        [ApplyModelValidation]
        public IHttpActionResult Post([FromBody] AlunoDTO alunoDTO)
        {
                try
                {
                    Aluno aluno = AutoMapperManager.Instance.Mapper.Map<AlunoDTO, Aluno>(alunoDTO);
                    _repositorioAlunos.Inserir(aluno);
                    return Created($"{Request.RequestUri}/{aluno.Id}", aluno);
                }
                catch (Exception ex)
                {

                    return InternalServerError(ex);
                }            
        }

        [ApplyModelValidation]
        public IHttpActionResult Put(int? id, [FromBody] AlunoDTO alunoDTO)
        {
                try
                {
                    if (!id.HasValue)
                    {
                        return BadRequest();
                    }

                    Aluno aluno = AutoMapperManager.Instance.Mapper.Map<AlunoDTO, Aluno>(alunoDTO);
                    aluno.Id = id.Value;
                    _repositorioAlunos.Atualizar(aluno);
                    return Ok();
                }
                catch (Exception ex)
                {

                    return InternalServerError(ex);
                }
        }

        public IHttpActionResult Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    return BadRequest();
                }

                Aluno aluno = _repositorioAlunos.SelecionarPorId(id.Value);
                if (aluno == null)
                {
                    return NotFound();
                }

                _repositorioAlunos.ExcuirPorId(id.Value);
                return Ok();
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

    }
}
