using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseMurdererV3
{
    public class PulseData
    {
        private int id;
        private string iterval;

        public PulseData(int id, string iterval)
        {
            Id = id;
            Iterval = iterval;
        }

        public PulseData()
        {
        }

        public int Id
        {
            get => id;
            set
            {
                id = value;
            }
        }

        public string Iterval
        {
            get => iterval;
            set
            {
                iterval = value;
            }
        }
    }
}
