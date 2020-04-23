/* 
  w3d3
    - create the necessary classes to design a double linked list
      - a linked list that allows you to traverse forwards AND backwards, allowing you to start at the front or the back
    
  w3d4
    - DList: Prepend Value
      - add new val before a target val
    - isNodeInLeftHalf: given a reference to a node, return whether it's in left half or not
*/

class DLLNode {
  constructor(data) {
    this.data = data;
    this.prev = null;
    this.next = null;
  }
}

class DLL {
  constructor() {
    this.head = null;
    this.tail = null;
  }
}
