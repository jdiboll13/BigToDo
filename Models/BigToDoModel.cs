using System;

namespace BigToDo.Models
{
    public class BigToDoModel
    {

        public int ID  { get; set; }
        public string TaskName { get; set; }
        public bool? Complete { get; set; } = false;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime CompleteDate { get; set; }
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public void IsComplete()
        {
            Complete = true;
            CompleteDate = DateTime.Now;
        }
    }
}