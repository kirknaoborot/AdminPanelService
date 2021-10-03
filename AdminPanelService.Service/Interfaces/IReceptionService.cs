using AdminPanelService.Core.Reception;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminPanelService.Service.Interfaces
{
    public interface IReceptionService
    {
        Task<ReceptionModel> Add(string name);

        Task<IReadOnlyList<ReceptionModel>> GetReceptions();

        Task<ReceptionModel> Update(Guid Id, string name);

        Task<ReceptionModel> Delete(Guid Id);
    }
}
