using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class JobProviderTokenDTO : JobProviderDTO
    {
        public List<TokenDTO> Tokens { get; set; }
    }
}
