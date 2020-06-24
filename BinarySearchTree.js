/* 
  1. Mon
    1. isEmpty
    2. min (with & without recursion)
    3. max (with & without recursion)

  2. Tue
    1. contains (with & without recursion)

  3. Wed
    1. insert (with & without recursion)
        - insert the new value in the appropriate place in the tree
    2. range (Range is max minus min. What if tree is empty?)\
    Bonus: full (recursive: isFull if every node other than the leaves has two children)
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

  // Time: O(h) linear, h = height of tree
  // Space: O(1)
  contains(searchVal) {
    let current = this.root;

    while (current) {
      if (current.val === searchVal) {
        return true;
      }

      if (searchVal < current.val) {
        current = current.left;
      } else {
        current = current.right;
      }
    }
    return false;
  }

  // Time: O(h) linear, h = height of tree
  // Space: O(1)
  containsRecursive(searchVal, current = this.root) {
    if (current === null) {
      return false;
    }

    if (current.val === searchVal) {
      return true;
    }

    if (searchVal < current.val) {
      return this.containsRecursive(searchVal, current.left);
    }

    if (searchVal > current.val) {
      return this.containsRecursive(searchVal, current.right);
    }
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
