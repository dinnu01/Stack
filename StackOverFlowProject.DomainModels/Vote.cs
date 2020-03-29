using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StackOverFlowProject.DomainModels
{
   public class Vote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VoteID { get; set; }
        public int AnswerId { get; set; }
        public int UserId { get; set; }
        public string VoteValue { get; set; }
    }
}
