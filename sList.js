/* 
  Requirements:

  w1d1
    1. SList: Add Back
    2. seedFromArr: SList: Convert Array to SList
    3. Bonus: addBack recursive

  w1d2
    1. List: Add Front
      - add a new node to the front of the list
    2. List: Remove Front
      - remove only the first node from the list
      - bonus: return the removed val, or null if nothing was removed
    3. Bonus:
      - get middle node's data

  w1d3
    1. List: Contains (with & without recursion)
      - check if the list contains a value
    2. SList: Remove Back
      - remove the last node from the list
      - bonus: return the removed val, or null if nothing was removed
    3. Bonus:
      - SList: Split on Value
      - splitOnVal(5) for the list (1=>3=>5=>2=>4) will change list to (1=>3), and the return value will be a new list containing (5=>2=>4)

  w1d4
    1. SList: Move Min to Front
    2. SList: Remove Val
        - remove the node with the specified value, true if successful / false if not
    3. Bonus: 
      - displayPeople: in a linked list containing person objects, write a method to print a comma separated string of all the people's firstName

  w1d5
    1. SList: Second to Last Value
      - return the 2nd to last val
    2. SList: Concat
      - combine two SLists together
      - if `list1` is a list of nodes with values 1, 2, 3. and `list2` is a list of nodes with values 4, 5, 6
        - `list1.concat(list2);` should result in `list1` having nodes with values 1, 2, 3, 4, 5, 6
    3. Bonus
      - insertPersonAscAge: build an add person method that adds a person object to linked list maintaing asc order by person's age key

  w3d1
    1. recursiveLast: recursively return the value / data of the last node
    2. SList: Partition
      - partition a SList such that all values less than the given value are to the left of it, and all values greater than the given value are to the right (not perfectly sorted)

  w3d2
    1. Remove Negatives (in place)
    2. recursiveMax - find the max int recursively

  w3d3
    - removeDupesSorted: Remove duplicates from a sorted linked list (in place)
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

  removeFront() {
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
  // can also have two runners, one that goes next.next and the slower one going just .next
  // so when the faster one reaches end, the slower one is half way
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

  removeBack() {
    let removedData = null;

    if (this.head !== null) {
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

  contains(searchData) {
    let runner = this.head;

    // if head is null, runner is null, loop won't run
    while (runner) {
      if (runner.data === searchData) {
        return true;
      }
      runner = runner.next;
    }
    return false;
  }

  containsRecursive(searchData, runner = this.head) {
    if (this.isEmpty() || runner === null) {
      return false;
    }

    if (runner.data == searchData) {
      return true;
    }

    return this.containsRecursive(searchData, runner.next);
  }

  // splitOnVal(5) for the list (1=>3=>5=>2=>4) will change list to (1=>3), and the return value will be a new list containing (5=>2=>4)

  splitOnVal(val) {
    const newList = new SList();

    if (this.isEmpty()) {
      return newList;
    }

    if (this.head.data === val) {
      newList.head = this.head;
      this.head = null;
      return newList;
    }

    let runner = this.head;

    while (runner.next) {
      if (runner.next.data === val) {
        newList.head = runner.next;
        runner.next = null;
        return newList;
      }
      runner = runner.next;
    }

    return newList;
  }

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

  // this solution removes the node and inserts new node at front, could also swap the data of the nodes
  moveMinToFront() {
    if (this.isEmpty()) {
      return;
    }

    let runner = this.head;
    let min = this.head.data;

    while (runner) {
      if (runner.data < min) {
        min = runner.data;
      }
      runner = runner.next;
    }
    // now that we know the min, if it is alredy the head, nothing needs to be done
    if (this.head.data === min) {
      return;
    }

    let prev = this.head;
    runner = this.head.next;

    while (runner) {
      if (runner.data === min) {
        prev.next = runner.next; // remove the min
        this.insertAtFront(min);
        return;
      } else {
        prev = runner;
        runner = runner.next;
      }
    }
  }

  displayPeople() {
    let runner = this.head;
    let names = "";

    while (runner) {
      names += `${runner.data.firstName} ${runner.data.lastName}${
        runner.next ? ", " : ""
      }`;
      runner = runner.next;
    }
    console.log(names);
    return names;
  }

  secondToLast() {
    if (!this.head || !this.head.next) return null;

    let runner = this.head;

    while (runner.next && runner.next.next) {
      runner = runner.next;
    }
    return runner.data;
  }

  concat(addList) {
    let runner = this.head;

    if (runner === null) this.head = addList.head;
    else {
      while (runner.next) {
        runner = runner.next;
      }
      runner.next = addList.head;
    }
  }

  // assuming all node's data are person objects
  insertPersonAscAge(data) {
    const newNode = new Node(data);

    if (!this.head) {
      this.head = newNode;
      return this;
    }

    if (newNode.data.age < this.head.data.age) {
      newNode.next = this.head;
      this.head = newNode;
      return this;
    }

    let prev = this.head;
    let current = this.head.next;

    while (current && current.data.age <= newNode.data.age) {
      prev = current;
      current = current.next;
    }

    prev.next = newNode;
    newNode.next = current;
    return this;
  }

  partition(val) {
    if (this.contains(val) === false) {
      return this;
    }

    const smallerList = new SList();
    const largerList = new SList();
    let valCount = 1;

    let runner = this.head;

    while (runner) {
      // insertAtFront for better performance than insertAtBack
      if (runner.data < val) {
        smallerList.insertAtFront(runner.data);
      } else if (runner.data > val) {
        largerList.insertAtFront(runner.data);
      } else if (runner.data === val) {
        valCount++;
      }
      runner = runner.next;
    }
    // ensure our given val is at the beginning of the larger list
    for (let i = 0; i < valCount; ++i) {
      largerList.insertAtFront(val);
    }

    smallerList.concat(largerList);

    this.head = smallerList.head;
    return this;
  }

  recursiveLast(runner = this.head) {
    if (runner === null) {
      return null;
    }
    if (runner.next === null) {
      return runner.data;
    }
    return this.recursiveLast(runner.next);
  }

  // can't set max to 0 in case list has all negative numbers
  recursiveMax(runner = this.head, max = null) {
    if (max === null && this.head !== null) {
      max = this.head.data;
    }
    if (runner === null) {
      return max;
    }
    if (runner.data > max) {
      max = runner.data;
    }
    return this.recursiveMax(runner.next, max);
  }

  removeNegatives() {
    if (!this.head) {
      return this;
    }

    let runner = this.head;

    // get rid of all negatives at start so head will be positive, or null
    while (runner && runner.data < 0) {
      runner = runner.next;
    }

    this.head = runner;

    //  head may have become null, that's why we check runner && runner.next
    while (runner && runner.next) {
      if (runner.next.data < 0) {
        runner.next = runner.next.next;
      } else {
        runner = runner.next;
      }
    }
    return this;
  }

  /** Approach: while runner isn't null
   * if runner.next is a dupe, update runner.next to .next.next
   * 111233455
   * 11233455
   * 1233455
   * 123455
   * 12345
   */
  removeDupesSorted() {
    let runner = this.head;

    if (!runner) {
      return this;
    }

    while (runner.next) {
      if (runner.data === runner.next.data) {
        const newNext = runner.next.next;
        runner.next = newNext;
      } else {
        runner = runner.next;
      }
    }
    return this;
  }
}

const myList = new LinkedList();
myList.seedFromArr([5, 2, 1, 6, 3]);

const myListOfPersons = new LinkedList();
myList.seedFromArr([
  { firstName: "Alex" },
  { firstName: "Kevin" },
  { firstName: "Ronald" },
  { firstName: "Mark" },
  { firstName: "Roza" },
]);
