﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MinhasNotas.Models
{
    public class Grades
    {
        public int Id { get; set; }
        [Column(TypeName = "double")]
        public double Grade { get; set; }
        public DateTime DataTest { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

    }
}
