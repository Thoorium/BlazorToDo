using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorToDo.WebApp.Data
{
    public class ToDoItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool Done { get; set; }

        public string AddedBy { get; set; }

        [NotMapped]
        public Guid EditId { get; set; } = Guid.NewGuid();

        [NotMapped]
        public bool MarkedForRemoval { get; set; } = false;

        public override bool Equals(object obj)
        {
            //
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //
            
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            
            // TODO: write your implementation of Equals() here
            ToDoItem item = obj as ToDoItem;
            if(Id == 0 || item.Id == 0)
                return item.EditId == EditId;
            return item.Id == Id;
            //return base.Equals (obj);
        }
        
        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            //throw new System.NotImplementedException();
            return base.GetHashCode();
        }
    }
}