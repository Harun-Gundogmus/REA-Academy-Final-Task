using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class TaskOwner
    {
        [Key]
        public int owner_id { get; set; }
        public string owner_name { get; set; }
        public string owner_task_title { get; set; }
        public string owner_explanation { get; set; }
        public string owner_status { get; set; }
        public int comment_id { get; set; }
        public ICollection<TaskComment> comment { get; set; }

    }
    public enum Status
    {
        Created = 0,
        InProgress = 1,
        Done = 2
    }
}
