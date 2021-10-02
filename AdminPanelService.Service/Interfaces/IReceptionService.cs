using AdminPanelService.Core.Reception;
using System.Threading.Tasks;

namespace AdminPanelService.Service.Interfaces
{
    public interface IReceptionService
    {
        Task<ReceptionModel> Add(string name);
    }
}
