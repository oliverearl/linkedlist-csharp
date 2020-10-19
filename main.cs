using System;

public class MainClass
{
  public static void Main(string[] args)
  {
    LinkedList list = new LinkedList();

    list.push("England");
    list.push("Wales");
    list.push("Scotland");
    list.push("Northern Ireland");
    list.print();

    list.pop(); 
    list.pop("England");
    list.print();
  }
}

public class LinkedList
{
  protected class Node
  {
    public string data;
    public Node next;
  }

  protected Node head;

  public LinkedList()
  {
    this.head = null;
  }

  public void push(string value) 
  {
    Node newNode = new Node();

    newNode.data = value;

    newNode.next = head;

    head = newNode;
  }

  public void pop()
  {
    if (head == null)
    {
      Console.WriteLine("Linked list is empty.");
      return;
    }
    head = head.next;
  }

  public void pop(string value)
  {
    Node current = head;
    Node previousNode = null;

    if (current != null && current.data.ToLower() == value.ToLower())
    {
      head = current.next;
      return;
    }

    while (current != null && current.data.ToLower() != value.ToLower())
    {
      previousNode = current;
      current = current.next;
    }

    if (current == null)
    {
      Console.WriteLine("Value does not exist in this list.");
      return;
    }

    previousNode.next = current.next;
  }

  public bool isEmpty()
  {
    return head == null;
  }

  public string peek()
  {
    if (!isEmpty())
    {
      return head.data;
    }
    Console.WriteLine("Nothing to return.");
    return null;
  }

  public bool search(string value)
  {
    Node current = head;
    bool found = false;

    while (current != null && !found)
    {
      if (current.data.ToLower() == value.ToLower())
      {
        found = true;
      }
      else
      {
        current = current.next;
      }
    }
    return found;
  }

  public void print()
  {
    if (head == null) 
    {
      Console.WriteLine("Linked list is empty.");
      return;
    }

    Node current = head;

    while (current != null) 
    {
      // The dollar sign indicates "string interpolation".
      // It allows you to print variables in a string without ugly concatenation.
      // It's a fancy way of writing Console.Write(current.data + "->");
      Console.Write($"{current.data}->");
      current = current.next;
    }
    Console.Write(Environment.NewLine);
  }
}