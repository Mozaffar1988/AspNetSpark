using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetSpark.Models
{
    public class Car
    {
        [Key]
        public  int Id { get; set; }
        [Required]
        public string VIN { get; set; }
        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }
        public string Style { get; set; }

        [Required]
        public string Year { get; set; }

      
        public string Miles { get; set; }
        public string Colors { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
