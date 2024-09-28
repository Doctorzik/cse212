using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: A number of items and their priority is added to the queue
    // "brush" (3), "pray" (7), "eat" (2), "social media" (1);
    // Expected Result: 
    // [pray, brush, eat, social media]
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {   
        var priorityQueue = new PriorityQueue();
         priorityQueue.Enqueue("brush", 3);
         priorityQueue.Enqueue("pray", 7);
         priorityQueue.Enqueue("eat", 2);
         priorityQueue.Enqueue("social", 1);

         for(int i = 0 ; i < 5; ++i){
            var highestPriorityItem =    priorityQueue.Dequeue();
            Assert.AreEqual(highestPriorityItem, "pray");
            
         } 
        
 
    }

    [TestMethod]
    // Scenario:  There are    multiple items with same priority
    // "brush" (3), "pray" (7), "eat" (2), "social media" (1), "game" (4), "exercise" (4);
    
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("brush", 6);
        priorityQueue.Enqueue("pray", 7);
        priorityQueue.Enqueue("eat", 7);
        priorityQueue.Enqueue("game", 4);
        priorityQueue.Enqueue("exercise", 4);
       
         for(int i = 0 ; i < 5; ++i){
            var highestPriorityItem =    priorityQueue.Dequeue();
            Assert.AreEqual(highestPriorityItem, "pray");
            
         } 

    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario:  There are    multiple items with same priority that a far apart in the queu
    // "brush" (3), "pray" (7), "eat" (2), "social media" (1), "game" (4), "exercise" (4) "marry" (7);
    
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("brush", 6);
        priorityQueue.Enqueue("marry", 7);
        priorityQueue.Enqueue("eat", 2);
        priorityQueue.Enqueue("game", 4);
        priorityQueue.Enqueue("exercise", 4);
        priorityQueue.Enqueue("pray", 7);

       
         for(int i = 0 ; i < 5; ++i){
            var highestPriorityItem =    priorityQueue.Dequeue();
            Assert.AreEqual(highestPriorityItem, "pray");
            
         } 

    }

}
