using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace app.domain
{
    public class Issue : BaseEntity
    {
        [DisplayName("Issue ID")]
        public int IssueID { get; set; }

        [DisplayName("Train Issue")]
        public string Problem { get; set; }

        [DisplayName("Reordered Time")]
        public DateTime ReorderedTime { get; set; }
    }
}
