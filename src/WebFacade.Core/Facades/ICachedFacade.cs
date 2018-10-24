using System.Collections.Generic;
using System.Threading.Tasks;
using WebFacade.Core.Models;

namespace WebFacade.Core.Facades
{
    public interface ICachedFacade: IFacade
    {
        Task ClearAsync(string category, IEnumerable<string> uuids);
    }
}
