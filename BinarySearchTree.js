class Node {
  constructor(data) {
    this.data = data;
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

  // Time: O(h) linear, h = height of left sub tree starting from current node
  // Space: O(1)
  min(current = this.root) {
    if (current === null) {
      return null;
    }

    while (current.left) {
      current = current.left;
    }
    return current.data;
  }

  // Time: O(h) linear, h = height of left sub tree starting from current node
  // Space: O(1)
  minRecursive(current = this.root) {
    if (current === null) {
      return null;
    }

    if (current.left === null) {
      return current.data;
    }
    return this.minRecursive(current.left);
  }

  // Time: O(h) linear, h = height of right sub tree starting from current node
  // Space: O(1)
  max(current = this.root) {
    if (current === null) {
      return null;
    }

    while (current.right) {
      current = current.right;
    }
    return current.data;
  }

  // Time: O(h) linear, h = height of right sub tree starting from current node
  // Space: O(1)
  maxRecursive(current = this.root) {
    if (current === null) {
      return null;
    }

    if (current.right === null) {
      return current.data;
    }
    return this.minRecursive(current.right);
  }

  // Time: O(h) linear, h = height of tree
  // Space: O(1)
  contains(searchVal) {
    let current = this.root;

    while (current) {
      if (current.data === searchVal) {
        return true;
      }

      if (searchVal < current.data) {
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

    if (current.data === searchVal) {
      return true;
    }

    if (searchVal < current.data) {
      return this.containsRecursive(searchVal, current.left);
    }

    if (searchVal > current.data) {
      return this.containsRecursive(searchVal, current.right);
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

  // Time: O(h) linear, h = height of tree because we might be adding at bottom
  // Space: O(1)
  insert(newVal) {
    const node = new Node(newVal);

    if (this.isEmpty()) {
      this.root = node;
    } else {
      let current = this.root;

      while (true) {
        if (newVal <= current.data) {
          if (!current.left) {
            current.left = node;
            break;
          } else {
            current = current.left;
          }
        } else {
          // newVal is greater than current.data
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

    if (newVal > curr.data) {
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

  // DFS Preorder: (Parent, Left, Right)
  // on fullTree var: [25, 15, 10, 4, 12, 22, 18, 24, 50, 35, 31, 44, 70, 66, 90]
  toArrPreorder(node = this.root, vals = []) {
    if (node) {
      vals.push(node.data);
      this.toArrPreorder(node.left, vals);
      this.toArrPreorder(node.right, vals);
    }
    return vals;
  }

  // DFS Inorder: (Left, Parent, Right)
  // on fullTree var: [4, 10, 12, 15, 18, 22, 24, 25, 31, 35, 44, 50, 66, 70, 90]
  // Show the call stack of this in debugger and how it pops and then show the stack solution below to see the same thing with manual stack
  toArrInorder(node = this.root, vals = []) {
    if (node) {
      this.toArrInorder(node.left, vals);
      vals.push(node.data);
      this.toArrInorder(node.right, vals);
    }
    return vals;
  }

  // DFS Inorder: (Left, Parent, Right)
  toArrInorderNonRecursive(node = this.root) {
    let current = node;
    const stack = [],
      vals = [];

    while (true) {
      if (current !== null) {
        stack.push(current);
        current = current.left;
      } else if (stack.length > 0) {
        current = stack.pop();
        vals.push(current.data);
        current = current.right;
      } else {
        break;
      }
    }
    return vals;
  }

  // DFS Postorder (Left, Right, Parent)
  // on fullTree var: [4, 12, 10, 18, 24, 22, 15, 31, 44, 35, 66, 90, 70, 50, 25]
  toArrPostorder(root = this.root, vals = []) {
    if (root) {
      this.toArrPostorder(root.left, vals);
      this.toArrPostorder(root.right, vals);
      vals.push(root.data);
    }
    return vals;
  }

  // BFS order: horizontal rows left-to-right top-down
  // on fullTree var: [25, 15, 50, 10, 22, 35, 70, 4, 12, 18, 24, 31, 44, 66, 90]
  toArrLevelorder(current = this.root) {
    const queue = [],
      vals = [];

    if (current) {
      queue.push(current);
    }

    // other tree structures have more than a left and a right, so children could be looped over and enqueued
    while (queue.length > 0) {
      const dequeuedNode = queue.shift();
      vals.push(dequeuedNode.data);

      if (dequeuedNode.left) {
        queue.push(dequeuedNode.left);
      }

      if (dequeuedNode.right) {
        queue.push(dequeuedNode.right);
      }
    }
    return vals;
  }

  // prints tree with root on left and index in parens in reverse inorder traversal
  // https://www.geeksforgeeks.org/print-binary-tree-2-dimensions/
  print(node = this.root, spaceCnt = 0, spaceIncr = 10) {
    if (!node) {
      return;
    }

    spaceCnt += spaceIncr;
    this.print(node.right, spaceCnt);

    console.log(
      " ".repeat(spaceCnt < spaceIncr ? 0 : spaceCnt - spaceIncr) +
        `${node.data}`
    );

    this.print(node.left, spaceCnt);
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

console.log(fullTree.toArrPreorder());
