using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
	class Program
	{
		static void Main(string[] args)
		{
			///*LinearSearch*/
			//Console.WriteLine("Please enter an int array, separated by ,: ");
			//string input = Console.ReadLine();
			//string[] intArray = input.Split(',');
			int[] a = new int[]{-3, 4, 3, 90 };
			//int[] b = TwoSum(a, 0);
			//Console.WriteLine("Result is :");
			//foreach (var item in b)
			//{
			//	Console.WriteLine("{0}",item);
			//}
			// Reverse(123);

			//Console.WriteLine(IsPalindrome(121));
			Console.WriteLine(RomanToInt("LVI"));

		}

		public static int[] TwoSum(int[] nums, int target)
		{   /* solution 2 */
			Hashtable temp = new Hashtable();
			int[] b;
			for (int i = 0; i < nums.Length; i++)
			{
				/*cannot compare target, because if [-3, 4, 3, 90 ] and 0, there will no two sum
				if (nums[i] <= target)*/
					int a = target - nums[i];
					if (temp.ContainsValue(a))
					{
						b = new int[] { temp.Keys.OfType<int>().FirstOrDefault(x => (int)temp[x] == a), i };
						return b;
					}
					temp.Add(i, nums[i]);
			}
			/*Solution 1*/
			//Hashtable temp = new Hashtable();
			//for (int i = 0; i < nums.Length; i++)
			//{
			//	if (nums[i] <= target)
			//	{
			//		temp.Add(i, nums[i]);
			//	}
			//}
			//IDictionaryEnumerator denum = temp.GetEnumerator();
			//DictionaryEntry dentry;
			//while (denum.MoveNext())
			//{
			//	dentry = (DictionaryEntry)denum.Current;
			//	int a = target - (int)dentry.Value;
			//	if (temp.ContainsValue(a))
			//	{
			//		return new int[] { temp.Keys.OfType<int>().FirstOrDefault(x => (int)temp[x] == a), (int)dentry.Key};
			//	}
			//}
			throw new Exception("No two sum solution");
		}
		public static int Reverse(int x)
		{
			int reverse = 0;
			while (x != 0)
			{
				int remainder = x % 10;
				x /= 10;
				Console.WriteLine(x);
				/*7 and -8 because int range is from -2,147,483,648 to 2,147,483,647*/
				if (reverse > Int32.MaxValue / 10 || (reverse == Int32.MaxValue / 10 && remainder > 7))
				{ return 0; }
				if (reverse < Int32.MinValue / 10 || (reverse == Int32.MinValue / 10 && remainder < -8))
				{ return 0; }
				reverse = (reverse * 10) + remainder;

			}
			return reverse;
		}
		public static bool IsPalindrome(int x)
		{
			/*0 is anaylized ahead of x % 10 ==0, because 0 % 10 == 0*/
			if (x == 0)
			{
				return true;
			}
			if (x < 0 || x % 10 == 0) { return false; }
			int origin = x;
			int reverse = 0;
			while (x != 0)
			{
				int remainder = x % 10;
				x = x / 10;
				reverse = reverse * 10 + remainder;
			}
			if (reverse == origin)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static int RomanToInt(string s)
		{
			char[] charArr = s.ToUpper().ToCharArray();
			int result = 0;
			int j = charArr.Length;
			for (int i = 0; i < j; i++)
			{
				int num=0;
				if ((i!=(j-1)) && charArr[i].Equals('I') && (charArr[i+1].Equals('V') || charArr[i + 1].Equals('X')))
				{
					num = -1;
				}
				else if ((i != (j - 1)) && charArr[i].Equals('X') && (charArr[i + 1].Equals('L') || charArr[i + 1].Equals('C')))
				{
					num = -10;
				}
				else if ((i != (j - 1)) && charArr[i].Equals('C') && (charArr[i + 1].Equals('D') || charArr[i + 1].Equals('M')))
				{
					num = -100;
				}
				else
				{
					switch (charArr[i])
					{
						case 'I':
							num = 1;
							break;
						case 'V':
							num = 5;
							break;
						case 'X':
							num = 10;
							break;
						case 'L':
							num = 50;
							break;
						case 'C':
							num = 100;
							break;
						case 'D':
							num = 500;
							break;
						case 'M':
							num = 1000;
							break;
						default:
							num = 0;
							break;
						}
					}
				result += num;
			}
			return result;
		}

	}
}
