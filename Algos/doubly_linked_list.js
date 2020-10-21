class DLNode{
    constructor(val){
        this.value = val;
        this.prev = null;
        this.next = null;
    }
}

class DLList{
    constructor(){
        this.head = null;
        this.tail = null;
    }

    isEmpty(){
        return this.head == null;
    }

    // Write a method that will add to the front of our doubly linked list
    addToFront(value){

    }

    // Write a method that will add to the back of our doubly linked list
    addToBack(value){

    }

    // Write a method that will remove a node with a given value from our list.
    // If no node with that value exists, return null. If that node is removed, return true
    removeNode(value){

    }
}