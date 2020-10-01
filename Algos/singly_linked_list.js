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


    // Write a method that returns a boolean based on whether or not the linked
    // list contains a node with given value
    contains(value){
        // Basic logic:
        // start at the head, and check each node to see if it's the value.
        // if at any point we find that value, we'll return true.
        // if we reach the end of the list, return false
        let runner = this.head; // our runner, duh.
        while(runner != null) { // we want to check every single node
            if(runner.value == value){ // check to see if the value matches
                return true; // if it does, then our list does contain the value.
            }
            runner = runner.next; // otherwise, let's move the runner to the next node
        }
        return false; // if we exit the while loop, it means we never found the value, so it must not contain it.
    }

    // Write a method that will remove the last node from the linked list
    // HINT: You'll need to find out when you're at the SECOND TO LAST node
    removeFromBack(){
        // Basic logic:
        // first, check to see if the list is empty. if it is, we're done.
        // if the list is only 1 element in length, set the head to null
        // otherwise, let's get to the second to last node, then lop off the last node

        if(this.isEmpty()){ // if the list has no nodes to remove
            return this; // just return
        } else if (this.head.next == null) { // if the list only has ONE node
            this.head = null; // then set the head to null
            return this; // and return
        } else { // otherwise
            let lagger = this.head; // this is how we're going to stay 1 behind the last node
            let runner = this.head.next; // this will be the last node (eventually)

            while(runner.next != null) { // running until runner.next is null will put runner at the last node, and lagger at the 2nd to last node
                lagger = runner; // move the lagger up to the runner
                runner = runner.next; // and move the runner to the next node
            }

            lagger.next = null; // setting lagger's .next to null effectively removes the last node from the list
            return this; // and voila we're done!
        }
    }

    // Write a method that will return the second to last value in the linked list
    secondToLast(){
        if(this.isEmpty() || this.head.next == null){ // If the list is empty or only 1 element in length, we'll return null
            return null;
        }
        let runner = this.head;// start at the first node
        while(runner.next.next != null){ //until runner's .next has a .next of null, we want to move down the line
            runner = runner.next;
        }
        return runner.value; // at the point where runner.next.next == null, runner is the second to last node, so let's return its value!
    }

    // Write a method that will remove the first node with a given value, and return true or false
    // based on whether that value actually existed and was removed
    removeVal(value){
        if(this.isEmpty()){ // if the list is empty, there's nothing to remove
            return false;
        } else if (this.head.value == value){ // if the first node is the one we want to remove
            this.removeHead(); // we can just use our remove head method we already built
            return true; // and return true!
        } else {
            let runner = this.head; // start the runner at the head of the list
            while(runner.next != null){ // I'm going to use while runner.next != null because I'm going to be checking the next node each step of the way
                if(runner.next.value == value){ // if the next node has our desired value
                    runner.next = runner.next.next; // set runner's .next to the removed node's .next
                    return true; // and return true
                }
                runner = runner.next; // move runner to the next node
            }
            return false; // if we reached the end of our list, we never found the node, so there's nothing to remove.
        }
    }
}