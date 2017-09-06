using System;

namespace BigToDo.Models
{
    public class BigToDoModel
    {
        public BigToDoModel()
        {
        }

        public int ID  { get; set; }
        public string TaskName { get; set; }
        public bool Complete { get; set; } = false;
        public DateTime Time { get; set; } = DateTime.Now;

        public void IsComplete()
        {
            Complete = true;
            Time = DateTime.Now;
        }
        public int UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}