using AdminPanelService.Core.Reception;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminPanelService.Service.Interfaces
{
    public interface IReceptionService
    {
        Task<ReceptionModel> Add(string name);

        Task<IEnumerable<ReceptionModel>> GetReceptions();
    }
}
