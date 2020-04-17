// src = https://www.geeksforgeeks.org/implementation-priority-queue-javascript/
/*
  Draw a to do list with two columns: item, and importance
    - the to do, is your queue item

  Have students give you a to do and it's importance with 1 being most important
  When the list is empty, where does it go?

  Once first item is added, have students give more to dos,
  explain the process that you decide where to add the new to do,
  based on it's importance, is essentially a loop. You visually loop
  through the list until you find the first item that is not as
  important, then you put the new item in that position.

*/

class QElement {
  constructor(element, priority) {
    this.element = element;
    this.priority = priority;
  }
}

// PriorityQueue class
class PriorityQueue {
  // An array is used to implement priority
  constructor() {
    this.items = [];
  }

  // enqueue function to add element
  // to the queue as per priority
  enqueue(element, priority) {
    // creating object from queue element
    const qElement = new QElement(element, priority);
    let queued = false;

    // iterating through the entire
    // item array to add element at the
    // correct location of the Queue
    for (let i = 0; i < this.items.length; ++i) {
      if (this.items[i].priority > qElement.priority) {
        // Insert new item before the first item whose priority number is larger
        // smaller priority numbers are first
        this.items.splice(i, 0, qElement);
        queued = true;
        break;
      }
    }

    // if the element has the lowest priority (lower number is higher priority)
    // it is added at the end of the queue
    if (!queued) {
      this.items.push(qElement);
    }
  }

  dequeue() {
    if (this.isEmpty()) return "Underflow";
    return this.items.shift();
  }

  front() {
    // returns the highest priority element
    // in the Priority queue without removing it.
    if (this.isEmpty()) return "No elements in Queue";
    return this.items[0];
  }

  rear() {
    // returns the lowest priorty
    // element of the queue
    if (this.isEmpty()) return "No elements in Queue";
    return this.items[this.items.length - 1];
  }

  isEmpty() {
    return this.items.length == 0;
  }

  print() {
    return this.items.reduce((str, qEl) => (str += qEl.element + " "), "");
  }
}

module.exports = PriorityQueue;
