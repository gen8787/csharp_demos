/* 

  Members: Edely, Gaku, Isiah

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
    constructor(val, next = null) {
        this.val = val;
        this.next = next;
    }
}

class SLL {
    constructor() {
        this.head = null;
    }
    insertToBack(node) {
        if (this.head !== null) {
            let runner = this.head;
            while (runner.next !== null) {
                // run through the list 
                runner = runner.next;
            }
            // hey, that node's next will be whatever we're trying to add
            runner.next = node;
        }
        // check for edge case (no nodes in SLL)
        this.head =
    }
}

let testNode = new Node(5);
let testSLL = new SLL();
testSLL.insertToBack(testNode);


/*

head | next
null | ---

head | next       | (last node).next
node | node.next  | ---
            ^
          runner


  */
// for the bonus
this.tail = null;
insertToBack(node) {
    if (this.head !== null) {
        let runner = this.head;
        while (runner.next !== null) {
            // run through the list 
            runner = runner.next;
        }
        // hey, that node's next will be whatever we're trying to add
        runner.next = node;
    }
    // check for edge case (no nodes in SLL)
    this.head === node;

    return;
}
kBonus
this.tail === node;

return; // SLL: testNode2 // SLL: testNode -> testNode2