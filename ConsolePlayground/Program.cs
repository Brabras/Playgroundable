using ConsolePlayground;

var testNode1 = Solution.MakeNode(249);

var testNode2 = Solution.MakeNode(5649);

var result = Solution.AddTwoNumbers(testNode1, testNode2);

var firstNumber = result.val;
Console.Write(firstNumber);

while (result.next is not null)
{
    var num = result.next.val;
    firstNumber = firstNumber * 10 + num;
    result = result.next;
    Console.Write(firstNumber % 10);
}



public class Solution
{
    public static ListNode MakeNode(int number)
    {
        ListNode? result = null;
        while (number != 0)
        {
            var newNode = new ListNode(number % 10, result);
            result = newNode;
            number /= 10;
        }

        return result!;
    }
    
    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var firstNumber = l1.val;
        Console.Write(firstNumber);

        double tenIndex = 1;
        while (l1.next is not null)
        {
            var num = l1.next.val;
            firstNumber = int(firstNumber + Math.Pow(10D, tenIndex) * num);
            l1 = l1.next;
            tenIndex++;
            Console.Write(firstNumber % 10);
        }

        var secondNumber = l2.val;
        Console.WriteLine();
        Console.Write(secondNumber);

        while (l2.next is not null)
        {
            var num = l2.next.val;
            secondNumber = secondNumber * 10 + num;
            l2 = l2.next;
            Console.Write(secondNumber % 10);
        }

        var thirdNumber = firstNumber + secondNumber;

        var firstNode = new ListNode(thirdNumber % 10);
        thirdNumber /= 10;
        var currentNode = firstNode;
        while (thirdNumber != 0)
        {
            var lastNode = new ListNode(thirdNumber % 10);
            currentNode.next = lastNode;
            currentNode = lastNode;
            thirdNumber /= 10;
        }

        return firstNode;
    }
}