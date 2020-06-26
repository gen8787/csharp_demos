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

  4. Thur (Recursive Traversal Order)
    1. console.log each node's val in depth first search (DFS) Preorder: (Parent, Left, Right)
        - on fullBstTest, it should log in this order: 25, 15, 10, 4, 12, 22, 18, 24, 50, 35, 31, 44, 70, 66, 90
    2. console.log each node's val in depth first search (DFS) Inorder: (Left, Parent, Right)
        - on fullBstTest, it should log in this order: 4, 10, 12, 15, 18, 22, 24, 25, 31, 35, 44, 50, 66, 70, 90
    3. console.log each node's val in depth first search (DFS) Postorder: (Left, Right, Parent)
        - on fullBstTest, it should log in this order: 4, 12, 10, 18, 24, 22, 15, 31, 44, 35, 66, 90, 70, 50, 25

  5. Fri
    1. Non-recursive breadth first print:
        - console.log each node's val in level order, horizontal level-by-level
        - for the example commented tree the order would be: "50, 40, 60, 30, 45, 55, 70, 20, 35, 65, 25"
    2. size (recursive: total number of nodes)
    3. height (recursive: longest path from root to leaf)
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

  // Time: O(h) linear, h = height of tree because we might be adding at bottom
  // Space: O(1)
  insert(newVal) {
    const node = new Node(newVal);

    if (this.isEmpty()) {
      this.root = node;
    } else {
      let current = this.root;

      while (true) {
        if (newVal <= current.val) {
          if (!current.left) {
            current.left = node;
            break;
          } else {
            current = current.left;
          }
        } else {
          // newVal is greater than current.val
          if (!current.right) {
            current.right = node;
            break;
          } else {
            current = current.right;
          }
        }
      }
    }
    return this;
  }

  // Time: O(h) linear, h = height of tree
  // Space: O(1)
  insertRecursive(newVal, curr = this.root) {
    if (this.isEmpty()) {
      this.root = new Node(newVal);
      return this;
    }

    if (newVal > curr.val) {
      if (curr.right === null) {
        curr.right = new Node(newVal);
        return this;
      }
      return this.insertRecursive(newVal, curr.right);
    } else {
      if (curr.left === null) {
        curr.left = new Node(newVal);
        return this;
      }
      return this.insertRecursive(newVal, curr.left);
    }
  }

  // Time: O(rightHeight + leftHeight) -> still linear so simplify to O(h)
  // Space: O(1)
  range(startNode = this.root) {
    if (!startNode) {
      return null;
    }
    return this.max(startNode) - this.min(startNode);
  }

  isFull(node = this.root) {
    // if empty, or node is null
    if (!node) {
      return false;
    }

    // if leaf node
    if (!node.left && !node.right) {
      return true;
    }

    if (node.left && node.right) {
      return this.isFull(node.left) && this.isFull(node.right);
    }

    return false;
  }

  // DFS Preorder: (Parent, Left, Right)
  // on fullTree: 25, 15, 10, 4, 12, 22, 18, 24, 50, 35, 31, 44, 70, 66, 90
  printPreorder(node = this.root) {
    if (node) {
      console.log(node.val);
      this.printPreorder(node.left);
      this.printPreorder(node.right);
    }
  }

  // DFS Inorder: (Left, Parent, Right)
  // on fullTree: 4, 10, 12, 15, 18, 22, 24, 25, 31, 35, 44, 50, 66, 70, 90
  printInorder(node = this.root) {
    if (node) {
      this.printInorder(node.left);
      console.log(node.val);
      this.printInorder(node.right);
    }
  }

  // DFS Inorder: (Left, Parent, Right)
  printInorderStack(node = this.root) {
    let current = node;
    const stack = [];
    let str = "";

    while (true) {
      if (current !== null) {
        stack.push(current);
        current = current.left;
      } else if (stack.length > 0) {
        current = stack.pop();
        console.log(current.val);

        str += current.val + " ";
        current = current.right;
      } else {
        break;
      }
    }
    return str;
  }

  // DFS Postorder (Left, Right, Parent)
  // on fullTree: 4, 12, 10, 18, 24, 22, 15, 31, 44, 35, 66, 90, 70, 50, 25
  printPostorder(root = this.root) {
    if (root) {
      this.printPostorder(root.left);
      this.printPostorder(root.right);
      console.log(root.val);
    }
  }

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

const fullTree = new BinarySearchTree();
fullTree
  .insert(25)
  .insert(15)
  .insert(10)
  .insert(22)
  .insert(4)
  .insert(12)
  .insert(18)
  .insert(24)
  .insert(50)
  .insert(35)
  .insert(70)
  .insert(31)
  .insert(44)
  .insert(66)
  .insert(90);

fullTree.printInorderStack();
