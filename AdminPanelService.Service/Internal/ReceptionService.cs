using AdminPanelService.Core.Reception;
using AdminPanelService.Data.Context;
using AdminPanelService.Data.Domain;
using AdminPanelService.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelService.Service.Internal
{
    internal class ReceptionService : IReceptionService
    {
        private readonly AdminPanelContext _adminPanelContext;

        public ReceptionService(AdminPanelContext adminPanelContext)
        {
            _adminPanelContext = adminPanelContext;
        }

        #region public methods

        public async Task<IReadOnlyList<ReceptionModel>> GetReceptions()
        {
          var receptions = await _adminPanelContext.Receptions
                .Where(i => i.IsActive)
                .Select(_ => new ReceptionModel
                {
                    Id = _.Id,
                    Name = _.Name,
                    CreateDate = _.CreateDate
                })
                .ToListAsync();

            return receptions;
        }

        public async Task<ReceptionModel> Add(string name)
        {
            if (await CheckForDuplicatesName(name))
                throw new InvalidOperationException($"Приемная с именем {name} уже существует");

            var reception = new Reception
            {
                Id = Guid.NewGuid(),
                Name = name,
                CreateDate = DateTime.Now,
                EditDate = DateTime.Now,
                IsActive = true
            };

            await _adminPanelContext.AddAsync(reception);
            await _adminPanelContext.SaveChangesAsync();

            return MapReceptionModelFromDomain(reception);
        }

        public async Task<ReceptionModel> Update(Guid Id, string name)
        {
            var reception = await _adminPanelContext.Receptions.FirstOrDefaultAsync(i => i.Id == Id);

            if (reception == null)
                throw new InvalidOperationException($"Приемная с идентификатором {Id} не найдена");

            if (await CheckForDuplicatesName(name))
                throw new InvalidOperationException($"Приемная с именем {name} уже существует");

            reception.Name = name;
            reception.EditDate = DateTime.Now;

            await _adminPanelContext.SaveChangesAsync();

            return MapReceptionModelFromDomain(reception);
        }

        public async Task<ReceptionModel> Delete(Guid Id)
        {
            var reception = await _adminPanelContext.Receptions.FirstOrDefaultAsync(i => i.Id == Id);

            if (reception == null)
                throw new InvalidOperationException($"Приемная с идентификатором {Id} не найдена");

            if (reception.IsActive == true)
            {
                reception.IsActive = false;
                reception.EditDate = DateTime.Now;

                await _adminPanelContext.SaveChangesAsync();
            }

            return MapReceptionModelFromDomain(reception);
        }

        #endregion

        #region private methods
        private ReceptionModel MapReceptionModelFromDomain(Reception reception)
        {
            return new ReceptionModel
            {
                Id = reception.Id,
                Name = reception.Name,
                CreateDate = reception.CreateDate
            };
        }

        private async Task<bool> CheckForDuplicatesName(string name)
        {
            return (await _adminPanelContext.Receptions
                .AnyAsync(i => i.Name.Trim().ToLower() == name.Trim().ToLower()));
        }

        #endregion
    }
}
