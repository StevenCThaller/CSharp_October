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

    }

    // Write a method that will find the smallest value in the binary search tree
    min(){

    }

    // Write a method that will find the largest value in the binary search tree
    max(){

    }

    // Here's a method that will actually print the binary search tree out in a readable manner
    printTree(){
        if(this.root == null) {
            console.log("This tree is empty.");
            return this;
        }

        this.printHelper(this.root);
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