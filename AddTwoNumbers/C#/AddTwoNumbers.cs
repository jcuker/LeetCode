/*
You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Input: (2 -> 4 -> 3) + (5 -> 6 -> 4) (342 + 465) = 807
Output: 7 -> 0 -> 8
*/

using System;

namespace LeetCode
{
    public class AddTwoNumbersSolution
    {
        // definiton was provided
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            String strFirstNum = "";
            String strSecondNum = "";

            while (l1 != null)
            {
                strFirstNum += l1.val.ToString();
                l1 = l1.next;
            }

            while (l2 != null)
            {
                strSecondNum += l2.val.ToString();
                l2 = l2.next;
            }

            int intFirstNumber = int.Parse(Reverse(strFirstNum));
            int intSecondNumber = int.Parse(Reverse(strSecondNum));

            int intSum = intFirstNumber + intSecondNumber;

            ListNode returnValue = BuildListNode(intSum);
            return returnValue;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static ListNode BuildListNode(int intSum)
        {
            String strSumReversed = Reverse(intSum.ToString());

            ListNode returnNode = new ListNode(int.Parse(strSumReversed[0].ToString()));

            int intIndex = 1;
            ListNode objCursor = returnNode;

            while (intIndex < strSumReversed.Length)
            {
                ListNode tempNode = new ListNode(int.Parse(strSumReversed[intIndex].ToString()));
                objCursor.next = tempNode;
                objCursor = tempNode;
                intIndex++;
            }

            return returnNode;
        }

        public static void Main()
        {
            ListNode temp, cursor;
            ListNode firstList = new ListNode(2);
            temp = new ListNode(4);
            firstList.next = temp;

            cursor = temp;
            temp = new ListNode(3);
            cursor.next = temp;

            ListNode secondList = new ListNode(5);
            temp = new ListNode(6);
            secondList.next = temp;
            
            cursor = temp;
            temp = new ListNode(4);
            cursor.next = temp;

            ListNode result = AddTwoNumbers(firstList, secondList);
            Console.Write("First List: ");
            PrintList(firstList);
            Console.Write("Second List: ");
            PrintList(secondList);
            Console.Write("Result: ");
            PrintList(result);
        }

        public static void PrintList(ListNode list)
        {
            while (list != null)
            {
                Console.Write(list.val.ToString());
                list = list.next;
                if(list != null)
                {
                    Console.Write(" -> ");
                }
            }

            Console.WriteLine("");
        }
    }
}