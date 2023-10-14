Solution solution = new();
Console.WriteLine(string.Join(", ", solution.SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 8)));
Console.WriteLine(string.Join(", ", solution.SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 6)));
Console.WriteLine(string.Join(", ", solution.SearchRange(new int[] { }, 1)));

public class Solution
{
	private int BinarySearch(int[] nums, int target, bool isLeft = true)
	{
		int left = 0;
		int right = nums.Length - 1;
		while (left <= right)
		{
			int middle = left + (right - left) / 2;
			if (nums[middle] == target)
			{
				if (isLeft)
				{
					if (middle == 0 || nums[middle - 1] != target)
					{
						return middle;
					}
					else
					{
						right = middle - 1;
					}
				}
				else
				{
					if (middle == nums.Length - 1 || nums[middle + 1] != target)
					{
						return middle;
					}
					else
					{
						left = middle + 1;
					}
				}
			}
			else if (nums[middle] < target)
			{
				left = middle + 1;
			}
			else
			{
				right = middle - 1;
			}
		}
		return -1;
	}

	public int[] SearchRange(int[] nums, int target)
	{
		if (nums.Length == 0)
		{
			return new int[] { -1, -1 };
		}
		int leftIdx = BinarySearch(nums, target);
		if (leftIdx < 0)
		{
			return new int[] { -1, -1 };
		}
		int rightIdx = BinarySearch(nums, target, false);
		return new int[] { leftIdx, rightIdx };
	}
}