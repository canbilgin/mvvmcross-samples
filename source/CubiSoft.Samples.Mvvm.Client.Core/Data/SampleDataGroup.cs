using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubiSoft.Samples.Mvvm.Client.Core.Data
{
    /// <summary>
    /// Generic group data model.
    /// </summary>
    public class SampleDataGroup
    {
        public SampleDataGroup()
        {
        }

        public string UniqueId { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public List<SampleDataItem> Items { get; set; }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
