An exercise I did once and later committed. Mostly useful for the TDD improvements. 

Progress I made:

- First I wrote the **Recursive** StringCombinationFinderRecursive.
    - This loops over the whole list repeatedly to see if it can find a match. This worked functionally, but was extremely inefficient and took way too long (500+ seconds). NOK
- Secondly I started with a **better algoritm** from scratch. 
    - Starting from the 6-letter words first, and seeing if a match can be found like that. Great execution time ( < 1 second ) but not suuuper readable yet. Especially after ChatGPT improvements.
- Third I started with a **TDD** approach with a friend, making small, incremental improvements along the way.
    - Arguably the most on-point response to what this exercise was designed to probe

The assignment can be found below.

----

# Technical Developer test

In this developer test case, you're going to implement an algorithmn. The objective is to test your skills as a developer.

Technologies that should be used:

- .NET
- C#

Your code will be evaluated using the following criteria:

- Correctness of the algorithm
- Performance
- Clean code
- Seperation of concerns

The way the code needs to be run, is not important. This can be as simple as a console app.

Be mindful of changing requirements like a different maximum combination length, or a different source of the input data. Don't spend too much time on this exercise. 

Feel free to send us a mail if you have any questions about the exercise.

## Submitting the exercise

The assignment can be submitted by sending us your solution through e-mail: 

- Briefly write down where you would improve the code if you were given more time.
- The solution may be sent as a link to your repository, as a zip file in the mail, or uploaded to a file hosting service (eg: wetransfer).

## 6 letter words

There's a file in the root of the repository, input.txt, that contains words of varying lengths (1 to 6 characters).

Your objective is to show all combinations of those words that:

- Together form a word of 6 characters.
- That combination must also be present in input.txt.

You can start by only supporting combinations of two words and improve the algorithm at the end of the exercise to support any combinations.


### Example

When the program is run with this input:
```
foobar
fo
o
bar
```

Then the program should ouput:
```
fo+o+bar=foobar
foo+bar=foobar


```
