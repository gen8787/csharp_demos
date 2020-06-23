/* 
  1. Mon
    1. isEmpty
    2. min (with & without recursion)
    3. max (with & without recursion)

  2. Tue
    1. contains (with & without recursion)
*/

class Node {
  constructor(val) {
    this.val = val;
    this.left = null;
    this.right = null;
  }
}

class BinarySearchTree {
  constructor() {
    this.root = null;
  }

  // Time: O(1) constant
  // Space: O(1)
  isEmpty() {
    return this.root === null;
  }

  // show without params first, so adding param can be a lesson for min of right sub tree: bst.min(bst.root.right)
  // Time: O(h) linear, h = height of left sub tree starting from current node
  // Space: O(1)
  min(current = this.root) {
    if (current === null) {
      return null;
    }

    while (current.left) {
      current = current.left;
    }
    return current.val;
  }

  // Time: O(h) linear, h = height of left sub tree starting from current node
  // Space: O(1)
  minRecursive(current = this.root) {
    if (current === null) {
      return null;
    }

    if (current.left === null) {
      return current.val;
    }
    return this.minRecursive(current.left);
  }

  // show without params first, so adding param can be a lesson for max of left sub tree: bst.max(bst.root.left)
  // Time: O(h) linear, h = height of right sub tree starting from current node
  // Space: O(1)
  max(current = this.root) {
    if (current === null) {
      return null;
    }

    while (current.right) {
      current = current.right;
    }
    return current.val;
  }

  // Time: O(h) linear, h = height of right sub tree starting from current node
  // Space: O(1)
  maxRecursive(current = this.root) {
    if (current === null) {
      return null;
    }

    if (current.right === null) {
      return current.val;
    }
    return this.minRecursive(current.right);
  }
}

const emptyTree = new BinarySearchTree();
const oneNodeTree = new BinarySearchTree();
oneNodeTree.root = new Node(10);

/* twoLevelTree 
        root
        10
      /   \
    5     15
*/
const twoLevelTree = new BinarySearchTree();
twoLevelTree.root = new Node(10);
twoLevelTree.root.left = new Node(5);
twoLevelTree.root.right = new Node(15);

/* fullTree
                    root
                <-- 25 -->
              /            \
            15             50
          /    \         /    \
        10     22      35     70
      /   \   /  \    /  \   /  \
    4    12  18  24  31  44 66  90
*/
