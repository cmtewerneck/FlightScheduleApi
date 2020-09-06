using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FlightScheduleApi.Api.ViewModels;
using FlightScheduleApi.Business.Interfaces;
using AutoMapper;
using FlightScheduleApi.Business.Models;
using Microsoft.AspNetCore.Authorization;
using FlightScheduleApi.Api.Extensions;
using FlightScheduleApi.Api.Controllers;

namespace FlightScheduleApi.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/aeronaves")]
    public class AeronavesController : MainController
    {
        private readonly IAeronaveRepository _aeronaveRepository;
        private readonly IAeronaveServices _aeronaveService;
        private readonly IMapper _mapper;

        public AeronavesController(IAeronaveRepository aeronaveRepository,
                                      IMapper mapper,
                                      IAeronaveServices aeronaveService,
                                      INotificador notificador, IUser user) : base(notificador, user)
        {
            _aeronaveRepository = aeronaveRepository;
            _mapper = mapper;
            _aeronaveService = aeronaveService;
        }

        [ClaimsAuthorize("Aeronave", "Atualizar")]
        [HttpGet]
        public async Task<IEnumerable<AeronaveViewModel>> ObterTodas()
        {
            return _mapper.Map<IEnumerable<AeronaveViewModel>>(await _aeronaveRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AeronaveViewModel>> ObterPorId(Guid id)
        {
            var aeronave = await ObterAeronave(id);

            if (aeronave == null) return NotFound();

            return aeronave;
        }

        private async Task<AeronaveViewModel> ObterAeronave(Guid id)
        {
            return _mapper.Map<AeronaveViewModel>(await _aeronaveRepository.ObterAeronave(id));
        }

        [ClaimsAuthorize("Aeronave", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<AeronaveViewModel>> Adicionar(AeronaveViewModel aeronaveViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _aeronaveService.Adicionar(_mapper.Map<Aeronave>(aeronaveViewModel));

            return CustomResponse(aeronaveViewModel);
        }

        [ClaimsAuthorize("Aeronave", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AeronaveViewModel>> Atualizar(Guid id, AeronaveViewModel aeronaveViewModel)
        {
            if (id != aeronaveViewModel.Id)
            {
                NotificarErro("O id informado é diferente do id da requisição.");
                return CustomResponse(aeronaveViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _aeronaveService.Atualizar(_mapper.Map<Aeronave>(aeronaveViewModel));

            return CustomResponse(aeronaveViewModel);
        }

        [ClaimsAuthorize("Aeronave", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AeronaveViewModel>> Excluir(Guid id)
        {
            var aeronaveViewModel = await ObterAeronave(id);

            if (aeronaveViewModel == null)
            {
                NotificarErro("O id da aeronave não foi encontrado.");
                return CustomResponse(aeronaveViewModel);
            }

            await _aeronaveService.Remover(id);

            return CustomResponse(aeronaveViewModel);
        }
    }
}
