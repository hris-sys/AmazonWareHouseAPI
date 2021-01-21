using Data.Connection;
using Data.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.Classes
{
    public class BaseContext
    {
        protected AmazonDbContext Context { get; set; }

        public BaseContext(AmazonDbContext context)
        {
            this.Context = context;
        }
    }
}
