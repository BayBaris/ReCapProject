using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CarDetailsDto : IDto
    {
        public int CarID { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Descriptions { get; set; }

    }
}
