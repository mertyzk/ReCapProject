using System;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Entity.Concrete
{
    public class CarImage:IEntity
    {
        [Key]
        public int ImageId { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
