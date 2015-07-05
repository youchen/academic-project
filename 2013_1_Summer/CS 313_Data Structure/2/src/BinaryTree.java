package p2_Submit;
/**
 * Project 2 - Plot the Binary Search Tree.
 * @author Youchen Ren
 */
public class BinaryTree{
	private BinaryNode root;
	/**
	 * Two Constructors
	 */
	public BinaryTree(){root = null;} //constructs root -> null;

	public BinaryTree(int x){
		root = new BinaryNode(x);
	}
	/**
	 * Access methods - getLeft, getRight & getRootObj.
	 */
	public BinaryTree getLeft() throws BinaryTreeException {
		if(root == null) throw new BinaryTreeException("Empty Tree.");
		else{
			BinaryTree t = new BinaryTree();
			t.root = root.left;
			return t;
		}
	}
	public BinaryTree getRight() throws BinaryTreeException {
		if(root == null) throw new BinaryTreeException("Empty Tree.");
		else{
			BinaryTree t = new BinaryTree();
			t.root = root.right;
			return t;
		}
	}
	public int getRootObj() throws BinaryTreeException{
		if(root == null) throw new BinaryTreeException("Empty Tree.");
		else return root.element;
	}
	/**
	 * Update methods - setLeft and setRight.
	 */
	public void setLeft(BinaryTree t) throws BinaryTreeException{
		if(root == null) throw new BinaryTreeException("Empty Tree.");
		else root.left = t.root;
	}
	public void setRight(BinaryTree t) throws BinaryTreeException{
		if(root == null) throw new BinaryTreeException("Empty Tree.");
		else root.right = t.root;
	}
	/**
	 * Other methods - isEmpty, inorder & insert.
	 */
	public boolean isEmpty(){return root == null;}

	public static void inorder(BinaryTree t) throws BinaryTreeException{
		if(!t.isEmpty()){
			inorder(t.getLeft());
			System.out.println(t.getRootObj());
			inorder(t.getRight());
		}
	}
	public static BinaryTree insert(BinaryTree t, int x){
		if (t.isEmpty())
			return new BinaryTree(x);
		else{
			if((t.getRootObj()) < x)
				t.setRight(insert(t.getRight(), x));
			else
				t.setLeft(insert(t.getLeft(), x));
			return t;
		}
	}
}