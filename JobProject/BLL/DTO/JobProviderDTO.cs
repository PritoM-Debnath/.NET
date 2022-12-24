using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class JobProviderDTO
    {
        public int Id { get; set; }
        [Required]
        public string Uname { get; set; }
        [Required]
        public string Pass { get; set; }
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
        [Required]
        public string Designation { get; set; }
    }
}
