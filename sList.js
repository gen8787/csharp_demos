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

  5. Fri
    1. secondToLast
      - return the 2nd to last val
    2. concat
      - combine two SLists together
      - if list1 is a list of nodes with values 1, 2, 3 and list2 is a list of nodes with values 4, 5, 6
        - list1.concat(list2) should result in list1 having nodes with data in this order: 1, 2, 3, 4, 5, 6
    3. Bonus: splitOnVal
      - splitOnVal(5) for the list (1=>3=>5=>2=>4) will change list to (1=>3), and the return value will be a new list containing (5=>2=>4)
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

  // Time: O(n) linear, n = list length. Val could be last node
  // Space: O(1) constant
  removeVal(val) {
    if (this.isEmpty()) {
      return false;
    }

    if (this.head.data === val) {
      this.head = this.head.next;
      return true;
    }

    let runner = this.head.next;

    while (runner.next && runner.next.data !== val) {
      runner = runner.next;
    }

    if (runner.next && runner.next.data === val) {
      runner.next = runner.next.next;
      return true;
    }
    return false;
  }

  // getMinMode() {
  //   let runner = this.head;
  //   let minNode = this.head;

  //   while (runner) {
  //     if (runner.data < minNode.data) {
  //       minNode = runner;
  //     }
  //     runner = runner.next;
  //   }
  //   return minNode;
  // }

  // Time: O(2n) -> O(n) linear, n = list length
  // Space: O(1) constant
  moveMinToFront() {
    if (this.isEmpty()) {
      return this;
    }

    let minNode = this.head;
    let prev = this.head;
    let runner = this.head;

    while (runner) {
      if (runner.data < minNode.data) {
        minNode = runner;
      }
      runner = runner.next;
    }

    if (this.head === minNode) {
      return this;
    }

    runner = this.head;

    while (runner !== minNode) {
      prev = runner;
      runner = runner.next;
    }

    prev.next = minNode.next;
    minNode.next = this.head;
    this.head = minNode;
    return this;
  }

  // Time: O(n) linear, n = list length
  // Space: O(n)
  // This avoids the extra loop in the above sln
  moveMinFront() {
    if (this.isEmpty()) {
      return this;
    }

    let minNode = this.head;
    let runner = this.head;
    let prev = this.head;

    while (runner) {
      if (runner.data < minNode.data) {
        minNode = runner;
      }

      // make sure the prev stays the prev of minNode
      // if minNode is last node, we don't want prev to become the runner
      if (prev.next !== minNode && runner.next !== null) {
        prev = runner;
      }
      runner = runner.next;
    }

    if (minNode === this.head) {
      return this;
    }

    prev.next = minNode.next;
    minNode.next = this.head;
    this.head = minNode;
    return this;
  }

  // Time: O(n - 1) n = list length -> O(n) linear
  // Space: O(1) constant
  secondToLast() {
    if (!this.head || !this.head.next) {
      return null;
    }

    let runner = this.head;

    while (runner.next && runner.next.next) {
      runner = runner.next;
    }
    return runner.data;
  }

  // Time: O(n) n = "this" list length -> O(n) linear. addList does not need to be looped
  // Space: O(1) constant, although this list grows by addList's length, our algo does not need to take up additional space to do it's job
  concat(addList) {
    let runner = this.head;

    if (runner === null) {
      this.head = addList.head;
    } else {
      while (runner.next) {
        runner = runner.next;
      }
      runner.next = addList.head;
    }
    return this;
  }
}

SList.prototype.someNewMethod = function () {
  console.log("This method was added to the class from outside the class");
};

const linkedList = new SList();
linkedList.seedFromArr([10, 15, 1]);
linkedList.display();
