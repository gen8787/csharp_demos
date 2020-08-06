/* 
  1. Mon
    1. isEmpty
    2. insertAtBack
    3. seedFromArr
        - given an array, insert each item of the array to the back of this linked list

  2. Tue
    1. insertAtFront
        - add a new node to the front of the list
    2. removeHead
        - remove only the first node from the list and return the data of the removed node or null
    3. Extra: return the average of the list

  3. Wed
    1. removeBack
        - remove the last node from the list and return it's data or null
    2. contains - with & without recursion
        - check if the list contains a value

  4. Thur
    1. secondToLast
        - return the 2nd to last val
    2. removeVal
        - remove the node with the specified value, return the removed val, or null if nothing was removed
    3. Extra: recursiveMax: return max val from list using recursion
    4. Extra: prepend new val before given val
*/

class Node {
  constructor(data) {
    this.data = data;
    this.next = null;
  }
}

class SinglyLinkedList {
  constructor() {
    this.head = null;
  }

  // all the methods (functionality) of our linked list go here:

  // Time: O(n * m), n = arr.length, m = this linked list's length
  // Space: O(1) constant
  seedFromArr(arr) {
    for (let i = 0; i < arr.length; i++) {
      this.insertAtBack(arr[i]);
    }
    return this;
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

  isEmpty() {
    return this.head === null;
  }

  insertAtBack(data) {
    const newTail = new Node(data);

    if (this.isEmpty()) {
      // list that has only a head means, the head is both the head and the tail
      this.head = newTail;
      return this;
    }

    let runner = this.head;

    while (runner.next !== null) {
      runner = runner.next;
    }

    runner.next = newTail;
    return this;
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
    const oldHead = this.head;
    this.head = this.head.next;
    return oldHead.data;
  }

  // Time: O(n) linear, n = length of list
  // Space: O(1) constant
  average() {
    let runner = this.head;
    let sum = 0;
    let cnt = 0;

    while (runner) {
      cnt++;
      sum += runner.data;
      runner = runner.next;
    }
    return sum / cnt;
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
        while (runner.next.next) {
          runner = runner.next;
        }

        // after while loop finishes, runner is now at 2nd to last node
        removedData = runner.next.data;
        runner.next = null; // remove it from list
      }
    }
    return removedData;
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

  // Time: O(n - 1) n = list length -> O(n) linear
  // Space: O(1) constant
  secondToLast() {
    if (!this.head || !this.head.next) {
      return null;
    }

    // there are at least 2 nodes

    let runner = this.head;

    while (runner.next.next) {
      runner = runner.next;
    }
    return runner.data;
  }

  // Time: O(n) linear, n = list length. Val could be last node
  // Space: O(1) constant
  removeVal(val) {
    if (this.isEmpty()) {
      return null;
    }

    if (this.head.data === val) {
      return this.removeHead();
    }

    let runner = this.head.next;

    while (runner.next && runner.next.data !== val) {
      runner = runner.next;
    }

    if (runner.next && runner.next.data === val) {
      const removedData = runner.next.data;
      runner.next = runner.next.next;
      return removedData;
    }
    return null;
  }

  // Time: O(n) linear, n = length of list
  // Space: O(1)
  containsRecursive(val, runner = this.head) {
    if (runner === null) {
      return false;
    }

    if (runner.data === val) {
      return true;
    }
    return this.containsRecursive(val, runner.next);
  }

  recursiveMax(runner = this.head, maxNode = this.head) {
    if (this.head === null) {
      return null;
    }

    if (runner === null) {
      return maxNode.data;
    }

    if (runner.data > maxNode.data) {
      maxNode = runner;
    }

    return this.recursiveMax(runner.next, maxNode);
  }
}

const emptyList = new SinglyLinkedList();
const singleNodeList = new SinglyLinkedList().insertAtBack(1);
const biNodeList = new SinglyLinkedList().insertAtBack(1).insertAtBack(2);
const firstThreeList = new SinglyLinkedList().seedFromArr([1, 2, 3]);

const secondThreeList = new SinglyLinkedList().seedFromArr([4, 5, 6]);
const unorderedList = new SinglyLinkedList().seedFromArr([
  -5,
  -10,
  4,
  -3,
  6,
  1,
  -7,
  -2,
]);

const sortedDupeList = new SinglyLinkedList().seedFromArr([
  1,
  1,
  1,
  2,
  3,
  3,
  4,
  5,
  5,
]);

console.log(emptyList.recursiveMax(), "should be null");
console.log(singleNodeList.recursiveMax(), "should be 1");
console.log(biNodeList.recursiveMax(), "should be 2");
console.log(unorderedList.recursiveMax(), "should be 6");
