const { SLNode, SLList } = require('./singly_linked_list');
// A stack is a last in first out data structure.
// Design a class to represent a stack using an array to store the items.
// After that, design a class to represent a stack using a singly linked list
// to store the items

class ArrayStack {
    constructor(){
        this.items = [];
    }

    // Adds a new item and returns the size of the stack
    push(value){
        this.items.push(value); // adding to the stack
        return this.items.length; // return the size of the stack
    }

    // returns the removed item
    pop(){
        return this.items.pop(); // this will remove the last item in the stack and return it
    }

    // returns true or false
    isEmpty(){
        return this.items.length === 0; // if the length is 0, it's empty!
    }

    // returns the number of items in the stack
    size(){
        return this.items.length; // the length of the array is the number of items in the stack
    }

    // return the top item without removing it
    peek(){
        return this.items[this.items.length-1]; // considering our push and pop functioned at the end of the array,
        // the "top" of the stack is the end of the array!
    }
}

// Personal recommendation:
// treat the FRONT of the SLL as the top of the stack
class SLLStack {
    constructor(){
        this.items = new SLList();
    }

    // Adds a new item and returns the size of the stack
    push(value){
        this.items.addToFront(value); // add to the front of the sll (top of the stack)
        return this.items.length(); // return the length
    }

    // returns the removed item
    pop(){
        // for this one, our SLL's removeHead method doesn't return the node
        // so let's hold onto it
        let removed = this.items.head;
        this.items.removeHead(); // chop it off the list
        return removed; // and return it
    }

    // returns true or false
    isEmpty(){
        return this.items.isEmpty(); // hey we built that already!
    }

    // returns the number of items in the stack
    size(){
        return this.items.length(); // this one too!
    }

    // return the top item without removing it
    peek(){
        return this.items.head; // top of the stack is the head of the list!
    }
}

module.exports = {
    SLLStack
}

