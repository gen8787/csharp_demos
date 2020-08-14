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
     - size
     - front (return first item without removing)
   - Time complexities should be as follows:
     - Array Queue: enqueue: O(1), dequeue: O(n), size: O(1), front: O(1)
     - Linkedd List Queue: enqueue: O(1), dequeue: O(1), size: O(1), front: O(1)
3. Wed
   - compareQueues
     - write a method on the Queue class that, given another queue, will return whether they are equal (same items in same order)
     - Use ONLY the provided queue methods, do not manually index the queue items, no extra array or objects
     - restore the queues to their original state
   - queueIsPalindrome
     - write a method on the Queue class that returns whether or not the queue is a palindrome
     - use only 1 stack as additional storage (no additional arrays / objects)
     - do not manually index the queue, use the provided queue methods and stack methods, restore the queue to original state when done
   - Extra: MinStack
     - Design a stack that supports push, pop, top, and min methods where the min method retrieves the minimum int in the stack
     - Bonus: retrieve min element in constant time (no looping).
4. Thur
   - sumOfHalvesEqual
     - create a method on the Queue class that returns whether or not the sum of the first half of the queue is equal to the sum of the second half
     - DO NOT manually index the queue items, only use the provided queue methods, use no additional arrays or objects for storage
     - restore the queue to it's original state before returning
   - QueueUsingTwoStacks
     - create enqueue and dequeue methods on a new queue class that uses ONLY 2 stacks as storage but simulates a FIFO pattern
     - use only the provided stack methods from the two stacks (do not directly index)
5. Fri
   - PriorityQueue (create enqueue and dequeue methods)
     - design a new PriorityQueue class where the queue maintains an ascending order when items are added based on queue item's provided priority integer value. A priority value of 1 is most important which means it should be at the front of the queue, the first to be dequeued.
   - LinkedListPriorityQueue

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
