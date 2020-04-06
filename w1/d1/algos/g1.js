/* 

  Members: Alex, Faris, Matt, Millie

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
    constructor(value) {
        this.value = value;
        this.next = null;
    }
}

class SLL {
    constructor() {
        this.head = null;
    insertToBack(value) {
        let NewNode = new Node(value);
        let runner = this.head;
        while (runner.next != null) {
            rnner = runner.next;
            unner.next = NewNode
        }

        return
    }
} alello
        self.hed = ast