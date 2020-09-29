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
        // // optional:
        // this.length = 0;
    }

    length(){
        let length = 0; 
        let runner = this.head;

        while(runner != null){
            length++;
            runner = runner.next;
        }
        return length;
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

    // Write a method that will add to the FRONT of a singly linked list
    // The biggest thing to keep in mind here is that adding to the front 
    // of a singly linked list means you are setting a NEW head.
    addToFront(value) {
        // The edge case was a trick! Whether or not the list is empty doesn't impact
        // anything for this one!

        
        let newNode = new SLNode(value); // Let's first create our new node
        newNode.next = this.head; // then set its .next to the head of the SLL
        this.head = newNode; // and then set the head to our new node
        return this; // and finally, return this
        
    }

    // Write a function that REMOVES the head of a singly linked list
    removeHead(){
        // In order to remove the head of the SLL, there must BE a head
        if(this.isEmpty()){
            // If there isn't, there's nothing to do...
            return null;
        }

        // Let's rely on garbage collection!
        this.head = this.head.next;

        // ... that's it...
        return this;

        // Now, depending on how we wanted this method to work specifically, we 
        // could have had it return the removed node, which would look something like this:

        let removedNode = this.head;
        this.head = removedNode.next;
        removedNode.next = null;
        return removedNode;

    }

    // BONUS:
    // Write a method that will calculate and return the average of the 
    // singly linked list
    average(){
        // If the list is empty, there's no average to calculate.
        if(this.isEmpty()){
            return 0;
        }

        // now, if the list isn't empty, we need to get to calculatin!
        let runner = this.head; // y'all know the deal with this one by now
        let sum = 0; // to keep track of the sum as we iterate through the list
        let length = 0; // to keep track of how many elements are in the SLL to calculate the average

        while(runner != null){ // we want to move runner, adding to the sum and length until we finish touching every node
            sum += runner.value; // add the runner's value to the sum
            length++; // increment the length
            runner = runner.next; // and move the runner to the next node
        }

        // now that we've finished running through the list, let's calculate the average and return it
        return sum/length;

    }
}