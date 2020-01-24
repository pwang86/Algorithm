using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.search
{
	class LinearSearch
	{
		public static int IntLinearSearch(int[] data, int item, int start) {
			int length = data.Length;
			if (start < 0)
			{
				return -1;
			}
			for (int i = start; i < length; i++)
			{
				if (data[i] == item)
				{
					return i;
				}
			}
			return -1;
		}
	}
}
