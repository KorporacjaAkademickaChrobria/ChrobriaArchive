using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModel.Model
{
    public class Image
    {
        [Key]
        public long ImageId { get; set; }
        public string Name { get; set; }
    }
}
