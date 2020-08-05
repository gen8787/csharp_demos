/* 
  Return the fibonacci number at the nth position, recursively.
  
  Fibonacci sequence: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, ...

  The next number is found by adding up the two numbers before it,
  starting with 0 and 1 as the first two numbers of the sequence.
*/

const num1 = 0;
const expected1 = 0;

const num2 = 1;
const expected2 = 1;

const num3 = 2;
const expected3 = 1;

const num4 = 3;
const expected4 = 2;

const num5 = 4;
const expected5 = 3;

const num6 = 8;
const expected6 = 21;

// naive recursion
// Time: O(2^n) exponential
// Space: O(1)
function fibNaiveRecursion(n) {
  if (n < 0) {
    return null;
  }

  if (n < 2) {
    return n;
  }
  return fibNaiveRecursion(n - 1) + fibNaiveRecursion(n - 2);
}

/* 
  In computing, memoization or memoisation is an optimization technique used primarily to speed up computer programs by storing the results of expensive function calls and returning the cached result when the same inputs occur again.

  Time: O(2n) -> O(n) linear
  Space: O(n)
*/
function fibRecursive(n, memo = { 0: 0, 1: 1 }) {
  if (n < 0) {
    return null;
  }

  if (memo[n] !== undefined) {
    return memo[n];
  }

  memo[n] = fibRecursive(n - 1, memo) + fibRecursive(n - 2, memo);

  return memo[n];
}

// non recursive
// Time: O(n) linear
// Space: O(1) constant
function fibonacci(n) {
  if (n < 0) {
    return null;
  }

  const seq = [0, 1];

  for (let i = 2; i <= n; i++) {
    seq.push(seq[i - 2] + seq[i - 1]);
  }
  return seq[n];
}

// src=https://medium.com/developers-writing/fibonacci-sequence-algorithm-in-javascript-b253dc7e320e
function fib(n) {
  if (n < 0) {
    return null;
  }

  var prev = 1,
    prev2 = 0,
    temp;

  while (n > 0) {
    temp = prev;
    prev = prev + prev2;
    prev2 = temp;
    n--;
    // console.log("prev:", prev, "prev2:", prev2, "temp:", temp);
  }
  return prev2;
}
