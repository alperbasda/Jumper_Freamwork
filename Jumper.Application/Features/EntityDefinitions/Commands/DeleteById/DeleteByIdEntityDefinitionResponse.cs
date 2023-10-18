using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper.Application.Features.EntityDefinitions.Commands.DeleteById;

public class DeleteByIdEntityDefinitionResponse
{
    public Guid UserId { get; set; }

    public string Name { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }
}
