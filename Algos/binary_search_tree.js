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
}

let myTree = new BSTree();
myTree.root = new BSNode(10);
myTree.root.left = new BSNode(4);
myTree.root.right = new BSNode(12);
