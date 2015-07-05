
/**
 * CS313 Summer 2013
 * Project 1
 * 
 * @author Youchen Ren
 */
public class Polynomial {
	private Node head = new Node(0);
	private int size;
//Constructors***************************************
	Polynomial (){
		head.setNext(null);
		size = 0;
	}
	Polynomial (Node h){
		head = h;
		size = 0;
	}
//Methods********************************************
	public int size() {return size;}

	public void append(int e) {
		Node n = new Node(e);
		if (size == 0) head = n;
		else {
			Node cur = head;
			while(cur.getNext() != null) {
				cur = cur.getNext();
			}
			cur.setNext(n);
		}
		size++;
	}
	public static void print(Polynomial p) {
		Node n = p.head;
		while(n != null) {
			System.out.print(n.getElement()+" ");
			n = n.getNext();
		}
	}
	public Node getFront() {
		return this.head;
	}
//Method of "sum" & "product"********************************************************
	public static Polynomial sum(Polynomial p1, Polynomial p2) {
		Node p1h = p1.head;
		Node p2h = p2.head;
		Node sumPh = new Node(0);
		Node newNode;
		Polynomial sumP = new Polynomial(sumPh);
		Node temp = sumPh;
		int s, p1int = 0, p2int = 0;
		boolean flag = true;
		while(flag) {
			if (p1h == null && p2h != null) {
				p1int = 0;
				p2int = p2h.getElement();
			}
			else if (p2h == null && p1h != null) {
				p2int = 0;
				p1int = p1h.getElement();
			}
			else {
				p1int = p1h.getElement();
				p2int = p2h.getElement();
			}
			s = p1int + p2int;
			temp.setElement(s);
			if (p1h == null && p2h != null) {
				p2h = p2h.getNext();
			}
			else if (p2h == null && p1h != null) {
				p1h = p1h.getNext();
			}
			else {
				p1h = p1h.getNext();
				p2h = p2h.getNext();
			}
			if(p1h == null && p2h == null) {
				flag = false;
			}
			else{
				newNode = new Node(0);
				temp.setNext(newNode);
				sumP.size++;
				temp = temp.getNext();
			}
		}//while
		return sumP;
	}//sum method
	public static Polynomial product(Polynomial p1, Polynomial p2) {
		Node p1h = p1.head;
		Node p2h = p2.head;
		Node proPh = new Node(0);
		Node newNode;
		Polynomial productP = new Polynomial(proPh);
		Node temp = proPh;
		int CompuCount = 0;
		while(p1h != null) {
			while(p2h != null) {
				temp.setElement((p1h.getElement()*p2h.getElement()) + temp.getElement());
				if((p2h.getNext()!= null) && (temp.getNext() == null)) {
					newNode = new Node(0);
					temp.setNext(newNode);
					productP.size++;
				}
				p2h = p2h.getNext();
				temp = temp.getNext();
			}
			p2h = p2.head;
			p1h = p1h.getNext();
			temp = productP.head;
			CompuCount++;
			for (int i = 1; i <= CompuCount; i++) {
				temp = temp.getNext();
			}
		}
		return productP;
	}//product method
}//class Polynomial
