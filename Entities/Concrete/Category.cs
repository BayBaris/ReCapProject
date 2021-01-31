using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    class Category : IEntity
    {
        public int BrandID { get; set; }
        public int ColorID { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
    }
}
