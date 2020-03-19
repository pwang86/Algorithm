using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
			int[] a = new int[] { -3, 4, 3, 90 };
			//int[] b = TwoSum(a, 0);
			//Console.WriteLine("Result is :");
			//foreach (var item in b)
			//{
			//	Console.WriteLine("{0}",item);
			//}
			// Reverse(123);

			//Console.WriteLine(IsPalindrome(121));

			//Console.WriteLine(RomanToInt("LVI"));

			//string[] stringArr = new string[] { "flower", "flow", "flight" };
			//Console.WriteLine(LongestCommonPrefix(stringArr));

			//int[] array = new int[] {0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
			//Console.WriteLine(RemoveDuplicates(array));

			//int[] array = new int[] {0, 1, 2, 2, 3, 0, 4, 2 };
			//Console.WriteLine(RemoveElement(array,3));

			Console.WriteLine(ClimbStairs(44));

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
				int num = 0;
				if ((i != (j - 1)) && charArr[i].Equals('I') && (charArr[i + 1].Equals('V') || charArr[i + 1].Equals('X')))
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
		public static string LongestCommonPrefix(string[] strs)
		{
			StringBuilder prefix = new StringBuilder();
			StringBuilder result = new StringBuilder();
			foreach (char c in strs[0])
			{
				int count = 0;
				prefix.Append(c);
				for (int i = 1; i < strs.Length; i++)
				{
					if ((Regex.Match(strs[i], prefix.ToString(), RegexOptions.IgnoreCase)).Success)
						count++;
					else
						break;
				}
				if (count == (strs.Length - 1))
					result.Append(c);
				else
					break;
			}
			return result.ToString();
		}

		public static bool IsValid(string s)
		{
			Hashtable mappings = new Hashtable();
			mappings.Add(')', '(');
			mappings.Add('}', '{');
			mappings.Add(']', '[');

			Stack<char> myStack = new Stack<char>();
			for (int i = 0; i < s.Length; i++)
			{
				char c = s[i];
				if (mappings.ContainsKey(c))
				{
					char topElement = ((myStack.Count == 0) ? '#' : myStack.Pop());
					if (!topElement.Equals(mappings[c]))
					{
						return false;
					}
				}
				else
				{
					myStack.Push(c);
				}
			}
			return (myStack.Count == 0);

		}

		// public class ListNode
		//{
		//        public int val;
		//        public ListNode next;
		//        public ListNode(int x) { val = x; }
		//      }


		//public ListNode MergeTwoLists(ListNode l1, ListNode l2)
		//{
		//	ListNode head = new ListNode(0);
		//	ListNode start = head;

		//	while (l1 != null && l2 != null)
		//	{
		//		if (l1.val <= l2.val)
		//		{
		//			start.next = l1;
		//			l1 = l1.next;
		//		}
		//		else
		//		{
		//			start.next = l2;
		//			l2 = l2.next;
		//		}

		//		start = start.next;
		//	}

		//	if (l1 != null)
		//	{
		//		start.next = l1;
		//	}
		//	if (l2 != null)
		//	{
		//		start.next = l2;
		//	}

		//	return head.next;
		//}

		public static int RemoveDuplicates(int[] nums)
		{
			/*first use FirstOrDefault and IndexOf, not work*/
			if (nums.Length == 0)
				return 0;
			int count = 0;
			for (int i = 1; i < nums.Length; i++)
			{
				if (nums[count] < nums[i])
				{
					nums[count + 1] = nums[i];
					count++;
				}

			}
			return (count + 1);
		}

		public static int RemoveElement(int[] nums, int val)
		{
			if (nums.Length == 0)
			{
				return 0;
			}
			int count = 0;
			for (int i = 0; i < nums.Length; i++)
			{
				if (nums[i] == val)
				{
					for (int j = i + 1; j < nums.Length; j++)
					{
						if (nums[j] != val)
						{
							int temp = 0;
							temp = nums[i];
							nums[i] = nums[j];
							nums[j] = temp;
							count++;
							break;
						}
					}
				}
				else
				{
					count++;
				}
			}
			return count;
		}

		public static string CountAndSay(int n)
		{
			string result;
			if (n == 1)
			{
				result = 1.ToString();
			}
			else
			{
				result = CountAndSay(n - 1);

				if (result.Length == 1)
					result = 11.ToString();
				else
				{
					string temp = "";
					for (int i = 0; i < result.Length;)
					{
						int count = 1;
						for (int j = i + 1; j < result.Length; j++)
						{

							if (result[i] == result[j])
							{
								count++;
							}

							else
							{
								break;
							}

						}
						// Console.WriteLine("{0}:{1}", count, result[i]);
						temp = string.Concat(temp, count.ToString(), result[i].ToString());
						// Console.WriteLine(temp);
						i += count;
					}
					result = temp;
				}
			}

			// Console.WriteLine("{0}.    {1}", n, result);
			return result;

		}

		public static int LengthOfLastWord(string s)
		{
			string[] str = s.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			return str.Length == 0 ? 0 : str[str.Length - 1].Length;

		}

		public static int MaxSubArray(int[] nums)
		{
			if (nums == null || nums.Length == 0)
			{
				return 0;
			}

			int max_current = nums[0];
			int max_best = nums[0];

			for (int i = 1; i < nums.Length; i++)
			{
				max_current = Math.Max(nums[i], max_current + nums[i]);
				max_best = Math.Max(max_current, max_best);
			}

			return max_best;
		}

		public static int[] PlusOne(int[] digits)
		{
			if (digits[digits.Length - 1] != 9)
			{
				digits[digits.Length - 1] += 1;
				return digits;
			}
			else
			{
				Stack<int> temp = new Stack<int>();
				temp.Push(0);
				bool addOne = true;
				for (int i = digits.Length - 2; i >= 0; i--)
				{
					if (digits[i] == 9 && addOne)
					{
						temp.Push(0);
					}
					else if (digits[i] != 9 && addOne)
					{
						temp.Push(digits[i] + 1);
						addOne = false;
					}
					else
					{
						temp.Push(digits[i]);
						addOne = false;
					}
				}
				if (addOne)
				{
					temp.Push(1);
				}
				return temp.ToArray();
			}
		}

		public static string AddBinary(string a, string b)
		{
			int over = 0;
			StringBuilder sb = new StringBuilder();

			for (int indexA = a.Length - 1, indexB = b.Length - 1; indexA >= 0 || indexB >= 0; indexA--, indexB--)
			{
				// - 48 is to convert char into int, 48 equals '0' in ASCII
				var curA = indexA >= 0 ? a[indexA] - 48 : 0;
				var curB = indexB >= 0 ? b[indexB] - 48 : 0;
				var sum = curA + curB + over;

				if (sum > 1)
				{
					sb.Insert(0, sum % 2);
					over = 1;
				}
				else
				{
					sb.Insert(0, sum);
					over = 0;
				}
			}
			if (over == 1)
			{
				sb.Insert(0, '1');
			}

			return sb.ToString();

		}

		public static int ClimbStairs(int n)
		{
			if (n == 1)
			{
				return 1;
			}
			int a = 1;
			int b = 2;
			for (int i = 3; i <= n; i++)
			{
				int c = a + b;
				a = b;
				b = c;
			}
			return b;

		}

		//public static ListNode DeleteDuplicates(ListNode head)
		//{
		//	if (head == null || head.next == null)
		//		return head;
		//	ListNode start = head;
		//	while (start.next != null)
		//	{
		//		if (start.val == start.next.val)
		//		{
		//			start.next = start.next.next;
		//		}
		//		else
		//		{
		//			start = start.next;
		//		}
		//	}
		//	return head;
		//}

		//public static bool IsSameTree(TreeNode p, TreeNode q)
		//{
		//	if (p == null && q == null)
		//		return true;
		//	else if (p == null || q == null)
		//		return false;
		//	bool result = false;
		//	if (p.val != q.val)
		//	{
		//		return false;
		//	}
		//	else
		//	{
		//		if (IsSameTree(p.left, q.left))
		//		{
		//			if (IsSameTree(p.right, q.right))
		//			{
		//				result = true;
		//			}
		//			else
		//				return false;
		//		}
		//		else
		//			return false;
		//	}
		//	return result;
		//}

		/**
          * Definition for a binary tree node.
		  * public class TreeNode {
          *     public int val;
		  *     public TreeNode left;
		  *     public TreeNode right;
		  *     public TreeNode(int x) { val = x; }
          * }
        */
		// recursion
		//public class Solution
		//{
		//	public bool IsSymmetric(TreeNode root)
		//	{
		//		return root == null || this.IsSymmetricRecursion(root.left, root.right);
		//	}

		//	public bool IsSymmetricRecursion(TreeNode node1, TreeNode node2)
		//	{
		//		if (node1 == null && node2 == null)
		//		{
		//			return true;
		//		}
		//		else if (node1 == null || node2 == null)
		//			return false;
		//		if (node1.val != node2.val)
		//			return false;
		//		return this.IsSymmetricRecursion(node1.left, node2.right) && this.IsSymmetricRecursion(node1.right, node2.left);
		//	}
		//}

		// iteration
		//Queue<TreeNode> q = new Queue<TreeNode>();
		//q.Enqueue(root);
		//      q.Enqueue(root);
		//      while(q.Any()){
		//          TreeNode t1 = q.Dequeue();
		//TreeNode t2 = q.Dequeue();
		//          if (t1 == null && t2 == null) continue;
		//          if (t1 == null || t2 == null) return false;
		//          if (t1.val != t2.val) return false;
		//          q.Enqueue(t1.left);
		//          q.Enqueue(t2.right);
		//          q.Enqueue(t1.right);
		//          q.Enqueue(t2.left);
		//      }
		//      return true;

		//public static int MaxDepth(TreeNode root)
		//{
		//if(root == null)
		//          return 0;
		//      Queue<TreeNode> q = new Queue<TreeNode>();
		//q.Enqueue(root);
		//      int count = 0;
		//      while(q.Any()){
		//          int length = q.Count;
		//count++;
		//          for(int i = 0; i<length; i++){
		//              TreeNode t = q.Dequeue();
		//              if(t.left != null) 
		//              { 
		//                q.Enqueue(t.left); 
		//              }
		//              if(t.right != null)
		//              {
		//                q.Enqueue(t.right);
		//              }
		//          }
		//      }   
		//      return count;    
		//}

		//public static IList<IList<int>> LevelOrderBottom(TreeNode root)
		//{
		//	if (root == null)
		//	{
		//		return null;
		//	}
		//	Stack<Treenode> s = new Stack<Treenode>();
		//	s.Push(root);
		//	while (s.Any())
		//	{
		//		int length = s.Count;
		//		for (int i = 0; i < length; i++)
		//		{
		//			if (s.left != null)
		//			{
		//				s.Push(s.left);
		//			}
		//			if (s.right != null)
		//			{
		//				s.Push(s.right);
		//			}
		//		}
		//	}
		//	List<int> ll = new List<int>();
		//	foreach (var item in s)
		//	{
		//		ll.Add(item.Pop().val);
		//	}
		//}

		//public static IList<IList<int>> LevelOrderBottom(TreeNode root)
		//{
		//	var ll = new List<IList<int>>();
		//	if (root == null)
		//	{
		//		return ll;
		//	}
		//	Queue<TreeNode> q = new Queue<TreeNode>();
		//	q.Enqueue(root);
		//	ll.Add(new List<int> { root.val });
		//	while (q.Any())
		//	{
		//		int length = q.Count;
		//		var l = new List<int>();
		//		for (int i = 0; i < length; i++)
		//		{
		//			TreeNode t = q.Dequeue();
		//			if (t.left != null)
		//			{
		//				q.Enqueue(t.left);
		//				l.Add(t.left.val);
		//			}
		//			if (t.right != null)
		//			{
		//				q.Enqueue(t.right);
		//				l.Add(t.right.val);
		//			}
		//		}
		//		if (q.Any())
		//		{
		//			ll.Add(l);
		//		}
		//	}
		//	ll.Reverse();
		//	return ll;
		//}

		//public static TreeNode SortedArrayToBST(int[] nums)
		//{
		//	return SortedRecursion(0, nums.Length - 1, nums);
		//}

		//public static TreeNode SortedRecursion(int start, int end, int[] nums)
		//{
		//	if (start > end)
		//	{
		//		return null;
		//	}
		//	int half = (end - start) / 2 + start;
		//	var root = new TreeNode(nums[half])
		//	{
		//		left = SortedRecursion(start, half - 1, nums),
		//		right = SortedRecursion(half + 1, end, nums)
		//	};
		//	return root;
		//}

		//public static bool IsBalanced(TreeNode root)
		//{
		//	if (root == null) return true;
		//	var left = IsBalancedHelper(root.left);
		//	var right = IsBalancedHelper(root.right);

		//	if (left == -1 || right == -1) return false;
		//	if (Math.Abs(left - right) >= 2) return false;

		//	return true;
		//}

		//private static int IsBalancedHelper(TreeNode root)
		//{
		//	if (root == null) return 0;
		//	var left = IsBalancedHelper(root.left);
		//	var right = IsBalancedHelper(root.right);

		//	if (left == -1 || right == -1) return -1;
		//	if (Math.Abs(left - right) >= 2) return -1;

		//	return Math.Max(left, right) + 1;
		//}

		//public static int MinDepth(TreeNode root)
		//{
		//	if (root == null)
		//		return 0;
		//	Queue<TreeNode> q = new Queue<TreeNode>();
		//	q.Enqueue(root);
		//	int height = 0;

		//	while (q.Any())
		//	{
		//		height++;
		//		int length = q.Count;
		//		for (int i = 0; i < length; i++)
		//		{
		//			TreeNode temp = q.Dequeue();
		//			if (temp.left == null && temp.right == null) return height;
		//			if (temp.left != null) q.Enqueue(temp.left);
		//			if (temp.right != null) q.Enqueue(temp.right);
		//		}
		//	}
		//	return height;
		//}

		//public static bool HasPathSum(TreeNode root, int sum)
		//{
		//	if (root == null) return false;
		//	if (root.left == null && root.right == null)
		//		return (sum == root.val);
		//	return HasPathSum(root.left, sum - root.val) || HasPathSum(root.right, sum - root.val);

		//}

		//public static IList<IList<int>> Generate(int numRows)
		//{
		//	var ll = new List<IList<int>>();

		//	for (int i = 0; i < numRows; i++)
		//	{
		//		var l = new List<int>();
		//		for (int j = 0; j <= i; j++)
		//		{
		//			l.Add((j == 0 || j == i) ? 1 : ll[i - 1][j - 1] + ll[i - 1][j]);
		//		}
		//		ll.Add(l);
		//	}
		//	return ll;
		//}

		//public static IList<int> GetRow(int rowIndex)
		//{
		//	var list = new List<int>();
		//	for (int i = 0; i <= rowIndex; i++)
		//	{
		//		var temp = new List<int>();
		//		for (int j = 0; j <= i; j++)
		//		{
		//			temp.Add(j == 0 || j == i ? 1 : (list[j - 1] + list[j]));
		//		}
		//		list = temp;
		//	}
		//	return list;
		//}

		//public static int MaxProfit(int[] prices)
		//{
		//	//int result = 0;
		//	//for (int i = 0; i < prices.Length; i++)
		//	//{
		//	//	for (int j = i + 1; j <= prices.Length - 1; j++)
		//	//	{
		//	//		result = Math.Max(result, prices[j] - prices[i]);
		//	//	}
		//	//}
		//	//return result;

		//	//optimized
		//	var max_so_far = 0;
		//	var max_current = 0;

		//	for (int i = 1; i < prices.Length; i++)
		//	{
		//		max_current = Math.Max(0, max_current + prices[i] - prices[i - 1]);
		//		max_so_far = Math.Max(max_current, max_so_far);
		//	}

		//	return max_so_far;
		//}

		public static int MaxProfit(int[] prices)
		{
			int temp = 0;
			int maxValue = 0;

			for (int i = 1; i < prices.Length; i++)
			{
				temp = Math.Max(0, maxValue + prices[i] - prices[i - 1]);
				maxValue = Math.Max(temp, maxValue);
			}
			return maxValue;
		}

		public static bool IsPalindrome(string s)
		{
			if (string.IsNullOrEmpty(s))
				return true;
			char[] arr = s.ToLower().Where(c => Char.IsLetterOrDigit(c)).ToArray();
			Console.WriteLine(arr);
			int i = 0;
			int j = arr.Length - 1;
			while (i <= j)
			{
				if (arr[i] != arr[j])
					return false;
				else
				{
					i++;
					j--;
				}
			}
			return true;
		}

		public static int SingleNumber(int[] nums)
		{
			return nums.Aggregate(0, (current, i) => current ^ i);

			// lower solution
			//HashSet<int> tempSet = new HashSet<int>();
			//for (int i = 0; i < nums.Length; i++)
			//{
			//	if (tempSet.Contains(nums[i]))
			//	{
			//		tempSet.Remove(nums[i]);
			//	}
			//	else
			//	{
			//		tempSet.Add(nums[i]);
			//	}
			//}
			//return tempSet.First();
		}

		//public static bool HasCycle(ListNode head)
		//{
		//	var slow = head;
		//	var fast = head;

		//	while (fast != null && fast.next != null)
		//	{
		//		slow = slow.next;
		//		fast = fast.next.next;

		//		if (slow == fast) return true;

		//	}
		//	return false;

		//// Option 2
		//if(head==null) return false;
		//      if(head.next == head) return true;

		//      var temp = head.next;
		//head.next = head;
		//      return HasCycle(temp);
		//}

		// option 3
		//HashSet<ListNode> temp = new HashSet<ListNode>();
		//      while(head!=null){
		//          if(temp.Contains(head)){
		//              return true;
		//          }
		//          else{
		//              temp.Add(head);
		//          }
		//	head = head.next;
		//      }
		//      return false;

		//}

		//public class MinStack
		//{

		//	/** initialize your data structure here. */
		//readonly Stack<Tuple<int, int>> _mStack = new Stack<Tuple<int, int>>();
		//public MinStack()
		//{

		//}

		//public void Push(int x)
		//{
		//	if (GetMin() == int.MinValue)
		//	{
		//		var newNode = new Tuple<int, int>(x, x);
		//		_mStack.Push(newNode);
		//	}
		//	else
		//	{
		//		var newNode = new Tuple<int, int>(x, Math.Min(x, GetMin()));
		//		_mStack.Push(newNode);
		//	}
		//}

		//public void Pop()
		//{
		//	_mStack.Pop();
		//}

		//public int Top()
		//{
		//	if (_mStack.Count == 0)
		//	{
		//		return int.MinValue;
		//	}
		//	return _mStack.Peek().Item1;
		//}

		//public int GetMin()
		//{
		//	if (_mStack.Count == 0)
		//	{
		//		return int.MinValue;
		//	}
		//	return _mStack.Peek().Item2;
		//}

		//public static int[] TwoSum(int[] numbers, int target)
		//{
		//	for (int i = 0, j = numbers.Length - 1; i < j;)
		//	{
		//		if (numbers[i] + numbers[j] == target)
		//		{
		//			return new int[] { i + 1, j + 1 };
		//		}
		//		else
		//		{
		//			if (numbers[i] + numbers[j] < target)
		//			{
		//				i++;
		//			}
		//			else
		//			{
		//				j--;
		//			}
		//		}

		//	}
		//	return new int[] { -1, -1 };
		//}

		public static string ConvertToTitle(int n)
		{
			StringBuilder sb = new StringBuilder();
			while (n > 0)
			{
				sb.Insert(0, (char)((n - 1) % 26 + 'A'));
				n = (n - 1) / 26;
			}
			return sb.ToString();
		}

		public static int MajorityElement(int[] nums)
		{
			int length = (int)(nums.Length / 2);
			var temp = new Hashtable();
			foreach (var item in nums)
			{
				if (temp.ContainsKey(item))
				{
					temp[item] = (int)temp[item] + 1;
				}
				else
					temp.Add(item, 1);
			}

			foreach (var key in temp.Keys)
			{
				if ((int)temp[key] > length)
					return (int)key;
			}
			return -1;

			// Moore's voting algorithm
			//int count = 1;
			//int temp = nums[0];
			//for (int i = 1; i < nums.Length; i++)
			//{
			//	if (count == 0)
			//	{
			//		temp = nums[i];
			//	}

			//	if (temp != nums[i])
			//	{
			//		count--;
			//	}
			//	else
			//	{
			//		count++;
			//	}
			//}
			//return temp;
		}

		public static int TitleToNumber(string s)
		{
			return s.Select(c => c - 'A' + 1).Aggregate(0, (temp, current) => temp * 26 + current);
		}

		public static int TrailingZeroes(int n)
		{
			int count = 0;
			for (int i = n / 5; i > 0; i /= 5)
			{
				count = count + i;
			}
			return count;

			// slower solution
			//double temp = 1;
			//while (n != 1)
			//{
			//	temp = temp * n;
			//	n--;
			//}
			//Console.WriteLine(temp);
			//int count = 0;
			//while (temp % 10 == 0)
			//{
			//	temp = temp / 10;
			//	count++;
			//}
			//return count;
		}

		public void Rotate(int[] nums, int k)
		{
			k = k % nums.Length;
			Array.Reverse(nums);

			Array.Reverse(nums, 0, k);
			Array.Reverse(nums, k, nums.Length - k);

			//faster solution

			//int[] a = new int[nums.Length];
			//for (int i = 0; i < nums.Length; i++)
			//{
			//	a[(i + k) % nums.Length] = nums[i];
			//}
			//for (int i = 0; i < nums.Length; i++)
			//{
			//	nums[i] = a[i];
			//}

		}

		public static uint reverseBits(uint n)
		{
			uint res = 0;

			for (int i = 0; i < 32; i++)
			{
				var ibit = (n >> i) & 1;
				res = (res << 1) + ibit;
			}

			return res;
		}

		public static int HammingWeight(uint n)
		{
			int bits = 0;
			int mask = 1;
			for (int i = 0; i < 32; i++)
			{
				if ((n & mask) != 0)
				{
					bits++;
				}
				mask <<= 1;
			}
			return bits;
		}

		public static int Rob(int[] nums)
		{
			var temp = new int[nums.Length + 1, 2];
			for (int i = 1; i <= nums.Length; i++)
			{
				temp[i, 0] = Math.Max(temp[i - 1, 0], temp[i - 1, 1]);
				temp[i, 1] = temp[i - 1, 0] + nums[i - 1];
			}
			return Math.Max(temp[nums.Length, 0], temp[nums.Length, 1]);

			// faster way
			//int evenSum = 0;
			//int oddSum = 0;
			//for (int i = 0; i < nums.Length; i++)
			//{
			//	if (i % 2 == 0)
			//	{
			//		evenSum += nums[i];
			//		evenSum = evenSum > oddSum ? evenSum : oddSum;
			//	}
			//	else
			//	{
			//		oddSum += nums[i];
			//		oddSum = oddSum > evenSum ? oddSum : evenSum;
			//	}
			//}
			//return evenSum > oddSum ? evenSum : oddSum;
		}
		public static bool IsHappy(int n)
		{
			var temp = new Dictionary<int, bool>();
			int count = n;
			while (!temp.ContainsKey(count))
			{
				temp.Add(count, true);
				int value = count;
				count = 0;

				while (value != 0)
				{
					count += (value % 10) * (value % 10);
					value /= 10;
					// Console.WriteLine(count);
				}
				if (count == 1) return true;
			}
			return false;
		}

		public static int CountPrimes(int n)
		{
			//var isNotPrime = new bool[n];

			//for (var i = 2; i < n; i++)
			//{
			//	if (isNotPrime[i]) continue;
			//	var start = i + i;
			//	while (start < n)
			//	{
			//		isNotPrime[start] = true;
			//		start += i;
			//	}
			//}
			//// remove 0 and 1
			//return isNotPrime.Skip(2).Count(x => x == false);
			var isPrime = new bool[n];

			for (int i = 2; i < n; i++)
			{
				isPrime[i] = true;
			}

			for (int i = 2; i * i < n; i++)
			{
				if (!isPrime[i]) continue;
				for (int j = i * i; j < n; j += i)
				{
					isPrime[j] = false;
				}
			}
			int count = 0;
			for (int i = 2; i < n; i++)
			{
				if (isPrime[i]) count++;
			}
			return count;
		}

		public bool IsIsomorphic(string s, string t)
		{
			if (s.Length != t.Length)
			{
				return false;
			}
			var str1 = new Dictionary<char, char>();
			var str2 = new Dictionary<char, char>();
			int length = s.Length;
			for (int i = 0; i < length; i++)
			{
				if (str1.ContainsKey(s[i]))
				{
					if (str1[s[i]] != t[i])
					{
						return false;
					}
				}
				else
				{
					str1.Add(s[i], t[i]);
				}
				if (str2.ContainsKey(t[i]))
				{
					if (str2[t[i]] != s[i])
					{
						return false;
					}
				}
				else
				{
					str2.Add(t[i], s[i]);
				}
			}
			return true;
		}

		//public ListNode ReverseList(ListNode head)
		//{
		//	var tempStack = new Stack<ListNode>();
		//	var tempHead = head;
		//	while (tempHead != null)
		//	{
		//		tempStack.Push(tempHead);
		//		// Console.WriteLine(head.val);
		//		tempHead = tempHead.next;
		//	}
		//	/*
		//	foreach(var item in tempStack){
		//		Console.WriteLine(item.val);
		//	}
		//	*/
		//	var temp = new ListNode(0);
		//	tempHead = temp;
		//	while (tempStack.Count != 0)
		//	{
		//		// Console.WriteLine(tempStack.Pop().val);
		//		tempHead.next = tempStack.Pop();
		//		tempHead = tempHead.next;
		//		// temp = temp.next;
		//		// Console.WriteLine(tempStack.Pop().val);
		//	}
		//	tempHead.next = null;
		//	return temp.next;

		// another solution:
		//var fakeHead = new ListNode(-1);
		//      while(head!=null){
		//          var next = head.next;
		//head.next = fakeHead.next;
		//          fakeHead.next = head;
		//          head = next;
		//      }
		//      return fakeHead.next;

		// recursive solution
		//if(head == null || head.next == null){
		//	return head;
		//}
		//var rest = ReverseList(head.next);

		//head.next.next = head;
		//head.next = null;

		//return rest;
		//}

		//public static bool ContainsDuplicate(int[] nums)
		//{
		//	HashSet<int> temp = new HashSet<int>();
		//	for (int i = 0; i < nums.Length; i++)
		//	{
		//		if (temp.Contains(nums[i]))
		//			return true;
		//		else
		//		{
		//			temp.Add(nums[i]);
		//		}
		//	}
		//	return false;
		// linq 
		// return nums.Count() > nums.Distinct().Count();
		// }

		//public static bool ContainsNearbyDuplicate(int[] nums, int k)
		//{
		//	var myDictionary = new Dictionary<int, int>();

		//	for (var i = 0; i < nums.Length; i++)
		//	{
		//		if (myDictionary.ContainsKey(nums[i]))
		//		{
		//			if (i - myDictionary[nums[i]] <= k)
		//				return true;
		//			else
		//				myDictionary[nums[i]] = i;
		//		}
		//		else
		//			myDictionary.Add(nums[i], i);
		//	}

		//	return false;

		//}

		//public class MyStack
		//{

		//	/** Initialize your data structure here. */
		//	public MyStack()
		//	{

		//	}

		//	/** Push element x onto stack. */
		//	public void Push(int x)
		//	{

		//	}

		//	/** Removes the element on top of the stack and returns that element. */
		//	public int Pop()
		//	{

		//	}

		//	/** Get the top element. */
		//	public int Top()
		//	{

		//	}

		//	/** Returns whether the stack is empty. */
		//	public bool Empty()
		//	{

		//	}
		//}
	}
	}
