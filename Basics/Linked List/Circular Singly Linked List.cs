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
        
        public void Remove(int data){
        	
            Node current = tail.Next; // 5 - 10 - 20 - 30
            Node prev = tail;         //  30 - 5 - 10 - 20
            
            do{
            	 if(current.Data == data){
                 	
                     if(current == tail && current.Next == tail) // for single node in linked list
                     {
                     		tail = null ;
                        return ;
                     }else{
                     		prev.Next = current.Next;
                            if(current == tail){
                            	tail = prev ;
                            }
                     }
                     Console.WriteLine($"Deleted list {data}");
                     return;
                 }
                 
            prev = current; 
            current = current.Next; 
            
            }while(current != tail.Next);
                
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
          list.Remove(30);
          list.Display();
          
    }
  }
}
