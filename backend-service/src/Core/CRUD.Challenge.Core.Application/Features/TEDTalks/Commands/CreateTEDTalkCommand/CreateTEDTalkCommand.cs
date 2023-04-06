namespace CRUD.Challenge.Core.Application.Features.TEDTalks.Commands.CreateTEDTalkCommand;

using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CRUD.Challenge.Core.Application.Wrappers;
using CRUD.Challenge.Core.Domain.Entities;
using MediatR;

public class CreateTEDTalkCommand : IRequest<Response<int>>
{
    public string Title { get; set; } = string.Empty;
    public DateTime DateOfEvent { get; set; }
    public string Speaker { get; set; } = string.Empty;
    public string auditoriumName { get; set; } = string.Empty;
    public int CityId { get; set; }
    //public City City { get; set; } = new City();

    public class CreateTEDTalkCommandHandler : IRequestHandler<CreateTEDTalkCommand, Response<int>>
    {

        private readonly IRepositoryAsync<TEDTalk> _respositoryAsync;
        private readonly IMapper _mapper;

        public CreateTEDTalkCommandHandler(IRepositoryAsync<TEDTalk> repositoryAsync, IMapper mapper)
        {
            this._respositoryAsync = repositoryAsync;
            this._mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateTEDTalkCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

