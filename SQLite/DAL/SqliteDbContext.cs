using SQLite.CodeFirst;
using SQLite.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace SQLite.DAL
{
    public class SqliteDbContext : DbContext
    {

        /// <summary>
        /// 从配置文件读取链接字符串
        /// </summary>
        public SqliteDbContext() :
        base("name = DataWall")
        {
            ConfigurationFunc();
        }

        /// <summary>
        /// 代码指定数据库连接
        /// </summary>
        /// <param name="existingConnection"></param>
        /// <param name="contextOwnsConnection"></param>
        public SqliteDbContext(DbConnection existingConnection, bool contextOwnsConnection) :
        base(existingConnection, contextOwnsConnection)
        {
            ConfigurationFunc();
        }

        private void ConfigurationFunc()
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var initializer = new SqliteDropCreateDatabaseWhenModelChanges<SqliteDbContext>(modelBuilder);
            Database.SetInitializer(initializer);
        }

        public DbSet<User> Users { get; set; }

    }
}
