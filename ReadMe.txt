Read Me


*Overview*
The InsertionSortProject program is a project created to observe the elapsed running times for two algorithms, 
Insertion Sort using Linear Search and Insertion Sort using Binary Search. Built using C#, 
we make use of the Systems Diagnostic class to monitor the execution times 
for a variety of array lengths 30, 300, 3000, 30000.



*How it works*
The code is simple and straight forwards, in the Main method you will notice three 
variables Min, Max and arrLen. Min and Max refer to the range of values based on 
the minimum and maximum integer variables that go into each index of the array. 
You also have arrLen, which denotes the length of the array. Currently it is set 
to Min = 100 and Max 400 and the length of the array is based on the n column in
the table above. These variables will be passed into a CreateRandomArray method to, 
as the name say create an array of n length, with pseudorandom values.

This array will then be placed into both Insertion Sort methods each with their 
respective search methods. Once completed, the values will be returned to the calling 
function, that will then be displayed in the console. Which will print some text 
noting the elapsed time for each InsertionSort method.



*How to Run The Program*
•	To execute the code, all you need to do is set the Min and Max range of Integers you want to populate the array with
•	For the arrLen variable, set that to nth amount based on the table above
•	Execute program



*Time Complexity*
Insertion Sort w/ Linear Search

T(n) = 

Insertion Sort w/ Binary Search

T(n) = 

*Comments*
When running the code, there will be some cases where the results will reflect
that the Linear Search portion of the algorithm will outperform the 
Binary Search. But that is somthing that will be seen when length n is 
very small, around n=30 to n= 300 to be exact. But in most cases, you
should see that Binary Search will outperform Linear Search majority of the time,
espacially as n grows towards 3000 and 30000.