using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SQLite.Models
{
    [Table("User")]
    public class User
    {
        [Column("id"), Key, Autoincrement]
        public int Id { get; set; }

        [Column("Guid")]
        public string Guid { get; set; }

        [Column("firstname")]
        public string FirstName { get; set; }

        [Column("lastname")]
        public string LastName { get; set; }

        [Column("adddatetime")]
        public DateTime AddDateTime { get; set; }
    }
}
