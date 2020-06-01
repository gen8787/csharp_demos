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

  getYou() {
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

famList.getYou();
