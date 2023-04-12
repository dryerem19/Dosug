namespace Dosug.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserEvent")]
    public partial class UserEvent
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }

        public virtual User User { get; set; }
    }
}
