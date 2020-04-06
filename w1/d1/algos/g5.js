/* 

  Members: Jimmy, Morgan, Ryan

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

class Node:
    def __init__(self, value):
    self.data = value
self.next = None


//insert to back