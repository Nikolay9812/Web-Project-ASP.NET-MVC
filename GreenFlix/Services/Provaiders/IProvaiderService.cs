using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenFlix.Services.Provaiders
{
    public interface IProvaiderService
    {
        public bool IsProvaider(string userId);

        public int IdByUser(string userId);
    }
}
