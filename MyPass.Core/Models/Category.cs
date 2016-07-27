using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPass.Core.Models
{
    public class Category
    {

        public Category()
        {
            Entries = new Collection<Entry>();

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Entry> Entries { get; set; }

        [Required]
        public Guid CreatedById { get; set; }
        public User CreatedBy { get; set; }

        public Guid? ModifiedById { get; set; }
        public User ModifiedBy { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public bool Deleted { get; set; }

    }
}
