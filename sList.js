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
}

const linkedList = new SList();
linkedList.seedFromArr([1, 2, 3, 5, 6, 7, 8, 9, 10]);
linkedList.display();
