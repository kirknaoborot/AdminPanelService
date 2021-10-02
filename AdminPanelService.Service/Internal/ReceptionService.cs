using AdminPanelService.Core.Reception;
using AdminPanelService.Data.Context;
using AdminPanelService.Data.Domain;
using AdminPanelService.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace AdminPanelService.Service.Internal
{
    public class ReceptionService : IReceptionService
    {
        private readonly AdminPanelContext _adminPanelContext;

        public ReceptionService(AdminPanelContext adminPanelContext)
        {
            _adminPanelContext = adminPanelContext;
        }

        public async Task<ReceptionModel> Add(string name)
        {
            var reception = new Reception
            {
                Id = Guid.NewGuid(),
                Name = name,
                CreateDate = DateTime.Now
            };

            await _adminPanelContext.AddAsync(reception);
            await _adminPanelContext.SaveChangesAsync();

            return MapReceptionModelFromDomain(reception);
        }


        private ReceptionModel MapReceptionModelFromDomain(Reception reception)
        {
            return new ReceptionModel
            {
                Id = reception.Id,
                Name = reception.Name,
                CreateDate = reception.CreateDate
            };
        }
    }
}
