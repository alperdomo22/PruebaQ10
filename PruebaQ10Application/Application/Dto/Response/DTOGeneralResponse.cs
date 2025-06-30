using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Response
{
    public class DTOGeneralResponse<T>
    {
        public bool Success { get; set; }
        public string Description { get; set; }
        public T Data { get; set; }
    }
}
