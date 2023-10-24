﻿using AutoMapper;
using Core.ApiHelpers.JwtHelper.Models;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Jumper.Application.Base;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetWithAllDetailById;
using Jumper.Application.Features.PropertyTypeDeclarations.Queries.GetAllFromCache;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Enums;
using MediatR;
using System.Linq.Expressions;

namespace Jumper.Application.Features.ProjectDeclaration.Rules;

public class ProjectDeclarationBusinessRules : BaseBusinessRules
{
    IProjectDeclarationDal _projectDeclarationDal;
    IMediator _mediator;
    IMapper _mapper;
    public ProjectDeclarationBusinessRules(IProjectDeclarationDal projectDeclarationDal, TokenParameters tokenParameters, IMediator mediator, IMapper mapper) : base(tokenParameters)
    {
        _projectDeclarationDal = projectDeclarationDal;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task ThrowExceptionIfSamaNameProjectExists(string name)
    {
        if (await _projectDeclarationDal.AnyAsync(w => w.Name == name && w.UserId == TokenParameters.UserId))
        {
            throw new BusinessException("Aynı isimde proje daha önce kayıt edilmiş.");
        }
    }

    public void FillDependencyEntityNames(GetWithAllDetailByIdProjectDeclarationResponse data)
    {
        foreach (var item in data.Relations)
        {
            item.DependedName = data.Entities.FirstOrDefault(w => w.Id == item.DependedId)?.Name ?? "";
            item.DependsOnName = data.Entities.FirstOrDefault(w => w.Id == item.DependsOnId)?.Name ?? "";
        }
    }

    public async Task FillPropertyTypes(GetWithAllDetailByIdProjectDeclarationResponse data)
    {
        var propertyTypes = await _mediator.Send(new GetAllFromCachePropertyTypeDeclarationQuery());
        data.PropertyTypes = _mapper.Map<List<PropertyTypeAggregation>>(propertyTypes);
    }

    public void FillEntityActionProperties(GetWithAllDetailByIdProjectDeclarationResponse data)
    {
        foreach (var item in data.Entities.SelectMany(w => w.Actions.SelectMany(w => w.Properties)))
        {
            var prop = data.Entities.FirstOrDefault(w => w.Properties.Any(q => q.Id == item.ProjectEntityPropertyId))?.Properties.First(w => w.Id == item.ProjectEntityPropertyId);
            item.PropertyName = prop?.Name ?? "";
            item.PropertyTypeCode = prop?.PropertyTypeCode ?? "";
        }
    }

    public void AddDefaultActions(GetWithAllDetailByIdProjectDeclarationResponse data)
    {
        foreach (var item in data.Entities)
        {
            if (item.Actions == null)
            {
                item.Actions = new List<ProjectDeclarationEntityActionAggregation>();
            }
            var allActionProperties = item.Properties.SelectMany(p => new[]
                {
                    new ProjectDeclarationEntityActionPropertyAggregation
                    {
                        ActionPropertyType = ActionPropertyType.Request,
                        ProjectEntityPropertyId = p.Id,
                        PropertyName = p.Name,
                        PropertyTypeCode = p.PropertyTypeCode,
                    },
                    new ProjectDeclarationEntityActionPropertyAggregation
                    {
                        ActionPropertyType = ActionPropertyType.Response,
                        ProjectEntityPropertyId = p.Id,
                        PropertyName = p.Name,
                        PropertyTypeCode = p.PropertyTypeCode,
                    }
                }).ToList();


            item.Actions.Add(new ProjectDeclarationEntityActionAggregation
            {
                CacheEnabled = false,
                LogEnabled = false,
                IsConstant = true,
                EntityAction = EntityAction.BulkCreate,
                Name = "BulkCreate",
                Properties = allActionProperties,
            });

            item.Actions.Add(new ProjectDeclarationEntityActionAggregation
            {
                CacheEnabled = false,
                LogEnabled = false,
                IsConstant = true,
                EntityAction = EntityAction.Create,
                Name = "Create",
                Properties = allActionProperties,
            });

            item.Actions.Add(new ProjectDeclarationEntityActionAggregation
            {
                CacheEnabled = false,
                LogEnabled = false,
                IsConstant = true,
                EntityAction = EntityAction.Update,
                Name = "Update",
                Properties = allActionProperties,
            });

            item.Actions.Add(new ProjectDeclarationEntityActionAggregation
            {
                CacheEnabled = false,
                LogEnabled = false,
                IsConstant = true,
                EntityAction = EntityAction.BulkUpdate,
                Name = "BulkUpdate",
                Properties = allActionProperties,
            });

            item.Actions.Add(new ProjectDeclarationEntityActionAggregation
            {
                CacheEnabled = false,
                LogEnabled = false,
                IsConstant = true,
                EntityAction = EntityAction.Delete,
                Name = "DeleteById",
                Properties = allActionProperties.Where(w => w.PropertyName == "Id").ToList(),
            });

            item.Actions.Add(new ProjectDeclarationEntityActionAggregation
            {
                CacheEnabled = false,
                LogEnabled = false,
                IsConstant = true,
                EntityAction = EntityAction.GetList,
                Name = "ListDynamic",
                Properties = allActionProperties.Where(w => w.ActionPropertyType == ActionPropertyType.Response).ToList(),
            });

            item.Actions.Add(new ProjectDeclarationEntityActionAggregation
            {
                CacheEnabled = false,
                LogEnabled = false,
                IsConstant = true,
                EntityAction = EntityAction.Get,
                Name = "GetById",
                Properties = allActionProperties.Where(w => w.ActionPropertyType == ActionPropertyType.Response || w.PropertyName == "Id").ToList(),
            });


        }
    }


    public Expression<Func<Domain.MongoEntities.ProjectDeclaration, bool>>? GetUserIdExpressionIfUserNotSuperUser()
    {
        return TokenParameters.IsSuperUser ? null : w => w.UserId == TokenParameters.UserId;
    }
}
