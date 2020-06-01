/* 
1. Mon
  - isEmpty
  - insertAtBack
  - seedFromArr
    - given an array, insert each item of the array to the back of this linked list
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

  isEmpty() {
    return this.head === null;
  }

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

  seedFromArr(arr) {
    for (const elem of arr) {
      this.insertAtBack(elem);
    }
  }

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
// linkedList.insertAtBack(1);
// linkedList.insertAtBack(2);
// linkedList.insertAtBack(3);
linkedList.seedFromArr([1, 2, 3, 5, 6, 7, 8, 9, 10]);
linkedList.display();
