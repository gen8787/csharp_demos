// http://algorithms.dojo.news/static/Algorithms/index.html#LinkTarget_2129
/* 
  String Anagrams

  Given a string,
  return array where each element is a string representing a different anagram (a different sequence of the letters in that string).

  Ok to use built in methods
*/

const str1 = "lim";
const expected1 = ["ilm", "iml", "lim", "lmi", "mil", "mli"];
// Order of the output array does not matter

// Time: O(n^2 * n!) https://www.geeksforgeeks.org/time-complexity-permutations-string/
// Space: O(n!) factorial
function stringAnagrams(str, solutions = [], partial = "") {
  if (!str) {
    solutions.push(partial);
  }

  for (let i = 0; i < str.length; i++) {
    const leftSlice = str.slice(0, i);
    const rightSlice = str.slice(i + 1); // skips current letter
    stringAnagrams(leftSlice + rightSlice, solutions, partial + str[i]);
  }
  return solutions;
}
