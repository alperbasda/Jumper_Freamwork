using Jumper.Domain.MongoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper.Application.Features.ProjectDeclarations.Commands.UpdateCacheSettings
{
    public class UpdateCacheSettingsProjectDeclarationResponse
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool UseCache { get; set; }

        public CacheConfiguration? CacheConfiguration { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime? UpdatedTime { get; set; }
    }
}
