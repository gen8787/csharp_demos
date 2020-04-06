/* 

  Members: Chris T, Gwennie, Ronald

  Create a singly linked list with the following methods:

  -
  insertToBack
  -
  seedFromArray
    - convert given array to linked list
  - print
    - print a comma separated string of your linekd list data
  
  Bonus:
    - how would you design the linked list so that you can add a new node to the back in O(1) constant time (no looping)
*/

class Node {
  constructor(data) {
    this.data = data;
    this.next = null;
  }
}

class Slist {
  constructor() {
    this.head = null;
  }
  insertToBack(data) {
    //if head is null add to list
    newnode = new Node(data);
    if (this.head == null) {
      this.head = newnode;
    }
    let runner = this.head;
    //while loop through list
    while (runner.next != null) {
      runner = runner.next;
    }
    runner.next = newnode;
    return this;
  }

  //[1,3,5,7,9]
  seedFromArray(inputArray) {
    //for loop for inputArray
    for (i = 0; i < inputArray.length; i++) {
      // insertToBack for each item inputArray
      // newNode for each item
      this.insertToBack(inputArray[i]);
    }
  }
}
