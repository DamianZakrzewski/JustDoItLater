using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustDoItLater.Enums;

namespace JustDoItLater.Model
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public ToDoState State { get; set; } = ToDoState.NotStarted;
        public DateTime Date { get; set; } = DateTime.Now.Date;

        //[Timestamp]
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
