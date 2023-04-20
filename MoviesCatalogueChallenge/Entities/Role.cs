using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesCatalogueChallenge.Entities
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public virtual ICollection<User> Users { get; set; } = null!;// One-to-many relationship with User

    }
}
