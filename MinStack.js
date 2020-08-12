// https://leetcode.com/problems/min-stack/
/* 
  Design a stack that supports push, pop, top, 
  and retrieving the minimum element
    - bonus: retrieve min element in constant time (no looping).

  push(x) -- Push element x onto stack.
  pop() -- Removes the element on top of the stack.
  top() -- Get the top element.
  getMin() -- Retrieve the minimum element in the stack
*/

class MinStack {
  constructor() {
    this.items = [];
    this.minStack = [];
  }

  // Time: O(1) constant
  // Space: O(1)
  // The algo itself isn't using extra space but our class has an extra array called minStack
  // That may take up the same space as items
  push(n) {
    this.items.push(n);

    if (this.minStack.length === 0 || n < minStack[this.minStack.length - 1])
      this.minStack.push(n);
  }

  // Time: O(1) constant
  // Space: O(1)
  pop() {
    const popped = this.items.pop();

    if (popped === this.minStack[this.minStack.length - 1]) {
      this.minStack.pop();
    }
    return popped;
  }

  // Time: O(1) constant
  // Space: O(1)
  top() {
    return this.items[this.items.length - 1];
  }

  // Time: O(1) constant
  /* 
    Space: O(1) because this method itself isn't using up extra space,
    but the constant time is possible because of the extra space that this.minStack
    is taking up, which could be as much as large as this.items, see push method comment
  */
  getMin() {
    return this.minStack[this.minStack.length - 1];
  }
}

// store objects in stack with a curr min key to track what the min was at that time
