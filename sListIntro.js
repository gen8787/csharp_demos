class Person {
  constructor(name) {
    this.name = name;
    this.firstChild = null;
  }
}

class FamList {
  constructor() {
    this.headOfHousehold = null;
  }

  getYoungestChild() {
    let runner = this.headOfHousehold;

    while (runner.firstChild !== null) {
      runner = runner.firstChild;
    }

    console.log(runner);
  }
}

const greatGrandpa = new Person("Great Grandpa");
greatGrandpa.firstChild = new Person("Grandpa");
greatGrandpa.firstChild.firstChild = new Person("Dad");
greatGrandpa.firstChild.firstChild.firstChild = new Person("You");
const you = greatGrandpa.firstChild.firstChild.firstChild;

const famList = new FamList();
famList.headOfHousehold = greatGrandpa;

famList.getYoungestChild();

const myNode = new Node(5);
myNode.next = new Node(6);
myNode.next.next = new Node(7);

// x now refers to the same object that the myNode var
let x = myNode;

// since x refers to the same object as myNode, this is updating the same object by "reference"
x.data = 10;

// this simply reassigns the variable x, from refering to the myNode object to now being a string
// this does nothing to the myNode object, we just overwrote the value of the x variable
x = "reassigned x";

// similarly, runner now refers to the same myNode object
let runner = myNode;

// runner var is simply reassigned to the next node object, no object was updated because it is just reassigning a var
runner = runner.next;

// the runner var is NOT being reassigned, the object that the runner var refers to is having it's next key UPDATED by refrence
// instead of the next node being what it used to be, it is now the next next node (old next is skipped now)
runner.next = runner.next.next;
