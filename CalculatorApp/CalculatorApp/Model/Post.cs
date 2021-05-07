using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp.Model
{
    public class Post
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Calculations { get; set; }
        public string Answer { get; set; }
    }
}
