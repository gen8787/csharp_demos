// import stack to use it in this file too
const Stack = require("./stack");

class Queue {
  constructor(items = []) {
    this.items = items;
  }

  // Time: O(1) constant
  // Space: O(1)
  enqueue(item) {
    this.items.push(item);
  }

  // if empty will return undefined
  // Time: O(n) linear, due to having to shift all the remaining items to the left after removing first elem
  // Space: O(1)
  dequeue() {
    return this.items.shift();
  }

  // returns undefined if empty
  // Time: O(1)
  // Space: O(1)
  front() {
    return this.items[0];
  }

  // Time: O(1)
  // Space: O(1)
  isEmpty() {
    return this.items.length === 0;
  }

  // Time: O(1)
  // Space: O(1)
  size() {
    return this.items.length;
  }

  // Time: O(n) linear
  // Space: O(n)
  print() {
    const str = this.items.join(" ");
    console.log(str);
    return str;
  }

  /*   
    Queues are equal only if they have equal
    elements in identical order. Allocate no other
    object, and return the queues in their original
    condition upon exit.

    Time: O(n) linear, n = queue length
    Space: O(1) constant
  */
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

  // Time: O(2n) -> O(n) linear, n = queue length
  // Space: O(n) linear, every queue item duplicated into stack
  isPalindrome() {
    const stack = new Stack();
    const len = this.size();
    let isPalin = true;

    for (let i = 0; i < len; i++) {
      const dequeued = this.dequeue();
      stack.push(dequeued);
      this.enqueue(dequeued);
    }

    for (let i = 0; i < len; i++) {
      const dequeued = this.dequeue();
      const popped = stack.pop();

      console.log("dequeued: ", dequeued, "popped: ", popped);

      if (dequeued !== popped) {
        isPalin = false;
      }

      this.enqueue(dequeued);
    }
    return isPalin;
  }
}

const q = new Queue([1, 2, 3]);
console.log(q.isPalindrome());
