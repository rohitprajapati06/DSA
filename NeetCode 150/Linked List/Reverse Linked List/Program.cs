/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
 
public class Solution {
    public ListNode ReverseList(ListNode head) {
          
          ListNode Next = null;
          ListNode prev = null;
          ListNode current = head;

          while(current != null){
             Next = current.next;
             current.next = prev;   // next;
             prev = current;

             current = Next;

          }
            return prev;
    }
}
