namespace Logic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //[Table("TrackedAction")]
    public partial class TrackedAction
    {
        public Guid Id { get; set; }

        [Required]
        public string IdentificationDetail { get; set; }
        public bool HasBeenActedUpon { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedAt { get; set; }

        public string Remarks { get; set; }

        public string ApplicationPath { get; set; }
        public string ProcessName { get; set; }

        

    }
}
