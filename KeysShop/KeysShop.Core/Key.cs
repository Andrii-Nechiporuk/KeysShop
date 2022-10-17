using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysShop.Core
{
    public class Key
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public double? Sale { get; set; }
        public int? Frequency { get; set; }
        public string? Count { get; set; }
        public string? ImgPath { get; set; }
        public bool IsOriginal { get; set; }
        public bool IsKeyless { get; set; }
        public Brand? Brand { get; set; }
        public List<Feedback>? feedbacks { get; set; }
    }
}
