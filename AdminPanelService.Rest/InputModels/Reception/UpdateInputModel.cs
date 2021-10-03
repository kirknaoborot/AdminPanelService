using System;
using System.ComponentModel.DataAnnotations;


namespace AdminPanelService.Rest.InputModels.Reception
{
    public class UpdateInputModel
    {
        /// <summary>
        /// Идентификатор приемной
        /// </summary>
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Название приемной
        /// </summary>
        [Required]
        [RegularExpression("^[А-Яа-я ]+$", ErrorMessage = "Имя должно состоять из Кириллицы")]
        public string Name { get; set; }
    }
}
