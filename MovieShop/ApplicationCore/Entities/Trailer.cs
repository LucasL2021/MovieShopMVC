﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("Trailer")]
    public class Trailer
    {
        
        public int Id { get; set; }
        public string TrailerUrl { get; set; }
        public string Name { get; set; }
        public int MovieId { get; set; }

        //Navigation Property
        public Movie Movie { get; set; }



    }
}
