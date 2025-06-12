using System;

public class Node{
	
	public int Data;
	public Node Prev;
	public Node Next;
	
	public Node(int data){
		Data = data;
		Next = null;
		Prev = null;
	}
}

public class DoublyLinkedList{
	
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
		newNode.Prev  = current;
		
	}
	
	public void Prepend(int data){
		
		Node newNode = new Node(data);
		
		if(head == null){
			head = newNode;
			return;
		}
		
		newNode.Next = head;
		head.Prev = newNode;
		head = newNode;
	}
	
   public void Print(){
   		
	   Node current = head;
	   while(current != null){
	   		Console.Write(current.Data + " -> ");
		    current = current.Next;
	   }
	   Console.WriteLine("null");
   }

}

public class Program{
	public static void Main(string[] args){
	DoublyLinkedList list = new DoublyLinkedList();
	list.Append(10);
	list.Append(20);
	list.Append(30);
	list.Prepend(5);
	list.Print();
	}
}
