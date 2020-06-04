/* 
Week 1

  1. Mon
    - isEmpty
    - insertAtBack
    - seedFromArr
      - given an array, insert each item of the array to the back of this linked list

  2. Tue
    1. insertAtFront
      - add a new node to the front of the list
    2. removeHead
      - remove only the first node from the list and return the data of the removed node or null
    3. Bonus: return the average of the list

  3. Wed
    1. contains - with & without recursion
      - check if the list contains a value
    2. removeBack
      - remove the last node from the list and return it's data or null
    3. Bonus: getMiddleData: get data of middle node

  4. Thur
    1. removeVal
      - remove the node with the specified value, return the removed val, or null if nothing was removed
    2. moveMinToFront
      - move node with min value in it to the front of the list (work in place, do not create a new list)
    3. Bonus: prepend new val before given val
*/

class Node {
  constructor(data) {
    this.data = data;
    this.next = null;
  }
}

class SList {
  constructor() {
    this.head = null;
  }

  // Time: O(1) constant
  // Space: O(1)
  isEmpty() {
    return this.head === null;
  }

  // Time: O(n) linear, n = length of list
  // Space: O(1)
  insertAtBack(val) {
    const newNode = new Node(val);

    if (this.isEmpty()) {
      this.head = newNode;
      return;
    }

    let runner = this.head;

    while (runner.next !== null) {
      runner = runner.next;
    }
    runner.next = newNode;
  }

  // Time: O(n * m) n = list length, m = arr.length
  // Space: O(1) constant
  seedFromArr(arr) {
    for (const elem of arr) {
      this.insertAtBack(elem);
    }
  }

  // Time: O(n) linear, n = length of list
  // Space: O(n) due to the string growing based on list size
  display() {
    let str = "";

    let runner = this.head;

    while (runner !== null) {
      str += runner.data;

      // add ", " if not last node
      if (runner.next !== null) {
        str += ", ";
      }
      runner = runner.next;
    }
    console.log(str);
    return str;
  }

  // Time: O(1) constant
  // Space: O(1)
  insertAtFront(data) {
    const newHead = new Node(data);
    newHead.next = this.head;
    this.head = newHead;
    return this;
  }

  // Time: O(1) constant
  // Space: O(1)
  removeHead() {
    if (this.isEmpty()) {
      return null;
    }

    this.head = this.head.next;
    return this;
  }

  // Time: O(n) linear, n = list length
  // Space: O(1)
  average() {
    if (this.isEmpty()) {
      return 0;
    }

    let count = 0;
    let sum = 0;
    let runner = this.head;

    // while runner is truthy, will cancel if runner is null or empty string or the int 0, anything that is falsy
    while (runner) {
      count++;
      sum += runner.data;
      runner = runner.next;
    }
    return sum / count;
  }

  // Time: O(n) linear, n = length of list
  // Space: O(1)
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

  // Time: O(n) linear, n = length of list
  // Space: O(1) constant
  containsRecursive(val, current = this.head) {
    if (current === null) {
      return false;
    }
    if (current.data === val) {
      return true;
    }
    return this.containsRecursive(val, current.next);
  }

  // Time: O(n) linear, n = length of list
  // Space: O(1) constant
  removeBack() {
    let removedData = null;

    if (!this.isEmpty()) {
      if (this.head.next === null) {
        // head only node
        removedData = this.head.data;
        this.head = null; // remove it from list
      } else {
        let runner = this.head;
        // right of && will only be checked if left is true
        while (runner.next && runner.next.next) {
          runner = runner.next;
        }

        // after while loop finishes, runner is now at 2nd to last node
        removedData = runner.next.data;
        runner.next = null; // remove it from list
      }
    }
    return removedData;
  }
}

SList.prototype.someNewMethod = function () {
  console.log("This method was added to the class from outside the class");
};

const linkedList = new SList();
// linkedList.seedFromArr([10, 15, 10]);
// linkedList.display();
