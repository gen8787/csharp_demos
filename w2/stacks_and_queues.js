/* 
  - A stack is a LIFO (Last in First Out) data structure
  - create a class to represent a stack using an array & another class for a stack using a singly linked list
    - create methods for each: push, pop, isEmpty, size, peek (return top item without removing)
*/

class Stack {
  constructor(items = []) {
    this.items = items;
  }

  push(el) {
    this.items.push(el);
  }

  pop() {
    if (this.isEmpty()) return "Underflow";

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
