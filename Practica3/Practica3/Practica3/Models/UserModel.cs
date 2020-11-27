using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Practica3.Models
{
    public class UserModel
    {
        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }
        [MaxLength(30)]

        public string Name { get; set; }
        [MaxLength(30)]

        public string Email { get; set; }

        [MaxLength(16)]
        public string Password { get; set; }

    }
}
