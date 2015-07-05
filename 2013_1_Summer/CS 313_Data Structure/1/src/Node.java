
/**
 * CS313 Summer 2013
 * Project 1
 * 
 * @author Youchen Ren
 */
public class Node {
	private int element;
	private Node next;
//Constructors***************************
	public Node (int e, Node n) {
		element = e;
		next = n;
	}
	public Node (int e) {
		this(e, null);
	}
//update methods*************************
	public void setElement(int e) {
		element = e;
	}
	public void setNext(Node n) {
		next = n;
	}
//access methods*************************
	public int getElement() {
		return element;
	}
	public Node getNext() {
		return next;
	}
}
