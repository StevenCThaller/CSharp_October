class BSNode {
    constructor(value){
        this.value = value;
        this.left = null;
        this.right = null;
    }
}


// EXAMPLE TREE AS COMMENT
/*
                    root
                <-- 25 -->
              /            \
            15             50
          /    \         /    \
        10     22      35     70
      /   \   /  \    /  \   /  \
    4    12  18  24  31  44 66  90
*/
class BSTree {
    constructor(){
        this.root = null;
    }

    // Write a method that will return a boolean based on whether or not the tree is empty
    isEmpty(){
        return this.root == null; // just like our singly linked list, if the "start" is null, then the whole thing is empty!

    }

    // Write a method that will find the smallest value in the binary search tree
    min(){
        // KEY POINT! What values go where?
        // If there's a node to the LEFT of the current node, it will be smaller
        // By that logic, the minimum value will be ALL the way to the left
        if(this.isEmpty()){ // if the tree is empty
            return null; // there can't be a minimum value
        }
        let runner = this.root; // otherwise, let's start our runner at the root
        while(runner.left != null){ // and until we're as far to the left as we can go
            runner = runner.left; // we'll move the runner to the left
        }
        return runner.value; // once we've reached the left-most edge, we'll return its value
    }

    // Write a method that will find the largest value in the binary search tree
    max(){
        // KEY POINT! What values go where?
        // If there's a node to the RIGHT of the current node, it will be larger (or equal)
        // By that logic, the maximum value will be ALL the way to the right
        if(this.isEmpty()){ // if the tree is empty
            return null; // there can't be a maximum value
        }
        let runner = this.root; // otherwise let's start our runner at the root
        while(runner.right != null) { // and until we're as far to the right as we can go
            runner = runner.right; // we'll move runner to the right
        }
        return runner.value; // once we've reached the right-most edge, we'll return its value
    }

    // Here's a method that will actually print the binary search tree out in a readable manner
    printTree(){
        if(this.root == null) {
            console.log("This tree is empty.");
            return this;
        }

        this.printHelper("", this.root);
    }
    printHelper(toPrint = "", runner) {
        if(runner == null) {
            return this;
        }

        toPrint += "\t";
        this.printHelper(toPrint, runner.right);
        console.log(`${toPrint}${runner.value}`);
        this.printHelper(toPrint, runner.left);
    }

    // Write a method that determines whether or not the binary search tree contains a node with a given value
    contains(value){
        let runner = this.root; // We need our runner to traverse through the binary search tree
        while(runner != null) { // while the runner isn't null, we'll do 1 of 3 things:
            if(runner.value == value) return true; // if the runner has the value we're looking for, then obviously the tree contains that value, so return true.
            else if(value > runner.value) runner = runner.right; // if the value we're looking for is greater than the current node's value, we'll go to the right
            else runner = runner.left; // otherwise, it must be less than the current node's value, so go to the left
        }
        return false; // if we finished running through the tree in that manner, it means runner is null, and the tree does not contain the given value
    }

    // Write a method that determines and returns the range of the binary search tree.
    // The range of a BST is the difference between the largest and smallest elements.
    range(){
        if(this.isEmpty()){ // if the tree is empty, we'll just return 0 and console log that it's empty
            console.log("Tree's empty.");
            return 0;
        }
        return this.max() - this.min(); // SUPER straightforward.
    }

    // Write a method that adds a new node to the binary search tree in the appropriate place
    // REMEMBER!! greater than or equal to the right, less than to the left!
    insert(value){
        if(this.isEmpty()){ // if the tree is empty, the new node is going to be the new root
            this.root = new BSNode(value); 
            return this;
        }

        let runner = this.root; // start our runner at the root
        while(runner != null) { // ideally, we'll never actually reach a point where runner is null, but for the sake of having a way to iterate
            if(value >= runner.value) { // if the value we want to add is greater than or equal to the runner's value
                if(runner.right == null) { // we'll first check to see if the runner's .right is null
                    runner.right = new BSNode(value); // if it is, that's where we want to add our new node
                    return this; // and return
                } else { //otherwise, if there IS  node to the right
                    runner = runner.right; // move the runner to that node
                }
            } else { // if the value we are looking to add is LESS than the current node's value
                if(runner.left == null) { // check to see if there IS a runner.left
                    runner.left = new BSNode(value); // and if there is not, that's where the new node will go
                    return this; // and then return this!
                } else { // otherwise, we want to move the runner to the left
                    runner = runner.left;
                }
            }
        }
        return false; // let's just drop this here in case?
    }

    // BONUS:
    // The same as above, but recursively!
    insertRecursive(value, runner = this.root, prev = null) {
        if(this.root == null) { // edge case: same as usual: if the root is null, new node is the root
            this.root = new BSNode(value);
            return this;
        }

        if(runner == null) { // break case: when the runner reaches null
            if(prev.value <= value) prev.right = new BSNode(value); // our prev parameter is used to keep track of the previous node so we know if the new node should be to the right or left of it
            else prev.left = new BSNode(value);
            return this; // after the new node's been created, return the tree
        } else if(value >= runner.value){ // if we still need to traverse
            return this.insertRecursive(value, runner.right, runner); // make recursive call to the right
        } else {
            return this.insertRecursive(value, runner.left, runner); // or left, depending on which way it needs to go.
        }
    }
}

let myTree = new BSTree();
myTree.insert(15).insertRecursive(10).insert(20);
myTree.insert(17).insert(25).insert(5).insert(13);
myTree.printTree();