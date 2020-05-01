/* 
  w4d2
    - create the BST class and the BSTNode class
      - a BST has a root instead of a head (because it's a tree)
      - a BSTNode has a left, right, and val or data instead of next
    - BST Max return the max with and without recursion
    - BST Min return the min with and without recursion

  w4d3
    - BST Contains (with & without recursion)
    - min of right sub tree (how can non-recursive min & max be adapted to work for this?)
    - max of left sub tree

  w4d4
    - BST Add
      - add a new value to the appropriate place in the tree, if the new value is equal to an existing value, add it to the left
    - BST Range
      - (Range is max minus min. What if tree is empty?)

  w4d5
    - print all vals as one space separated string
    - BST Size (recursive: total number of nodes)
*/

/* 
                  50
                /   \
              40    60
            /  \    / \
          30   45 55  70
        /   \        /
      20    35     65
        \
        25
*/

class BSTNode {
  constructor(val) {
    this.val = val;
    this.left = null;
    this.right = null;
  }
}

class BST {
  constructor() {
    this.root = null;
  }

  isEmpty() {
    return this.root === null;
  }

  // bst.min(myBst.root.right) would let us get the min value of the right sub-tree
  min(current = this.root) {
    if (current === null) {
      return null;
    }

    while (current.left) {
      current = current.left;
    }
    return current.val;
  }

  minRecursive(current = this.root) {
    if (current === null) {
      return null;
    }

    if (current.left === null) {
      return current.val;
    }

    return this.minRecursive(current.left);
  }

  // bst.max(myBst.root.left) would let us get the max vlaue of the right sub-tree
  max(current = this.root) {
    if (current === null) {
      return null;
    }

    while (current.right) {
      current = current.right;
    }
    return current.val;
  }

  maxRecursive(current = this.root) {
    if (current === null) {
      return null;
    }

    if (current.right === null) {
      return current.val;
    }

    return this.minRecursive(current.right);
  }

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

  range(startNode = this.root) {
    if (!startNode) {
      return null;
    }
    return this.max(startNode) - this.min(startNode);
  }

  add(newVal) {
    const node = new BSTNode(newVal);

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

  print(node = this.root) {
    if (!node) {
      return "";
    }
    return node.val + " " + this.print(node.left) + this.print(node.right);
  }

  printSeparator(node = this.root, separator = ", ", first = true) {
    if (!node) {
      return "";
    }

    const nodeStr = first ? node.val : separator + node.val;

    return (
      nodeStr +
      this.printSeparator(node.left, separator, false) +
      this.printSeparator(node.right, separator, false)
    );
  }

  size(node) {
    if (!node) {
      return 0;
    }
    return 1 + this.size(node.left) + this.size(node.right);
  }
}

/* 
                  50
                /   \
              40    60
            /  \    / \
          30   45 55  70
        /   \        /
      20    35     65
        \
        25
*/

const bst = new BST();

bst.add(50);
bst.add(40);
bst.add(60);
bst.add(70);
bst.add(45);
bst.add(30);
bst.add(35);
bst.add(20);
bst.add(25);
bst.add(65);
bst.add(55);

console.log(bst.print());
