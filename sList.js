/* 
  Requirements:

1. Mon
   - intro
   - SList: Add Back
   - seedFromArr: SList: Convert Array to SList
   - Bonus: addBack recursive
2. Tue
   1. List: Add Front
      - add a new node to the front of the list
   2. List: Remove Front
      - remove only the first node from the list
      - bonus: return the removed val, or null if nothing was removed
    3. Bonus:
      - get middle node's data
3. Wed
   1. List: Contains (with & without recursion)
      - check if the list contains a value
   2. SList: Remove Back
      - remove the last node from the list
      - bonus: return the removed val, or null if nothing was removed
   3. Bonus:
      - SList: Split on Value
      - splitOnVal(5) for the list (1=>3=>5=>2=>4) will change list to (1=>3), and the return value will be a new list containing (5=>2=>4)
*/

class Node {
  constructor(data) {
    this.data = data;
    this.next = null;
  }
}

class LinkedList {
  constructor() {
    this.head = null;
  }

  isEmpty() {
    return this.head === null;
  }

  insertAtBack(data) {
    const newNode = new Node(data);

    if (this.isEmpty()) {
      this.head = newNode;
    } else {
      let runner = this.head;

      while (runner.next !== null) {
        runner = runner.next;
      }

      runner.next = newNode;
    }
    return this;
  }

  insertAtFront(data) {
    const newHead = new Node(data);
    newHead.next = this.head;
    this.head = newHead;

    return this;
  }

  removeHead() {
    if (!this.head) {
      return null;
    }

    const headData = this.head.data;
    this.head = this.head.next;
    return headData;
  }

  insertAtBackRecursive(data, runner = this.head) {
    if (this.isEmpty()) {
      this.head = new Node(data);
      return this;
    }

    if (runner.next === null) {
      runner.next = new Node(data);
      return this;
    }

    return this.insertAtBackRecursive(data, runner.next);
  }

  display() {
    let runner = this.head;
    let vals = "";

    while (runner) {
      vals += `${runner.data}${runner.next ? ", " : ""}`;
      runner = runner.next;
    }
    console.log(vals);
    return vals;
  }

  seedFromArr(arr) {
    for (const item of arr) {
      this.insertAtBack(item);
    }
  }

  // extra looping can be avoided if we kept track of a length property on our list
  // updating the length as nodes are added / removed
  getMiddleData() {
    let runner = this.head;
    let len = 0;

    while (runner) {
      len++;
      runner = runner.next;
    }

    // even length, no middle
    if (len % 2 === 0) {
      return null;
    }

    runner = this.head;
    let midPoint = Math.floor(len / 2);
    let idx = 0;

    while (idx !== midPoint) {
      idx++;
      runner = runner.next;
    }
    return runner.data;
  }
}
