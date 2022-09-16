LinkedList<string> names = new LinkedList<string>();
LinkedList<int> ages = new LinkedList<int>();

names.addNode("Max");
names.addNode("Zac");
names.addNode("Chris");

ages.addNode(1);
ages.addNode(2);
ages.addNode(3);

names.printData();
ages.printData();

class LinkedList<T>
{
    public T type { get; set; }

    Node head;

    public LinkedList()
    {
        head = null;
    }

    public void addNode(T newData)
    {
        Node newNode = new Node(newData);
        newNode.next = head;
        head = newNode;
    }

    public void printData()
    {
        Node currentData = head;
        while (currentData != null)
        {
            Console.WriteLine(currentData.data);
            currentData = currentData.next;
        }
    }
    class Node
    {
        public T data { get; set; }
        public Node next { get; set; }

        public Node(T Data)
        {
            data = Data;
            next = null;
        }
    }
}
