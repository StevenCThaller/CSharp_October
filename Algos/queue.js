const { SLNode, SLList } = require('./singly_linked_list');
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
        return this.items.splice(0,1); // ez
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
}

class SLLQueue{
    constructor(){
        this.items = new SLList();
    }

    // adds an item and returns the new size
    enqueue(value){
        this.items.addToBack(value); // add to the back of the queue
        return this.length(); // and return the size
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
}