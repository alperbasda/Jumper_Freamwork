using MediatR;

namespace Jumper.Application.Features.ProjectEntities.Queries.GetListByName;

public class GetListByNameProjectEntityQuery : IRequest<List<GetListByNameProjectEntityResponse>>
{
    public string SearchTerm { get; set; }

    private string _searchTermLower = "";

    public string SearchTermLower
    {
        get
        {
            if (string.IsNullOrEmpty(_searchTermLower))
            {
                _searchTermLower = SearchTerm.ToLower();
            }
            return _searchTermLower;
        }
    }
}
