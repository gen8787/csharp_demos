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
}
