class MinHeap {
  constructor() {
    // 0th index not used, so null is a placeholder. Not using 0th index helps make some calculations simpler
    // are array is now sort of 1-based instead of 0-based since the first real value will be index 1;
    this.heap = [null];
  }

  insert(val) {
    this.heap.push(val);
    this.shiftUp();
    return this;
  }

  shiftUp() {
    // see shiftUp in Heaps.md to implement
  }
}
