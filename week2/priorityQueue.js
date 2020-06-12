class QElement {
  constructor(element, priority) {
    this.element = element;
    this.priority = priority;
  }
}

class PriorityQueue {
  constructor(items = []) {
    this.items = items;
  }

  enqueue(element, priority) {
    // can use either of these item objects as our new item
    // const item = { element: element, priority: priority };
    const qItem = new QElement(element, priority);
    let queued = false;

    for (let i = 0; i < this.items.length; i++) {
      // since lower priority is more important, we found the index that this new item belongs
      if (this.items[i].priority > qItem.priority) {
        queued = true;
        this.items.splice(i, 0, qItem);
        return this.items.length;
      }
    }

    if (!queued) {
      this.items.push(qItem);
    }
    return this.items.length;
  }

  // if empty will return undefined
  // Time: O(n) linear, due to having to shift all the remaining items to the left after removing first elem
  // Space: O(1)
  dequeue() {
    return this.items.shift();
  }

  display() {
    let str = "";

    for (const item of this.items) {
      if (str !== "") {
        str += ", ";
      }

      str += JSON.stringify({ element: item.element, priority: item.priority });
    }
    console.log(str);
    return str;
  }
}

const q = new PriorityQueue();
q.enqueue("Aric", 4);
q.enqueue("DJ", 6);
q.enqueue("Patrick", 2);
q.enqueue("The Instructional One", 1);

q.display();
