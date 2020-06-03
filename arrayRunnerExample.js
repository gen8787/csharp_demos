Array.prototype.sendRunner = function () {
  let runner = 0;

  while (runner < this.length) {
    const data = this[runner];
    runner = runner + 1; // next increment
    console.log(data);
  }
};

const yourNums = [1, 2, 3, 4];
const myNumsNotYourNums = [10, 100];

yourNums.sendRunner();
myNumsNotYourNums.sendRunner();
