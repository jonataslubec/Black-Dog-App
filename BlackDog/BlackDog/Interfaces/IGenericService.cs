using BlackDog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisGPC.Portable.Interfaces
{
    public interface IGenericService
    {
        Task<List<PageModel>> GetAllPages();
      
    }

}
