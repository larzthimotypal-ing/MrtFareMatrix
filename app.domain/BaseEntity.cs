using System;
using System.ComponentModel.DataAnnotations;

namespace app.domain
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }
    }
}
