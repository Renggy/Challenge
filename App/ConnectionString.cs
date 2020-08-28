using Challenge.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.App
{
    public class ConnectionString : DbContext
    {
        public ConnectionString(DbContextOptions<ConnectionString> options) : base(options)
        {

        }
        public DbSet<AuthModel> table_user { get; set; }
        public DbSet<RequestModel> table_transaksi_request { get; set; }
    }
}
