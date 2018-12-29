using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite.EF6;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SQLite.DAL;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using SQLite.Models;

namespace SQLite
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            //连接Config配置数据库
            using (SqliteDbContext db = new SqliteDbContext())
            {
                #region 预热：针对数据表较多的情况下建议执行下述操作
                var objectContext = ((IObjectContextAdapter)db).ObjectContext;
                var mappingColection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                mappingColection.GenerateViews(new List<EdmSchemaError>());
                #endregion

                var UsersNew = db.Users.ToList();
                dataGridView1.DataSource = UsersNew;
            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////连接指定数据库
            //var ptah = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataWall.db");
            //var connection = SQLiteProviderFactory.Instance.CreateConnection();
            //connection.ConnectionString = $"Data Source={ptah}";

            //using (SqliteDbContext db = new SqliteDbContext(connection, false))
            //{
            //    var objectContext = ((IObjectContextAdapter)db).ObjectContext;
            //    var mappingColection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
            //    mappingColection.GenerateViews(new List<EdmSchemaError>());

            //    db.Users.Add(new User { FirstName = "宗文", LastName = "吴" });
            //    db.SaveChanges();
            //}

            //连接Config配置数据库
            using (SqliteDbContext db = new SqliteDbContext())
            {
                //#region 预热：针对数据表较多的情况下建议执行下述操作
                //var objectContext = ((IObjectContextAdapter)db).ObjectContext;
                //var mappingColection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                //mappingColection.GenerateViews(new List<EdmSchemaError>());
                //#endregion

                db.Users.Add(new User { Guid = Guid.NewGuid().ToString("D"), FirstName = "宗文", LastName = "吴", AddDateTime = DateTime.Now });
                db.SaveChanges();

                var UsersNew = db.Users.ToList();
                dataGridView1.DataSource = UsersNew;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //连接Config配置数据库
            using (SqliteDbContext db = new SqliteDbContext())
            {
                //#region 预热：针对数据表较多的情况下建议执行下述操作
                //var objectContext = ((IObjectContextAdapter)db).ObjectContext;
                //var mappingColection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                //mappingColection.GenerateViews(new List<EdmSchemaError>());
                //#endregion

                var User = db.Users.OrderByDescending(u => u.AddDateTime).FirstOrDefault();
                db.Users.Remove(User);
                db.SaveChanges();
                var UsersNew = db.Users.ToList();
                dataGridView1.DataSource = UsersNew;
            }
        }
    }
}
