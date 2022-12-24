using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class JobVacancyDTO
    {
        public int Id { get; set; }
        [Required]
        public string JobType { get; set; }
        [Required]
        public string JobDescription { get; set; }
        [Required]
        public string Salary { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string RequiredSkills { get; set; }
        [Required]
        public string JobLocType { get; set; }
        [Required]
        public int Vacancy { get; set; }
        [Required]
        public int JobProviderId { get; set; }
    }
}
