const { SLNode, SLList } = require('./singly_linked_list');
const { SLLStack } = require('./stack');
// A queue is a first in first out data structure.
// Design a class to represent a queue using an array to store the items.
// After that, design a class to represent a queue using a singly linked list
// to store the items

class ArrayQueue {
    constructor(){
        this.items = [];
    }

    // adds an item and returns the new size
    enqueue(value){
        this.items.push(value); // add to the end of the array
        return this.items.length; // return the length
    }

    // removes an item and returns it
    dequeue(){
        return this.items.splice(0,1)[0]; // ez
    }

    // returns a boolean based on whether or not the queue is empty
    isEmpty(){
        return this.items.length === 0; // if it's empty, length is 0
    }

    // returns the number of elements in the queue
    size(){
        return this.items.length; // length of the array == size of the queue
    }

    // returns the first item without removing it
    front(){
        return this.items[0]; // first item in queue is index 0 in the array
    }

    // - create a method on the array Queue class that returns whether or not the sum of the first half of the queue is equal to the sum of the second half
    // - DO NOT manually index the queue items, only use the provided queue methods, use no additional arrays or objects for storage
    // - restore the queue to it's original state before returning    
    sumOfHalvesEqual(){
        let count = this.size(); // we're gonna need to know what "half" is, so we'll find the size
        let sum1 = 0; // for storing the sum of the first half
        let sum2 = 0; // for storing the sum of the second half

        // find sum of first half
        for(let i = 0; i < count/2; i++){
            let dequeued = this.dequeue(); // dequeue to add to the sum
            sum1 += dequeued; // add the dequeued entry to the sum
            this.enqueue(dequeued); // and re-add it to the queue
        }

        // find the sum of the second half
        for(let i = count/2; i < count; i++) {
            let dequeued = this.dequeue();
            sum2 += dequeued;
            this.enqueue(dequeued);
        }

        return sum1 == sum2; // then return whether or not they're the same
    }
}


class SLLQueue{
    constructor(){
        this.items = new SLList();
    }

    // adds an item and returns the new size
    enqueue(value){
        this.items.addToBack(value); // add to the back of the queue
        return this.items.length(); // and return the size
    }

    // removes an item and returns it
    dequeue(){
        const removed = this.items.head; // store the node we're about to chop off
        this.items.removeHead(); // chop it off
        return removed; // return it
    }

    // returns a boolean based on whether or not the queue is empty
    isEmpty(){
        return this.items.isEmpty(); // we already built this yo
    }

    // returns the number of elements in the queue
    size(){
        return this.items.length(); // we built this method specifically for this reason!
    }

    // returns the first item without removing it
    front(){
        return this.items.head; // start of the list is front of the queue
    }

    // - Write a method on the Queue class that, given another queue, will return whether they are equal (same items in same order)
    // - Use ONLY the provided queue methods, do not manually index the queue items, no extra array or objects
    // - Restore the queues to their original state
    compareQueues(queue){
        // let's make a fast-fail! If the two queues are different sizes, we know they're not the same. this will also help with not erroring out later on
        let count1 = this.size();
        let count2 = queue.size();
        if(count1 != count2) {
            return false;
        }

        
        let same = true; //initialize a boolean to true
        for(let i = 0; i < count1; i++){ // loop through the queue, basically
            let item1 = this.dequeue(); // remove the first item from each node
            let item2 = queue.dequeue();
            if(item1.value != item2.value){ // compare them
                same = false; // if they're different, the queues aren't "the same"
            }
            this.enqueue(item1.value);// add them back into their respective queues
            queue.enqueue(item2.value);
        }

        return same; // if every item was the same, "same" is still true. otherwise it's been flipped to false
    }

    // - write a method on the Queue class that returns whether or not the queue is a palindrome
    // - use only 1 stack as additional storage (no additional arrays / objects)
    // - do not manually index the queue, use the provided queue methods and stack methods, restore the queue to original state when done
    queueIsPalindrome(){
        let count = this.size();
        let stack = new SLLStack();

        for(let i = 0; i < count; i++) { // the biggest thing to recognize is that emptying a queue into a stack will make it so the stack empties out in reverse order
            let dequeued = this.dequeue().value;
            stack.push(dequeued);
            this.enqueue(dequeued);
        }

        let palindrome = true; // boolean starting at true

        for(let i = 0; i < count; i++){
            if(stack.peek().value != this.front().value){ // if the start of the queue isn't the same as the back (aka top of the stack)
                palindrome = false; // no palindrome
            }
            let dequeued = this.dequeue().value; // dequeue, and add it back to the queue and top of the stack
            this.enqueue(dequeued);
            stack.pop();
        }

        return palindrome;
    }
}
// - create enqueue and dequeue methods on a new queue class that uses ONLY 2 stacks to store your items
// - use only the provided stack methods from the two stacks (do not directly index)
// - i.e., how do you make a FIFO (First in First Out) data structure using two LIFO (Last in First Out) Stack data structures?
class StackQueue{
    constructor(){
        this.items = new SLLStack();
        this.secondStack = new SLLStack();
    }

    enqueue(value){
        // The idea is that if we empty our first stack into our second stack, the top of the second stack will be what was previously
        // the bottom of the first stack
        while(!this.items.isEmpty()){
            this.secondStack.push(this.items.pop().value);
        }
        // then we add the new value onto the top of the second stack
        this.items.push(value);
        // and then empty it all back from stack 2 into stack 1
        while(!this.secondStack.isEmpty()){
            this.items.push(this.secondStack.pop().value);
        }

        // which is the same as adding to the back of the queue. 

        // NOTE: This is the case because I decided I wanted the top of my stack to be the front of my queue
        return this.items.size();
    }

    dequeue(){
        return this.items.pop();
    }
}