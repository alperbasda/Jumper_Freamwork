using Core.Persistence.Dynamic;
using Core.Persistence.Requests;

namespace Jumper.Application.Base
{
    public class BaseDynamicQuery
    {
        public PageRequest PageRequest { get; set; } = new PageRequest()
        {
            PageSize = 10,
            PageIndex = 0,
        };

        public DynamicQuery? DynamicQuery { get; set; }
    }
}
