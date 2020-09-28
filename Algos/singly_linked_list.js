// Class for the node of our singly linked list
class SLNode {
    constructor(value) {
        this.value = value;
        this.next = null;
    }
}
// How do we actually create a new node?
// let mynode = new SLNode(10);
// console.log(mynode)

// Class for a singly linked list
class SLList {
    constructor(){
        // The only attribute we actually need is the head of the list
        this.head = null;
    }

    // This method should return a boolean
    // True if the list is empty, false if it is not
    isEmpty(){

    }


    addToBack(value){

        // // Assign the head of the list to a variable called runner
        // let runner = this.head;

        // // to move the runner down the line
        // runner = runner.next;

        // // if we want to reach the LAST node:
        // while(runner.next != null){
        //     runner = runner.next;
        // }

        // // if we want to run through ALL nodes, and be left sitting at null
        // while(runner != null) {

        // }
    }

    // BONUS:
    // Write a method that takes an array as a parameter, and converts it into a singly linked list
    
    // EXAMPLE:
    // seedFromArr([1,2,3,4]) would return 
    // 1 -> 2 -> 3 -> 4 ->
    seedFromArr(array){

    }

    printList(){
        if(this.head == null) {
            console.log("List is empty.");
            return;
        }
        let output = '';
        let runner = this.head;
        while(runner != null) {
            output += `${runner.value} -> `;
            runner = runner.next;
        }
        console.log(output);
        return;
    }
}

let myList = new SLList();

myList.head = new SLNode(10);
myList.head.next = new SLNode(4);
myList.head.next.next = new SLNode(7);

myList.printList();