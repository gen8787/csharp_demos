# [Stacks](./Stack.js) & [Queues](./Queue.js)

## Schedule

1. Mon
   - A Stack is a LIFO (Last in First Out) data structure
   - design a class to represent a stack using an array to store the items
   - after a Stack with an array, recreate the stack class using a singly linked list to store the items
   - create these methods for each of the Stack classes with O(1) time:
     - push (adds new item and returns new size)
     - pop (returns removed item)
     - isEmpty
     - size
     - peek (return top item without removing)
2. Tue
   - A Queue is a FIFO (First in First Out) data structure
   - design a class to represent a queue using an array to store the items
   - recreate the queue class using a singly linked list to store the items
   - create these methods for each classes:
     - enqueue (add item, return new size)
     - dequeue (remove and return item)
     - isEmpty
     - size, front (return first item without removing)
   - Time complexities should be as follows:
     - Array Queue: enqueue: O(1), dequeue: O(n), size: O(1), front: O(1)
     - Linkedd List Queue: enqueue: O(1), dequeue: O(1), size: O(1), front: O(1)

---

## Description

A stack and a queue are two data structures that are just an
array or linked list contained within a class. The purpose
of wrapping a class around it, is to enforce a standardized
way of interacting with the array via the class' methods.
This standardized way of interacting with the array is what
makes it either a stack or a queue.

Rather than mutating the array directly, or looping over it from the outside of the class,
all of that should be done by methods in the class to keep the way
the data structure is interacted with consistent.

If everyone uses the provided methods to interact with the data structure,
there will be consistency.

---

## Stack (Last In First Out (LIFO))

Imagine a stack of heavy blocks. You would only add new blocks
to the top of the stack and remove blocks from the top of the stack because they are too heavy to remove from the middle or the bottom.

So, to remove the block at the bottom of the stack, you would first remove
blocks at the top one-by-one until you got to the bottom

- new items are added to the 'top' of the 'stack', this is called `push`
  - added to the back of the array
- items are only removed from the 'top' of the 'stack', this is called `pop`
  - removed from the back of the array

---

## Queue (First in First Out (FIFO))

Imagine a line of people at a grocery store.
The first person in line is the next person to be serviced.
You wouldn't service the last person in line first.

- new items are added to the back of the queue (end of array), this is called `enqueue`
- items are only removed from the front of the queue (front of array) this is called `dequeue`

---

## Starter Code

- ```js
  class Queue {
    constructor(items = []) {
      this.items = items;
    }
    // add methods here, outside constructor
    newMethod(params) {
      // 'this' keyword will refer to the class instance
      // that newMethod was called on
    }
  }

  class Stack {
    constructor(items = []) {
      this.items = items;
    }
    // add methods here, outside constructor
    newMethod(params) {
      // 'this' keyword will refer to the class instance
      // that newMethod was called on
    }
  }

  // Alternate way to add method to class
  NameOfClass.prototype.newMethodsName = function (params) {
    // 'this' keyword inside method
    // will refer to the class instance that
    // the newMethod was called on
  };
  ```
