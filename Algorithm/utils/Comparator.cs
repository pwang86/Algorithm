using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.utils
{
	public sealed class Comparator
	{
		private static readonly Comparator instance = new Comparator();

		static Comparator() { }
		private Comparator() { }
		public static Comparator Instance {
			get {
				return instance;
			}
		}

		static int DefaultFunction(int a, int b) {
			if (a == b) {
				return 0;
			}

			return a < b ? -1 : 1;
		}

		public bool operatorEqual(int a, int b) {
			return Comparator.DefaultFunction(a, b) == 0;
		}

		public bool LessThan(int a, int b) {
			return Comparator.DefaultFunction(a, b) < 0;
		}

		public bool GreaterThan(int a, int b) {
			return Comparator.DefaultFunction(a, b) > 0;
		}

		public bool LessThanOrEqual(int a, int b) {
			return this.LessThan(a, b) || this.operatorEqual(a, b);
		}

		public bool GreaterThanOrEqual(int a, int b)
		{
			return this.GreaterThan(a, b) || this.operatorEqual(a, b);
		}

		//publlic Reverse() { }
	}
}
