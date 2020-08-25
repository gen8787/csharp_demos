class MinHeap {
  constructor() {
    // 0th index not used, so null is a placeholder. Not using 0th index helps make some calculations simpler
    // are array is now sort of 1-based instead of 0-based since the first real value will be index 1;
    this.heap = [null];
  }

  // Time: O(1) constant
  // Space: O(1)
  top() {
    return this.heap.length > 1 ? this.heap[1] : null;
  }

  // Time: O(log n) logarithmic due to shiftUp
  // Space: O(1) constant
  insert(val) {
    this.heap.push(val);
    this.shiftUp();
    return this;
  }

  shiftUp() {
    // so we don't have to keep typing this.
    const heap = this.heap;

    let idxOfNodeToShiftUp = heap.length - 1;

    this.printArr(
      `shiftUp start from back to shift ${heap[idxOfNodeToShiftUp]} up:`
    );
    this.printHorizontalTree();

    while (idxOfNodeToShiftUp > 1) {
      const idxOfParent = Math.floor(idxOfNodeToShiftUp / 2);

      // parent is already smaller or equal, no more swapping needed
      if (heap[idxOfParent] <= heap[idxOfNodeToShiftUp]) {
        break;
      }

      // while the parent is NOT smaller or equal, swap it with it's child (array destructure swap syntax)
      // when the while loop is done, the new node is in it's correct place so all parents are smaller or equal to children
      [heap[idxOfNodeToShiftUp], heap[idxOfParent]] = [
        heap[idxOfParent],
        heap[idxOfNodeToShiftUp],
      ];

      this.printArr(
        `shiftUp swapped ${heap[idxOfParent]} & ${heap[idxOfNodeToShiftUp]}:`
      );
      this.printHorizontalTree();

      idxOfNodeToShiftUp = idxOfParent;
    }
    console.log("shiftUp done\n");
  }

  // Time: O(log n) logarithmic due to shiftDown
  // Space: O(1) constant
  extract() {
    const heap = this.heap,
      min = heap[1],
      lastNode = heap.pop();

    heap[1] = lastNode;
    // since we put the lastNode at the start, it needs to be swapped down to it's correct position to restore the order
    this.shiftDown();
    return min;
  }

  // AKA: siftDown, heapifyDown, bubbleDown, sinkDown to restore order after extracting min
  shiftDown() {
    const heap = this.heap;

    let idxOfNodeToShiftDown = 1,
      idxOfLeftChild = idxOfNodeToShiftDown * 2;

    this.printArr(
      `shiftDown start from front to shift ${heap[idxOfNodeToShiftDown]} down:`
    );
    this.printHorizontalTree();

    // while there is at least 1 child
    while (idxOfLeftChild < heap.length) {
      const idxOfRightChild = idxOfLeftChild + 1;
      let idxOfSmallestChild = idxOfLeftChild;

      if (
        idxOfRightChild < heap.length &&
        heap[idxOfRightChild] < heap[idxOfLeftChild]
      ) {
        idxOfSmallestChild = idxOfRightChild;
      }

      // no more swapping needed, no children are smaller
      if (heap[idxOfNodeToShiftDown] <= heap[idxOfSmallestChild]) {
        break;
      }

      // swap the smallest child with the parent since the parent is larger
      [heap[idxOfNodeToShiftDown], heap[idxOfSmallestChild]] = [
        heap[idxOfSmallestChild],
        heap[idxOfNodeToShiftDown],
      ];

      this.printArr(
        `shiftDown swapped ${heap[idxOfSmallestChild]} & ${heap[idxOfNodeToShiftDown]}:`
      );
      this.printHorizontalTree();

      // follow this node since it was just swapped to see if it needs to be swapped again
      idxOfNodeToShiftDown = idxOfSmallestChild;
      idxOfLeftChild = idxOfNodeToShiftDown * 2;
    }
    console.log("shiftDown done\n");
  }

  // prints tree with root on left and index in parens in reverse inorder traversal
  // https://www.geeksforgeeks.org/print-binary-tree-2-dimensions/
  printHorizontalTree(parentIdx = 1, spaceCnt = 0, spaceIncr = 10) {
    if (parentIdx > this.heap.length - 1) {
      return;
    }

    spaceCnt += spaceIncr;
    this.printHorizontalTree(parentIdx * 2 + 1, spaceCnt);

    console.log(
      " ".repeat(spaceCnt < spaceIncr ? 0 : spaceCnt - spaceIncr) +
        `${this.heap[parentIdx]} (${parentIdx})`
    );

    this.printHorizontalTree(parentIdx * 2, spaceCnt);
  }

  printArr(...appendedMsgs) {
    const arrStr = `\n[${["null", ...this.heap.slice(1)].join(", ")}]`;
    const msgLen = arrStr.length + appendedMsgs.toString().length;
    console.log("-".repeat(msgLen), arrStr, ...appendedMsgs);
  }
}

const minHeap = new MinHeap();
minHeap
  .insert(5)
  .insert(4)
  .insert(7)
  .insert(3)
  .insert(6)
  .insert(2)
  .insert(1)
  .insert(0);
