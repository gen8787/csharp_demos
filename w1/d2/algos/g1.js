/* 
  Requirements:
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
}
