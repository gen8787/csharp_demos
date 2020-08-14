class QItem {
  constructor(data, priority) {
    this.data = data;
    this.priority = priority;
  }
}

class PriorityQueue {
  constructor(items = []) {
    this.items = items;
  }

  /* 
    [
      { data: "Jason", priority: 2},
      { data: "Gary", priority: 4},
      { data: "Parker", priority: 6},
    ]
    new item: { data: "Ryan", priority: 5}
  */
  enqueue(item, priority) {
    const qItem = new QItem(item, priority);
    let queued = false;

    for (let i = 0; i < this.items.length; i++) {
      if (this.items[i].priority > qItem.priority) {
        // Insert new item BEFORE the first item whose priority number is larger, since larger number is less important
        this.items.splice(i, 0, qItem);
        queued = true;
        break;
      }
    }

    // this item is the least important so it was not added anywhere in our list, add it to the back
    if (!queued) {
      this.items.push(qItem);
    }
  }

  // if empty will return undefined
  // Time: O(n) linear, due to having to shift all the remaining items to the left after removing first elem
  // Space: O(1)
  dequeue() {
    return this.items.shift();
  }

  print() {
    const strings = this.items
      .map((item) => `Data: ${item.data} | Priority: ${item.priority}`)
      .join("\n");

    console.log(strings);
    return strings;
  }
}

const pQ = new PriorityQueue();
pQ.enqueue("Gary", 4);
pQ.enqueue("Jason", 2);
pQ.enqueue("Parker", 6);
pQ.enqueue("Ryan", 2);
pQ.print();
