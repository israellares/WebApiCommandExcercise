using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommanderWebApi.DTOS
{
    public class CreateCommandDTO
    {
        [Required]
        [MaxLength(255)]
        public string Howto { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }

    }
}
