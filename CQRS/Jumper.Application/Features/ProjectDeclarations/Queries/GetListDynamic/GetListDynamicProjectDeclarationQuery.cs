﻿using Core.Persistence.Models.Responses;
using Jumper.Application.Base;
using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Queries.GetListDynamic
{
    public class GetListDynamicProjectDeclarationQuery : BaseDynamicQuery, IRequest<ListModel<GetListDynamicProjectDeclarationQueryResponse>>
    {
    }
}
