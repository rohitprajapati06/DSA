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
	
	public bool Contains(int data){
		
		 Node current = head;
		while(current != null){
			 
			if(current.Data == data){
				return true;
			}
			
			current = current.Next;
		}
		return false;
	}
	
	public void Delete(int data){
		
		Node newNode = new Node(data);
		if(head.Data == data){
			head = head.Next;
			head.Prev = null;
			return;
		}
		
		Node current = head ;
		while(current != null && current.Data != data){
			current = current.Next;
		}
		 if (current.Next != null)
            current.Next.Prev = current.Prev;

        if (current.Prev != null)
            current.Prev.Next = current.Next;
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

public class Program{
	public static void Main(string[] args){
		DoublyLinkedList list = new DoublyLinkedList();
			list.Append(10);
			list.Append(20);
			list.Append(30);
			list.Prepend(5);
			list.Print();
			Console.WriteLine("Linked List contains 20 : "+ list.Contains(20));
			list.Delete(30);
			list.Print();
			Console.WriteLine("Total Nodes in Linked List  : "+ list.Count());

	}
}
