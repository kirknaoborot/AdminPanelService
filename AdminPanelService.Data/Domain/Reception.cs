using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanelService.Data.Domain
{
    [Table("RECEPTIONS")]
    public class Reception
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Column("NAME")]
        public string Name { get; set; }
        [Column("CREATE_DATE")]
        public DateTime CreateDate { get; set; }
        [Column("EDIT_DATE")]
        public DateTime EditDate { get; set; }
        [Column("IS_ACTIVE")]
        public bool IsActive { get; set; }
    }
}
