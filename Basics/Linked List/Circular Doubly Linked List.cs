using System;

namespace HelloWorld
{
  
  class Node{
  		
        public int Data;
        public Node Next;
        public Node Prev;
        
        public Node(int data){
        	
            Data = data;
            Next = this;
            Prev = this;
        }
  }
  
  class CircularDoublyLinkedList{
  	
    	private Node head;
        
        public void Append(int data){
        	
             Node newNode = new Node(data);
             
             if(head == null){
             	 head = newNode;
                 return;
             }
             
             Node tail = head.Prev;
             
             tail.Next = newNode;
             newNode.Prev = tail;
             
             newNode.Next = head;
             head.Prev = newNode;            
        }
        
        public void Prepend(int data){
        	
             Append(data);
             head = head.Prev;
        }
        
        public void Print(){
        	
            Node temp = head;
            do{
            	Console.Write(temp.Data+" -> ");
                temp = temp.Next;
            }while(temp != head);
            Console.WriteLine(" back to start");
        }
  }
  class Program
  {
    static void Main(string[] args)
    {
      CircularDoublyLinkedList list = new CircularDoublyLinkedList();
      	 list.Append(10);
         list.Append(20);
         list.Append(30);
         list.Append(40);
         list.Prepend(5);
         list.Print();
    }
  }
}
