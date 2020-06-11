// http://algorithms.dojo.news/static/Algorithms/index.html#LinkTarget_2115
// Create Queue Using Two Stacks

// Starter code / explanation

// Create Queue Using Two Stacks
/* 
  class TwoStackQueue {
    constructor() {
      this.stack1 = [];
      this.stack2 = [];
    }
  }

  TwoStackQueue.prototype.enqueue = function(params) {
    // 'this' will refer to the class instance that the method was called on
  }
  TwoStackQueue.prototype.dequeue = function(params) {
    // 'this' will refer to the class instance that the method was called on
  }

  Using ONLY two stacks as the underlying data structure, simulate a queue (FIFO).
  Since you are using stacks, you have to use .pop() and .push() to add / remove elements from them.
  i.e., you have to use the stacks in the way that stacks are meant to be used

  Visualization / Physical Prop Version:
  Imagine a stack as a pole standing on a square base, and you have two of them.
  Imagine the items that will be added as a donut shape that can be put onto the pole (like a kids toy)

  If you put each donut 1 by 1 onto the pole, you have to remove the last one that was added first to get
  to the ones underneath it.

  In order to simulate a queue (first in, first out), you need to be able to remove the first
  donut that was added, which is at the bottom of the pole; to remove that donut you have to remove
  the other donuts temporarily, but you can't put these temporarily removed donuts on the floor, because
  the floor is not an official storage space, but you have a 2nd pole on a square base (stack) to put
  the temporarily removed donuts on.
*/

class TwoStackQueue {
  constructor() {
    this.stack1 = [];
    this.stack2 = [];
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
    while (start.length > 0) {
      destination.push(start.pop());
    }
  }

  display() {
    console.log(this.stack1.join(", "));
  }
}
