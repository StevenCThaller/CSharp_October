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
        let newNode = new DLNode(value);
        if(this.isEmpty()){
            this.tail = newNode;
            this.head = newNode;
            return this;
        }

        newNode.next = this.head;
        this.head.prev = newNode;
        this.head = newNode;
        return this;
    }

    // Write a method that will add to the back of our doubly linked list
    addToBack(value){
        let newNode = new DLNode(value);
        if(this.isEmpty()){
            this.tail = newNode;
            this.head = newNode;
            return this;
        }

        newNode.prev = this.tail;
        this.tail.next = newNode;
        this.tail = newNode;
        return this;
    }

    // Write a method that will remove a node with a given value from our list.
    // If no node with that value exists, return false. If that node is removed, return true
    removeNode(value){
        let headRun = this.head; 
        let tailRun = this.tail;
        while(headRun != tailRun && headRun.prev != tailRun) {
            if(headRun.value == value){

            } else if(tailRun.value == value){

            }
        }
    }
}