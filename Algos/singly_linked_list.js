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
        // All we want to do is return a boolean for whether or not the list is empty, so here's 2 ways

        // Method 1: The 'thorough' way

        // If the head is null, it means the list is empty
        if(this.head == null) {
            // so return true
            return true;
        } else { 
            // otherwise, return false!
            return false;
        }

        // Method 2: The 'slick' way

        return this.head === null;
    }


    addToBack(value){
        // For that edge case we talked about, let's see if the list is empty!
        if(this.isEmpty()){
            // If this list is indeed empty, we just need to set the head to 
            // a new node with the passed in value
            this.head = new SLNode(value);
            // And I'll return this so we can method chain if we want
            return this;
        }

        // If the list is NOT empty, we want to create our runner and assign it to the head of the list
        let runner = this.head;

        // and progress it to the LAST node
        while(runner.next != null) {
            runner = runner.next
        }

        // after breaking out of the loop, we need to set the next node to the new one
        runner.next = new SLNode(value);

        // and finally, return this so we can chain
        return this;
    }

    // BONUS:
    // Write a method that takes an array as a parameter, and converts it into a singly linked list
    
    // EXAMPLE:
    // seedFromArr([1,2,3,4]) would return 
    // 1 -> 2 -> 3 -> 4 ->
    seedFromArr(array){
        // this method is going to utilize our previously defined addToBack method!

        // We first need to loop through the array
        for(let i = 0; i < array.length; i++){
            // for each element in the array, let's add it to the back of our SLL!
            this.addToBack(array[i]);
        }

        // Alternative solution 1
        // for(let num of array) {
        //     this.addToBack(num);
        // }

        // Alternative solution 2
        // array.forEach(value => this.addToBack(value));

        // and that's it!
        return this;

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