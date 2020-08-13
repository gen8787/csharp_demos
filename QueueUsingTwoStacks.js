const Stack = require("./Stack");

// first in first out but using only two stacks to store the items
class TwoStackQueue {
  constructor() {
    this.stack1 = new Stack();
    this.stack2 = new Stack();
  }

  // Time: O(1) constant
  // Space: O(1)
  enqueue(item) {
    this.stack1.push(item);
    return this.stack1.length;
  }

  // Time: O(2n) -> O(n) linear
  // Space: O(1), no extra objects / arrays created within this method itself
  dequeue() {
    // move all items from stack 1 to stack 2, stack2 will have
    // items in reversed order now so that popping from stack 2
    // will get us the 'first in' item (FIFO)
    this.alternateStacks(this.stack1, this.stack2);

    const dequeued = this.stack2.pop();

    // move all items back to stack1 to be ready for enqueue
    this.alternateStacks(this.stack2, this.stack1);

    return dequeued;
  }

  alternateStacks(start, destination) {
    while (start.size()) {
      destination.push(start.pop());
    }
  }

  display() {
    console.log(this.stack1.join(", "));
  }
}
