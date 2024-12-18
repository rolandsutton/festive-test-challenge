# Introduction
Claus Delivery Enterprises are updating their systems and have written a load of new software however, development elves are are lazy and haven't written any unit tests. This is where you come in.
Each day there will be a new unit test challenge that will start simple and get more involved, there shouldn't take longer than 10 minutes, but hopefully will make you think.

If you get stuck, ask a colleague, ask google, ask me, even peek at my solution, let's get talking about what makes a good unit test.
The solutions in the test project are using nunit and nsubstitute but pick whatever tools you like.
While you're doing it have a think about what makes a good test and what a good test should cover.

I'll make sure that there are chocolates at the end to celebrate.

The code and solutions can be found at
https://github.com/rolandsutton/festive-test-challenge
so just clone the repository and fill your festive testing boots.
Rules
1. It's just a bit of festive fun.
2. The software in no way is supposed to represent a real system, so no complaints about how the elves have architected things to give some contrived testing situation.
3. The solutions in the test projects are just examples of one way in which the test could be written not necessarily  the perfect solution - I'd like to learn as well.
4. Feel free to share as far and wide as you see fit and ask any questions or make suggestions.


# Day 1
Starting simple, the code to test in in BlueCastle.Santa.Lib/Source/day1 create your own test project in the solution and test that inProgress is set when Go() is called.
Think about the name and structure  of your tests so that when the DevOps elves are setting up for next year's season they can maybe understand what's going on.

 