﻿using Bit.Domain.Common.Dto.Response.Generic;
using Bit.Synchronizer.Application.Licence.Querys;
using Bit.Synchronizer.Domain.Common.Dto;
using Bit.Synchronizer.Domain.Common.Interfaces.Repositories;
using Bit.Synchronizer.Domain.Common.Interfaces.Services;
using Bit.Synchronizer.Domain.Common.QuerysMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Bit.Synchronizer.Application.Licence.Handlers
{
    public class GetAllLicencesHandler : IRequestHandler<GetAllLicencesQuery, PagedResult<LicenceDto>>
    {
        private readonly ILicenceRepository _licenceRepository;
        private readonly IMSMonitorService _mSMonitorService;        

        public GetAllLicencesHandler(
            ILicenceRepository licenceRepository,
            IMSMonitorService mSMonitorService)
        {            
            _licenceRepository = licenceRepository;
            _mSMonitorService = mSMonitorService;
        }

        public async Task<PagedResult<LicenceDto>> Handle(GetAllLicencesQuery request, CancellationToken cancellationToken)
        {
            await _mSMonitorService.registerLogInformation("Inicia ejecución para listar licencias", data: JsonSerializer.Serialize(request) + "", resourceName: nameof(GetAllLicencesHandler));

            var result = await _licenceRepository.GetByAllAsync(new PagedQuery()
            {
                Filter = request.Filter,
                OrderBy = request.OrderBy,
                Page = request.Page,
                Results = request.Results,
                SortOrder = request.SortOrder
            });

            await _mSMonitorService.registerLogInformation("Se realiza listar licencias correctamente", data: JsonSerializer.Serialize(request) + "", resourceName: nameof(GetAllLicencesHandler));            

            return result;
        }
    }
}
