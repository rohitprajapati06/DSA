using System;

namespace HelloWorld
{
  class Node{
  		
       public int Data;
       public Node Next;
       
       public Node(int data){
       		
            Data = data;
            Next = null;
       }
  }
  
  class CircularSinglyLinkedList{
  		
        private Node tail;
        
        public void Append(int data){
        	
            Node newNode = new Node(data);
        	if(tail == null){
            	tail = newNode;
                tail.Next = tail;
            }else{
            	 newNode.Next = tail.Next;
            	 tail.Next = newNode;
                 tail = newNode;
            }
        }
        
        public void Prepend(int data){
        	
            Node newNode = new Node(data);
            if(tail == null){
            	tail = newNode;
                return;
            }else{
            	newNode.Next = tail.Next;
                tail.Next = newNode;
            }
        }
        
        public void Display(){
        	
            Node temp = tail.Next;
            if(temp == null){
            	Console.WriteLine("Linked List is Empty");
                return;
            }
            
            do{
            	Console.Write(temp.Data +" -> ");
                temp = temp.Next;

            }while(temp != tail.Next);
            Console.WriteLine("( back to start )");
        }
  }
  class Program
  {
    static void Main(string[] args)
    {
          CircularSinglyLinkedList list = new CircularSinglyLinkedList();
          list.Append(10);
          list.Append(20);
          list.Append(30);
          list.Prepend(5);
          list.Display();
          
    }
  }
}
