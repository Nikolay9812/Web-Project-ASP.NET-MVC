using GreenFlix.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenFlix.Services.Provaiders
{
    public class ProvaiderService :IProvaiderService
    {
        private readonly GreenFlixDbContext data;

        public ProvaiderService(GreenFlixDbContext data)
            => this.data = data;

        public bool IsProvaider(string userId)
            => this.data
                .Provaiders
                .Any(p => p.UserId == userId);

        public int IdByUser(string userId)
            => this.data
                .Provaiders
                .Where(p => p.UserId == userId)
                .Select(p => p.Id)
                .FirstOrDefault();
    }
}
