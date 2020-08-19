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

fullTree.print();
