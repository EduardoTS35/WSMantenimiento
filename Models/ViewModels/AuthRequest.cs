using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSMantenimiento.Models.ViewModels
{
    public class AuthRequest
    {
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Pass { get; set; }
    }
}
