package p2_Submit;
/**
 * Project 2 - Plot the Binary Search Tree.
 * @author Youchen Ren
 *
 */
public class BinaryNode{
	int element; //friendly data accessible by any class in the same package.
	BinaryNode left, right; 
	/**
	 * Two Constructors.
	 */
	BinaryNode(int e){this(e, null, null);}

	BinaryNode(int e, BinaryNode ln, BinaryNode rn){
		element = e;
		left = ln;
		right = rn;
	}
}//class BinaryNode