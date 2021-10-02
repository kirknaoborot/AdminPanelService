using System;

namespace AdminPanelService.Core.Reception
{
    public class ReceptionModel
    {
        /// <summary>
        /// Идентификатор приемной
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Название приемной
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Дата добавления приемной
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
