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
}
