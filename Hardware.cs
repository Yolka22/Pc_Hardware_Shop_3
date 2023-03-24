using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pc_Hardware_Shop
{
    internal class Hardware
    {

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}


		private int price;

		public int Price
		{
			get { return price; }
			set { price = value; }
		}

		private string characteristics;

		public string Characteristics
        {
			get { return characteristics; }
			set { characteristics = value; }
		}

	}
}
