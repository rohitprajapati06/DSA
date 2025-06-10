using System;

class Node{
	public int Data;
	public Node Next;
	
	public Node(int data){
		Data = data;
		Next = null;
	}
}

class SinglyLinkedList{
	
	private Node head;
	
	public void Append(int data){
		
		Node newNode = new Node(data);
		if(head == null){
			head = newNode;
			return;
		}
		Node current = head;
		while(current.Next != null){
			current = current.Next;
		}
		current.Next = newNode;
	}
	
	public void Print(){
		
		Node current = head ;
		while(current != null){
			Console.Write(current.Data + "-> ");
			current = current.Next;
		}
		Console.WriteLine("null");
	}
	
	public void Reverse(){
		
		Node prev = null ;
		Node current = head ;
		Node next = null;
		
		while(current != null){
			next = current.Next;
			current.Next = prev;
			prev = current;
			
			current = next;
			
		}
		 head = prev;
	}
}
public class Program
{
	public static void Main()
	{
		SinglyLinkedList list = new SinglyLinkedList();
		list.Append(20);
		list.Append(30);
		list.Append(10);
		list.Print();
		list.Reverse();
		list.Print();
	}
}
