using System;
namespace LinkedList{
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
			 return ;
		 }
		 
		 Node current = head;
		 while(current.Next != null){
		 	current = current.Next;
		 }
		 current.Next = newNode;
	 }
	 
	 public void Prepend(int data){
	 	
		 Node newNode = new Node(data);
		 newNode.Next = head;
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
	
	public void Remove(int data){
		
		if(head == null) return ;
		
		if(head.Data == data){
			head = head.Next;
			return;
		}
		Node current = head ;
		
		while(current != null && current.Next.Data != data){
			 current = current.Next;
		}
		
		if(current.Next != null){
			current.Next = current.Next.Next;
		}
	}
	
	public bool Contains(int data){
		
		Node current = head ;
		while(current != null){
		     if(current.Data == data){
			 	 return true;
			 }
			current = current.Next;
		}
		return false;
	}
	
	public int Count(){
		int count = 0;
		Node current = head;
		while(current != null){
			count++;
			current = current.Next;
		}
		return count;
	}
}
 class Program{
	public static void Main(){
		
		SinglyLinkedList list = new SinglyLinkedList();
		list.Append(10);
		list.Append(20);
		list.Prepend(5);
		list.Append(30);
		list.Print();
		list.Remove(30);
		list.Print();
		Console.WriteLine("Contains 20 :"+ list.Contains(20));
		Console.WriteLine("Total nodes in LinkedList :" +list.Count());

	}
 }
}
