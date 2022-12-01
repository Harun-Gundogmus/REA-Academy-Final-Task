using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class TaskComment
    {
        [Key]
        public int comment_id { get; set; }
        public string comment { get; set; }
        public TaskOwner TaskOwner { get; set; }
    }
}
