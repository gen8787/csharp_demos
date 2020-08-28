/* 
  4. Thur
    - A Doubly Linked List is a singly linked list with the added functionality of being able to traverse in both directions.
    - Since you can traverse forwards or backwards, that means you should be able to start at the head or tail (end). After creating the necessary classes, then build the following methods:
      - insertAtFront
        - given some new data, add it as the new head
      - insertAtBack
        - given some new data, add it to the back of the DList
      - removeMiddleNode
  5. Fri
    - insertAfter
      - add new val after a target val
    - insertBefore
      - add new val before a target val
*/

class Node {
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
    // if not empty there should always be a head and a tail, but to be safe we check both in case
    // the list is malformed meaning it has either a head or a tail but not both
    return this.head === null && this.tail === null;
  }

  seedFromArr(arr) {
    for (let i = 0; i < arr.length; i++) {
      this.insertAtBack(arr[i]);
    }
    return this;
  }

  // Time: O(n) linear, n = list length
  // Space: O(n)
  print() {
    let runner = this.head;
    let vals = "";

    while (runner) {
      vals += `${runner.data}${runner.next ? ", " : ""}`;
      runner = runner.next;
    }
    console.log(vals);
    return vals;
  }

  // Time: O(1) constant
  // Space: O(1)
  insertAtFront(data) {
    const newNode = new Node(data);

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
    const newTail = new Node(data);

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

  // Is there a middle when it's even? Some say yes, some say no. This assumes there is no middle when even
  // Time: O(0.5n) -> O(n) linear, n = list length (without our early exists, it would not be 0.5n)
  // Space: O(1) constant
  removeMiddleNode() {
    // when there is only 1 node, it is the middle, remove it.
    if (!this.isEmpty() && this.head === this.tail) {
      const removedData = this.head.data;
      this.head = null;
      this.tail = null;
      return removedData;
    }

    let forwardRunner = this.head;
    let backwardsRunner = this.tail;

    while (forwardRunner && backwardsRunner) {
      if (forwardRunner === backwardsRunner) {
        const midNode = forwardRunner;
        midNode.prev.next = midNode.next;
        midNode.next.prev = midNode.prev;
        return midNode.data;
      }

      // runners passed each other without stopping on the same node, even length, we can exit early
      if (forwardRunner.prev === backwardsRunner) {
        return null;
      }

      forwardRunner = forwardRunner.next;
      backwardsRunner = backwardsRunner.prev;
    }
    return null;
  }

  // can also send a runner from both sides to find the val in fewer iterations
  // Time: O(n) linear, n = list length. targetVal could be at opposite of starting side
  // Space: O(1)
  insertAfter(targetVal, newVal) {
    const newNode = new Node(newVal);
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
    const newNode = new Node(newVal);
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

  // alternatively for insertAfter & insertBefore since they share a lot of the same logic we can do something like this
  insertAft(targetVal, newVal) {
    return this.insertPositionally(targetVal, newVal, "after");
  }

  insertBef(targetVal, newVal) {
    return this.insertPositionally(targetVal, newVal, "before");
  }

  insertPositionally(targetVal, newVal, position) {
    const newNode = new Node(newVal);
    let runner = this.head;

    while (runner) {
      if (runner.data === targetVal) {
        if (position === "before") {
          newNode.next = runner;
          newNode.prev = runner.prev;
          runner.prev.next = newNode;
          runner.prev = newNode;

          if (runner === this.head) {
            this.head = newNode;
          }
        } else if (position === "after") {
          newNode.prev = runner;
          newNode.next = runner.next;
          runner.next.prev = newNode;
          runner.next = newNode;

          if (runner === this.tail) {
            this.tail = newNode;
          }
        }
        return true;
      } else {
        runner = runner.next;
      }
    }
    return false;
  }
}

const emptyList = new DoublyLinkedList();
const singleNodeList = new DoublyLinkedList().insertAtBack(1);
const biNodeList = new DoublyLinkedList().insertAtBack(1).insertAtBack(2);
const firstThreeList = new DoublyLinkedList().seedFromArr([1, 2, 3]);

const secondThreeList = new DoublyLinkedList().seedFromArr([4, 5, 6]);
const unorderedList = new DoublyLinkedList().seedFromArr([
  -5,
  -10,
  4,
  -3,
  6,
  1,
  -7,
  -2,
]);

const sortedDupeList = new DoublyLinkedList().seedFromArr([
  1,
  1,
  1,
  2,
  3,
  3,
  4,
  5,
  5,
]);
