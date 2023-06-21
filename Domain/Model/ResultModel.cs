using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ResultModel<T>
    {
        public T Model { get; set; }
        public List<string> Menssages { get; set; } = new List<string>();
        public bool Success { get; set; }
    }
}
