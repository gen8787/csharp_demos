class Stack {
  constructor(items = []) {
    this.items = items;
  }

  // Time: O(1)
  // Space: O(1)
  push(item) {
    this.items.push(item);
  }

  // Time: O(1)
  // Space: O(1)
  // Returns undefined if empty
  pop() {
    return this.items.pop();
  }

  // aka top, returns undefined if empty
  // Time: O(1)
  // Space: O(1)
  peek() {
    return this.items[this.items.length - 1];
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
}

module.exports = Stack;
