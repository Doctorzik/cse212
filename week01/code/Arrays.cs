using System.Diagnostics;

public static class Arrays
{
  /// <summary>
  /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
  /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
  /// integer greater than 0.
  /// </summary>
  /// <returns>array of doubles that are the multiples of the supplied number</returns>
  public static double[] MultiplesOf(double number, int length)
  {
    // TODO Problem 1 Start
    // Remember: Using comments in your program, write down your process for solving this problem
    // step by step before you write the code. The plan should be clear enough that it could
    // be implemented by another person.
    // Solution Comment:
    //  Create an empty List to store all the multipes.
    // loop through the size of the number of multiples
    // from the least number of multiples which is 1 to the last
    // multiply with the starting number,
    // push or add the result of the multiplication to the List,
    // exit the loop when it get to the last number + 1, because the loop starts from 1,
    // return the List of mulitples.
    List<double> multiples = new();
    for (int i = 1; i < length + 1; ++i)
    {
      double resultMultiplication = number * i;
      multiples.Add(resultMultiplication);
    }
    Console.WriteLine(multiples);
    return multiples.ToArray();  // replace this return statement with your own
  }

  /// <summary>
  /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
  /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
  /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
  ///
  /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
  /// </summary>
  public static void RotateListRight(List<int> data, int amount)
  {
    // TODO Problem 2 Start
    // Remember: Using comments in your program, write down your process for solving this problem
    // step by step before you write the code. The plan should be clear enough that it could
    // be implemented by another person.


// get the length of the list

     int n = data.Count;

    // Normalize the rotation amount
    // Where rotation is starting from
    amount = amount % n;
    // No need to rotate if the amount is 0 or equal to the length of the list

     if (amount == 0)
       return; 
 // Check if the  amount is 1, 
   if(amount == 1)
   {   //Because only the last  item is rotated, take the last item, replace it with the first,
      data.Insert(0, data[n - amount]);
      // Remove the current last Item
      data.RemoveAt(n);
      return;
   }
     //if the amount is greated than whole number 1,
     // get the index of the value at which the rotation will start from
     int beginingIndex = n - amount;
     // Get a list starting from the beginningIndex to the end of the
     // data items 
     var itemsToRotate = data.GetRange(beginingIndex, n - beginingIndex);
     // Get the items that will not be rotated
     var itemsNotRotated= data.GetRange(0, beginingIndex);
  // Empty the original List
              data.Clear();
    // Bring the Items to rotate the the front
    data.AddRange(itemsToRotate);
    //Bring the items not rotated to the back
    data.AddRange(itemsNotRotated);
  
  }}