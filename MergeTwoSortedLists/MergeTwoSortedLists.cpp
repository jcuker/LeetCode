/**
 * Definition for singly-linked list. public class ListNode { public int val;
 * public ListNode next; public ListNode(int x) { val = x; } }
 *
 * Merge two sorted linked lists and return it as a new list. The new list
 * should be made by splicing together the nodes of the first two lists.
 *
 * Example:
 *
 * Input: 1->2->4, 1->3->4 Output: 1->1->2->3->4->4
 *
 */
#include <random>
#include <iostream>
#include <algorithm>
#include <ctime>
using namespace std;


struct ListNode {
	int val;
	ListNode *next;
	ListNode(int x) {
		this->val = x;
		this->next = nullptr;
	}
};


static void print(ListNode* ln) {
	ListNode* temp = ln;
	while (temp->next != nullptr) {
		std::cout << temp->val << "->";
		temp = temp->next;
	}
	std::cout << ("nullptr\n");
}

static ListNode* mergeTwoLists(ListNode* l1, ListNode* l2) {
	if (l1 == nullptr) {
		return l2;
	}
	else if (l2 == nullptr) {
		return l1;
	}
	int min = std::min(l1->val, l2->val);
	ListNode* merged = new ListNode(min);
	ListNode* temp1 = l1;
	ListNode* temp2 = l2;
	if (temp1->val == min) {
		temp1 = temp1->next;
	}
	else {
		temp2 = temp2->next;
	}
	while (temp1 != nullptr && temp2 != nullptr) {
		min = std::min(temp1->val, temp2->val);
		ListNode* next = merged;
		while (next->next != nullptr) {
			next = next->next;
		}
		next->next = new ListNode(min);
		if (temp1->val == min) {
			temp1 = temp1->next;
		}
		else {
			temp2 = temp2->next;
		}
	}
	while (temp1 != nullptr) {
		ListNode* next = merged;
		while (next->next != nullptr) {
			next = next->next;
		}
		next->next = new ListNode(temp1->val);
		temp1 = temp1->next;
	}
	while (temp2 != nullptr) {
		ListNode* next = merged;
		while (next->next != nullptr) {
			next = next->next;
		}
		next->next = new ListNode(temp2->val);
		temp2 = temp2->next;
	}

	return merged;
}

static ListNode* generateListNode(int randN[]) {
	ListNode* ln = new ListNode(randN[0]);
	for (int i = 1; i < 10; i++) {
		ListNode* temp = ln;
		while (temp->next != nullptr) {
			temp = temp->next;
		}
		temp->next = new ListNode(randN[i]);
	}
	return ln;
}


int main() {
	int arr[] = { 1,15,26,34,41,50,65,79,87,99 };
	ListNode* l1 = generateListNode(arr);
	int arr2[] = { 2,5,9,12,15,17,19,22,33,44 };
	ListNode* l2 = generateListNode(arr2);
	ListNode* merged = mergeTwoLists(l1, l2);
	print(merged);

	return 0;
}