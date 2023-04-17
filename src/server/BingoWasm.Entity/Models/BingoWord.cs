using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoWasm.Entity.Models
{
    public class BingoWord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string RegistUser { get; set; }

        public DateTime RegistDateTime { get; set; }
    }
}
