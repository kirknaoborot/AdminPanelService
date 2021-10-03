using System;
using System.ComponentModel.DataAnnotations;

namespace AdminPanelService.Rest.InputModels.Reception
{
    public class DeleteInputModel
    {
        /// <summary>
        /// Идентификатор приемной
        /// </summary>
        [Required]
        public Guid Id { get; set; }
    }
}
