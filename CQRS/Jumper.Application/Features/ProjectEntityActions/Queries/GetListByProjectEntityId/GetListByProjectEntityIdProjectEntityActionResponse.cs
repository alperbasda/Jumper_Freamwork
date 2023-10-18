﻿using Jumper.Domain.Enums;

namespace Jumper.Application.Features.ProjectEntityActions.Queries.GetListByProjectEntityId;

public class GetListByProjectEntityIdProjectEntityActionResponse
{
    public Guid Id { get; set; }

    public Guid ProjectEntityId { get; set; }

    public string RequestProperties { get; set; }

    public string ResponseProperties { get; set; }

    public string Name { get; set; }

    public bool CacheEnabled { get; set; }

    public bool LogEnabled { get; set; }

    public EntityAction EntityAction { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public bool IsConstant { get; set; }
}

