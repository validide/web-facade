using System.Collections.Generic;
using System.Threading.Tasks;
using WebFacade.Core.Models;

namespace WebFacade.Core.Facades
{
    public interface IFacade
    {
        Task<IEnumerable<Resource>> GetAsync(string category, IEnumerable<string> uuids);
        Task SetAsync(string category, IEnumerable<Resource> resources);
    }
}
