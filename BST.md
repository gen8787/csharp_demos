# Binary Search Trees

- thur and fri have a non BST algo in case too many people are struggling with BSTs so you can pivot after covering the more basic BST algos

- [Algo Book - Ch 11](http://algorithms.dojo.news/static/Algorithms/index.html#LinkTarget_2135)
- [Binary Search Tree Drawing](https://cdn-media-1.freecodecamp.org/images/2rTqYlcrnWtICedt131tDft0CmkzZaViExJX)
- [Interactive BST Insert Delete Find](https://www.cs.usfca.edu/~galles/visualization/BST.html)

---

## Description

- is an ordered data structure
- but has a root instead of a head and nodes have left & right instead of next
  - using this information, create the necessary classes

---

### Parent / Child

- left and right are children of parent

---

### left

- value less than parent

---

### right

- value greater than parent

---

### left 'subtree' (entire left side of root)

- all less than root node

---

### right 'subtree' (entire right side of root)

- all greater than root node

---

### Leaf Nodes

- have no children

---

### Duplicates

- child that is same value of parent is chosen to be either right or left, just be consistent
  - however, this increases height of tree which increases time complexity
  - a solution is to add a count key to node and increment it for dupes
    - [Geeks for geeks BST Dupes](https://www.geeksforgeeks.org/how-to-handle-duplicates-in-binary-search-tree/)
