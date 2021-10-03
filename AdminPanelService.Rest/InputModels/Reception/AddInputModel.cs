using System.ComponentModel.DataAnnotations;

namespace AdminPanelService.Rest.InputModels.Reception
{
    public class AddInputModel
    {
        /// <summary>
        /// Название приемной
        /// </summary>
        [Required]
        [RegularExpression("^[А-Яа-я ]+$", ErrorMessage = "Имя должно состоять из Кириллицы")]
        public string Name { get; set; }
    }
}
