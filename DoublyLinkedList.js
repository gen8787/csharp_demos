/* 
  - A Doubly Linked List is a singly linked list with the added functionality of being able to traverse in both directions.
  - Since you can traverse forwards or backwards, that means you should be able to start at the head or tail (end). After creating the necessary classes, then build the following methods:

  Week3
    4. Thur
      - Create the necessary classes then build the below methods:
        - insertAtBack
          - given some new data, add it to the back of the DList
        - insertAtFront
        - removeMiddleNode

  5. Fri
    - insertAfter
      - add new val after a target val
    - insertBefore
      - add new val before a target val
*/

class DLLNode {
  constructor(data) {
    this.data = data;
    this.prev = null;
    this.next = null;
  }
}

class DoublyLinkedList {
  constructor() {
    this.head = null;
    this.tail = null;
  }

  isEmpty() {
    return this.head === null;
  }

  // Time: O(1) constant
  // Space: O(1)
  insertAtFront(data) {
    const newNode = new DLLNode(data);

    if (!this.head) {
      this.head = this.tail = newNode;
    } else {
      this.head.prev = newNode;
      newNode.next = this.head;
      this.head = newNode;
    }
    return this;
  }

  // Time: O(1) constant, on a single linked list with no tail pointer same operation is O(n)
  // Space: O(1)
  insertAtBack(data) {
    const newTail = new DLLNode(data);

    if (!this.head) {
      // if no head set the newTail to be both the head and the tail
      this.head = this.tail = newTail;
    } else {
      this.tail.next = newTail;
      newTail.prev = this.tail;

      this.tail = newTail;
    }
    return this;
  }

  // Time: O(n / 2) -> O(n) linear, n = list length
  // Space: O(1) constant
  removeMiddleNode() {
    let forwardRunner = this.head;
    let backwardsRunner = this.tail;

    while (forwardRunner && backwardsRunner) {
      // move the runners first so if the head is only node
      // it won't be compared to itself and considered the middle
      forwardRunner = forwardRunner.next;
      backwardsRunner = backwardsRunner.prev;

      if (forwardRunner === backwardsRunner) {
        let midNode = forwardRunner;

        midNode.prev.next = midNode.next;
        midNode.next.prev = midNode.prev;
        return midNode.data;
      }
      if (forwardRunner.next === backwardsRunner) {
        /**
         * happens if even lengthed list, there is no middle
         * so return to exit early before getting to the ends of list
         * this will return undefined which is what .pop() returns if
         * called on an empty array
         */
        return null;
      }
    }
  }

  // can also send a runner from both sides to find the val in fewer iterations
  // Time: O(n) linear, n = list length. targetVal could be at opposite of starting side
  // Space: O(1)
  insertAfter(targetVal, newVal) {
    const newNode = new DLLNode(newVal);
    let runner = this.head;

    while (runner) {
      if (runner.data === targetVal) {
        newNode.prev = runner;
        newNode.next = runner.next;
        runner.next.prev = newNode;
        runner.next = newNode;

        if (runner === this.tail) {
          this.tail = newNode;
        }
        return true;
      } else {
        runner = runner.next;
      }
    }
    return false;
  }

  // Time: O(n) linear, n = list length. targetVal could be at opposite of starting side
  // Space: O(1)
  insertBefore(targetVal, newVal) {
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
}
