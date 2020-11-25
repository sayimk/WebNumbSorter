namespace NumberSorter.Models.NumberModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sort
    {
        public int id { get; set; }

        public string sortedNumbers { get; set; }

        public decimal? sortTimeMillisec { get; set; }

        [StringLength(10)]
        public string sortDirection { get; set; }
    }
}
