using System;
using System.ComponentModel.DataAnnotations;

namespace AdminPanelService.Data.Domain
{
    public class Reception
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
