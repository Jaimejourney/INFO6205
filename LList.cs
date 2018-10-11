using System;

public class LList{

    public Node head;
    public int length { get; set; }
    public LList(){
        head = null;
        length = 0;
    }
    public void AddNodeToHead(int data){
        Node add = new Node(data);

        add.Next = head;
        head = add;
        length ++;

    }

    public void AddNode(int data){
        Node add = new Node(data);

        if(head == null){
            head = add;
            length ++;
            return;
        }
        Node temp = head;
        while(temp.Next != null)
            temp = temp.Next;
        
        temp.Next = add;
        length ++;
        

    }


    public Node FindNthFromEnd(int n){
        if(head == null || n <= 0)
            return null;
        
        Node front = head;
        Node back = head;
        for(int i = 0; i < n; i ++){
            front = front.Next;
            if(front == null)
                return null;
        }

        while(front != null){
            front = front.Next;
            back = back.Next;
        }
        return back;

    }
    

    public int GetCount(){
        if(head == null)
            return 0;
        
        int count = 0;
        Node temp = head;
        while(temp != null){
            temp = temp.Next;
            count ++;
        }

        return count;
    }
    public Node Reverse(Node node){

        if(node == null || node.Next == null)
            return null;

        Node back = null;
        Node mid = node;
        Node front = node.Next;

        while(front != null){
            mid.Next = back;
            back = mid;
            mid = front;
            front = front.Next;
        }
        mid.Next = back;

        return mid;
    }
    public void Reverse(){

        if(head == null || head.Next == null)
            return;

        Node back = null;
        Node mid = head;
        Node front = head.Next;

        while(front != null){
            mid.Next = back;
            back = mid;
            mid = front;
            front = front.Next;
        }
        mid.Next = back;

        head = mid;

    }

    public Node FindMid(){
        if(head == null || head.Next == null)
            return head;
        
        Node front = head;
        Node back = head;
        while(front != null){
            front = front.Next;
            if(front != null){
                front = front.Next;
                back = back.Next;
            }

        }
        return back;    

    }

    public bool IsPalindrome(){
        if(head == null || head.Next == null)
            return true;
        Node secondHalf = BreakListInHalf();
        Reverse(secondHalf);

        Node firstHalf = head;
        while(firstHalf != null || secondHalf != null){

            if(firstHalf.data != secondHalf.data)
                return false;
            firstHalf = firstHalf.Next;
            secondHalf = secondHalf.Next;
        }

        return true;

    }

    private Node FindLastNode(){
        if(head == null)
            return null;
        Node temp = head;
        while(temp.Next != null)
            temp = temp.Next;
        return temp;
    }

    public Node BreakListInHalf(){
        if(head == null || head.Next == null)
            return null;
        
        Node front = head;
        Node back = head;
        while(front != null){
            front = front.Next;
            if(front != null){
                front = front.Next;
                back = back.Next;
            }
        }
        Node temp = back.Next;
        back.Next = null;
        return temp;

    }

    public bool IsCyclic(){
        if(head == null || head.Next == null)
           return false;
        
        Node front = head;
        Node back = head;

        while(front != null){
            front = front.Next;
            if(front == null)
                return false;
            front = front.Next;
            back = back.Next;

            if(front == back)
                return true;

        }
        return false;

    }

    public void CreateCycle(){

        head = null;

        AddNode(1);
        AddNode(2);
        AddNode(3);
        AddNode(4);
        AddNode(5);
        AddNode(6);
        AddNode(7);
        Node mid = FindMid();
        AddNode(8);
        AddNode(9);
        AddNode(10);
        AddNode(11);
        AddNode(12);
        Node last = FindLastNode();
        last.Next = mid;
    }

    public void SortedMerge(){
        Node node1 = new Node(1);
        node1.Next = new Node(3);
        node1.Next.Next = new Node(5);
        node1.Next.Next.Next = new Node(7);


        Node node2 = new Node(2);
        node2.Next = new Node(4);
        node2.Next.Next = new Node(6);
        node2.Next.Next.Next = new Node(8);

        Node result = SortedMerge(node1, node2);
        Console.WriteLine();

    }

    private Node SortedMerge(Node node1, Node node2){
        Node result = null;
        if(node1 == null)
            return node2;
        if(node2 == null)
            return node1;
        if(node1.data < node2.data){
            result = node1;
            result.Next = SortedMerge(node1.Next, node2);
        }
        else{
            result = node2;
            result.Next = SortedMerge(node1, node2.Next);
        }
        return result;
    }

    public Node FindStartCycle(){
        if(head == null || head.Next == null)
           return null;
        
        Node front = head;
        Node back = head;
        while(front != null){
            front = front.Next;
            if(front == null)
                return null;
            front = front.Next;
            back = back.Next;

            if(front == back)
                break;
        }

        if(front == null)
            return null;
        // There is definitely a cycle

        back = head;

        while(front != back){
            front = front.Next;
            back = back.Next;
        }

        return back;
    }

    public void ZipMerge(){
        Node secondHalf = BreakListInHalf();
        Node firstHalf = head;

        secondHalf = Reverse(secondHalf);

        head = ZipMerge(firstHalf, secondHalf, true);

    }

    private Node ZipMerge(Node node1, Node node2, bool bSwitch){
        Node result = null;
        if(node1 == null)
            return node2;
        if(node2 == null)
            return node1;
        if(bSwitch == true){
            result = node1;
            result.Next = ZipMerge(node1.Next, node2, false);
        }
        else{
            result = node2;
            result.Next = ZipMerge(node1, node2.Next, true );
        }
        return result;

    }
}