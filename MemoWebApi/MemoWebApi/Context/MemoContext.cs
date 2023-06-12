using MemoWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoWebApi.Context
{
    public class MemoContext: DbContext
    {
        public MemoContext(DbContextOptions<MemoContext> options): base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
