/* 
  w3d3
    - create the necessary classes to design a double linked list
      - a linked list that allows you to traverse forwards AND backwards, allowing you to start at the front or the back
    
  w3d4
    - DList: Prepend Value
      - add new val before a target val
    - isNodeInLeftHalf: given a reference to a node, return whether it's in left half or not
*/

class DLLNode {
  constructor(data) {
    this.data = data;
    this.prev = null;
    this.next = null;
  }
}

class DLL {
  constructor() {
    this.head = null;
    this.tail = null;
  }

  prepend(targetVal, newVal) {
    const newNode = new DLLNode(newVal);
    let runner = this.head;

    while (runner) {
      if (runner.data === targetVal) {
        newNode.next = runner;
        newNode.prev = runner.prev;
        runner.prev.next = newNode;
        runner.prev = newNode;

        if (runner === this.head) {
          this.head = newNode;
        }
        return true;
      } else {
        runner = runner.next;
      }
    }
    return false;
  }

  isNodeInLeftHalf(node) {
    let amntToLeft = 0,
      amntToRight = 0;

    let leftRunner = node,
      rightRunner = node;

    while (leftRunner) {
      amntToLeft++;
      leftRunner = leftRunner.prev;
    }

    while (rightRunner) {
      amntToRight++;
      rightRunner = rightRunner.next;
    }

    return amntToLeft < amntToRight;
  }
}
