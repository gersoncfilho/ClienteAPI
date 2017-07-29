using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ClienteAPI.Models
{
    public class ClienteContext:DbContext
    {
        public ClienteContext() : base("ClientesAPI")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<UserAsp> UsersASP { get; set; }
        public DbSet<ProfileASP> ProfilesASP { get; set; }
        public DbSet<VideoASP> VideosASP { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Retira a pluralização quando o entity for criar o nome da tabela
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


        }
    }
}