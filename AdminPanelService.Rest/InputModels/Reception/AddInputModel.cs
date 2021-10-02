using System.ComponentModel.DataAnnotations;

namespace AdminPanelService.Rest.InputModels.Reception
{
    public class AddInputModel
    {
        /// <summary>
        /// Название приемной
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
