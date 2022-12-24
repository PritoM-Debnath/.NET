using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PortfolioDTO
    {
        public int Id { get; set; }
        [Required]
        public string Skills { get; set; }
        [Required]
        public string Expertise { get; set; }
        [Required]
        public string Experience { get; set; }
        [Required]
        public string Projects { get; set; }
        [Required]
        public string ExtraCurrActivities { get; set; }
        [Required]
        public int JobSeekerId { get; set; }
    }
}
