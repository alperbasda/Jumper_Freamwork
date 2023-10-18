using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper.Application.Features.EntityPropertyDefinitions.Commands.DeleteById
{
    public class DeleteByIdEntityPropertyDefinitionCommand : IRequest<DeleteByIdEntityPropertyDefinitionResponse>
    {
        public Guid Id { get; set; }
    }
}
