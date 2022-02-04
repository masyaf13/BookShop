using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop
{
    public abstract class BaseClass
    {

        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

        
        Random random = new Random();

        //magic string olmaması için değişkenleri atadık
        const int MIN_NUMS = 100000000;
        const int MAX_NUMS = 999999999;
        public BaseClass()
        {
            Id = random.Next(MIN_NUMS, MAX_NUMS);
            CreatedTime = DateTime.Now;
            UpdatedTime = DateTime.Now;
        }

    }
}
