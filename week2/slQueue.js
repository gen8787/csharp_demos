class Node {
  constructor(data) {
    this.data = data;
    this.next = null;
  }
}

class SLQueue {
  constructor() {
    this.head = null;
  }

  // Time: O(n) linear, n = list length
  // Space: O(1)
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

  // Time: O(1) constant
  // Space: O(1)
  dequeue() {
    // remove head
    if (!this.head) {
      return null;
    }

    const dequeued = this.head;
    this.head = this.head.next;
    return dequeued.data;
  }

  // Time: O(1) constant
  // Space: O(1)
  front() {
    return this.head ? this.head.data : null;
  }

  // Time: O(1) constant
  // Space: O(1)
  isEmpty() {
    return this.head === null;
  }

  // Time: O(n) linear
  // Space: O(1)
  contains(val) {
    let runner = this.head;

    while (runner) {
      if (runner.val === val) return true;
      runner = runner.next;
    }
    return false;
  }

  // Time: O(n) linear
  // Space: O(1)
  size() {
    let len = 0;
    let runner = this.head;

    while (runner) {
      len += 1;
      runner = runner.next;
    }
    return len;
  }

  // Time: O(n) linear
  // Space: O(n)
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

  // Time: O(n * m) n = list length, m = vals.length
  // Space: O(1)
  seed(vals) {
    vals.forEach((val) => this.enqueue(val));
  }
}
