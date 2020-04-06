/* 

Members: Dennis sucks, Scott, Zach

Create a singly linked list with the following methods:

Create a singly linked list with the following methods:

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
  constructor(value, next = null) {
    this.element = value;
    this.next = next;
  }
}

class LinkedList {
  constructor() {
    this.head = null;
    this.tail = null;
  }

  insertToBack(value) {
    var node = new Node(value);
    if (this.head === null) {
      this.head = node;
    } else {
      var runner = this.head;
      while (runner.next !== null) {
        runner = runner.next;
      }
      runner.next === node;
    }
    return this;
  }

  seedFromArray(arr) {
    if (arr.length === 0) {
      return;
    } else {
      for (var i = 0; i < arr.length; i++) {
        var node = new Node(arr[i]);
        this.insertToBack(node);
      }
    }
    return this;
  }
}

var myArray = ["DJ", "is", "dumb"];

var myList = new LinkedList(null);

myList.seedFromArray(myArray);
console.log(myList);
myList.seedFromArray(myArray);
console.log(myArray);
