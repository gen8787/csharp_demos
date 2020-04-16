/* 
  w2d1
    - A stack is a LIFO (Last in First Out) data structure
    - create a class to represent a stack using an array & another class for a stack using a singly linked list
      - create methods for each: push, pop, isEmpty, size, peek (return top item without removing)

  w2d2
    - A queue is a FIFO (First in First Out) data structure
    - create a class to represent a queue using an array & another class for a queue using a singly linked list
    - create methods for each classes: enqueue (add item), dequeue (remove and return item), isEmpty, size, front (return first item without removing)

  w2d3
    - compareQueues
      - write a method on the Queue class that will be given another Queue, determine if both queues are equal (all same items in same order)
        - DO NOT manually loop over the queue items, use the provided methods (enqueue and dequeue) to do the comparison
        - return whether or not they are equal and restore both queues to their original order

  w2d4
    - sumOfHalvesEqual
      - create a method on the Queue class that returns whether or not the sum of the first half of the queue is equal to the sum of the second half
      - DO NOT manually index the queue items, only use the provided queue methods, use no additional arrays or objects for storage
      - restore the queue to it's original state before returning
    - nextQueue
      - Design a Queue class that automatically sends every 3rd dequeued person object to a next queue that can be specified
      - Imagine a security queue where every 3rd person is randomly sent to an additional security queue
*/

class Stack {
  constructor(items = []) {
    this.items = items;
  }

  push(item) {
    this.items.push(item);
  }

  pop() {
    if (this.isEmpty()) {
      return "Underflow";
    }

    return this.items.pop();
  }

  peek() {
    // aka top
    return this.items[this.items.length - 1];
  }

  isEmpty() {
    return this.items.length === 0;
  }

  size() {
    return this.items.length;
  }

  print() {
    const str = this.items.join(" ");
    console.log(str);
    return str;
  }
}

class Node {
  constructor(data) {
    this.data = data;
    this.next = null;
  }
}

// can add to back and remove from back to maintain a LIFO pattern
// OR can add to front and remove from front, still maintains a LIFO pattern but is faster
// because it requires no looping to the end of the linked list
class SLStack {
  constructor() {
    this.head = null;
  }

  // add to top (add new head)
  push(val) {
    const newNode = new Node(val);

    if (this.head === null) {
      this.head = newNode;
    } else {
      newNode.next = this.head;
      this.head = newNode;
    }
  }

  // remove from top, (remove head)
  pop() {
    if (this.head === null) {
      return null;
    }

    const removed = this.head;
    this.head = this.head.next;

    return removed.data;
  }

  // aka top
  peek() {
    if (this.head === null) {
      return null;
    }
    return this.head.data;
  }

  contains(val) {
    let runner = this.head;

    while (runner) {
      if (runner.data === val) {
        return true;
      }
      runner = runner.next;
    }
    return false;
  }

  isEmpty() {
    return this.head === null;
  }

  size() {
    let len = 0;
    let runner = this.head;

    while (runner) {
      len += 1;
      runner = runner.next;
    }
    return len;
  }

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
}

class Queue {
  constructor(items = []) {
    this.items = items;
  }

  enqueue(item) {
    this.items.push(item);
  }

  dequeue() {
    if (this.isEmpty()) {
      return "Underflow";
    }

    return this.items.shift();
  }

  front() {
    if (this.isEmpty()) {
      return "Queue empty";
    }

    return this.items[0];
  }

  isEmpty() {
    return this.items.length === 0;
  }

  size() {
    return this.items.length;
  }

  print() {
    const str = this.items.join(" ");
    console.log(str);
    return str;
  }
}

class SLQueue {
  constructor() {
    this.head = null;
  }

  enqueue(val) {
    // add to back
    const newBack = new Node(val);
    let runner = this.head;

    if (runner === null) {
      this.head = newBack;
    } else {
      while (runner.next) {
        runner = runner.next;
      }
      runner.next = newBack;
    }
  }

  dequeue() {
    // remove head
    if (!this.head) {
      return null;
    }

    const dequeued = this.head;
    this.head = this.head.next;
    return dequeued.data;
  }

  front() {
    if (this.head === null) {
      return null;
    }
    return this.head.data;
  }

  isEmpty() {
    return this.head === null;
  }

  contains(val) {
    let runner = this.head;

    while (runner) {
      if (runner.val === val) return true;
      runner = runner.next;
    }
    return false;
  }

  size() {
    let len = 0;
    let runner = this.head;

    while (runner) {
      len += 1;
      runner = runner.next;
    }
    return len;
  }

  print() {
    let runner = this.head;
    let vals = "";

    while (runner) {
      vals += `${runner.val}${runner.next ? ", " : ""}`;
      runner = runner.next;
    }
    console.log(vals);
    return vals;
  }

  seed(vals) {
    vals.forEach((val) => this.enqueue(val));
  }

  compareQueues(q2) {
    if (this.size() !== q2.size()) {
      return false;
    }
    let count = 0;
    let isEqual = true;
    const len = this.size();

    while (count < len) {
      const dequeued1 = this.dequeue();
      const dequeued2 = q2.dequeue();

      if (dequeued1 !== dequeued2) {
        isEqual = false;
      }

      this.enqueue(dequeued1);
      q2.enqueue(dequeued2);
      count++;
    }

    return isEqual;
  }
}
