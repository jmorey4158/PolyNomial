# PolyNomial
This project will have several methods that take a polynomial equation (string) and the values of the variables (decimal[]) and calculate the sum of the polynomial. 

#Purpose
This Project was created as my attempt to complete some famous coding problems. 
##StrictPolynomial()
This method requires that the input equation follow these restrictions:
1. Only two valuables x and y
2. Only integer exponents
3. Only integer coefficient
4. Only term operator is '+'
The equation can has N number terms.

#Patterns
##PAPA Pattern
I used what I call the 'PAPA' pattern to tackle this problem. 'PAPA' stands for 'Parse', 'Assign', 'Process' and 'Aggregate'.

###Parse
Given that almost every programming problem (like creating code that calculates the sum of a polynomial) is really made up of a set of smaller, more easily-solved problems. And those sub-problems might be comprised of smaller problems, until the individual problems are easily solved. Thus parsing through the main problem can easily show one the smaller, more easily-solved problems. Even the gangliest problem can be broken down into bite-sized chucks.

###Assign
After having broken the main problem into chucks, assign each chunk to a helper method. These helpers serve the mail method to process each of the smaller chucks. Another advantage of this is that one can easily create Unit Tests for each of these chucks and test each in a logic fashion. 
###Process
Next, one codes each helper method until the unit tests pass. The pattern that I found works well is the “Inside-Out” Pattern (see below). Once all the chucks are done and all the unit tests pass, it time to finish up.

###Aggregate
The last thing to do is to create the code to aggregate the sub-answers into the main answer. One creates code that calls all the helper methods and passes the final solution to the consumer.  
##The Inside-Out Pattern

##5F Pattern
The 5F Pattern is an over-arching philosophy, or guiding principle for developing long-term, end-to-end projects that helps one to guarantee quality and effectiveness. 
The 5F’s stand for ‘Functional’, ‘Faithful’, ‘Friendly’, ‘Fast’, and ‘Future’

###Functional
This speaks for itself – make it work. That is the first goal of coding is to make the thing work. Unit tests pass and we get reliable values out of the code.

But this also means that it does what we designed it to do and nothing more. The “nothing more” part saves us developers from our own propensity to just keep coding because we just thought up some really cool feature. Been there done that. Have the T-Shirts. 
This helps us stick to our Agile goals and ship the needed code on time and at quality. There is always going to be another release in which we can put those cool features.

###Faithful
What I really wanted to say was Consistent or Resilient, but those words don’t start with “F”. After we have the code delivering what it should deliver (and nothing more), then we shift to making sure it is tough as nails but mercilessly beating on it (or have our friendly neighborhood tests do that – they are awesome at it). 

This ensures that we have covered corner cases and bad inputs. That we have made sure that it won’t eat up too many resources. That it always pops out the correct outputs. That it has all the try-catch blocks it needs. That it works and plays well with others.
We want to make sure we don’t have any naughty code. 

###Friendly
Friendly to the developers, to the testers, to the consumers. I know that this is a balancing act but we need to do it (after it works and is not naughty). This is usually a cyclical process done in our “spare time”. But we shouldn’t put it off like that. 
Everyone like to use friendly code. Everyone like to test friendly code. Everyone like to review friendly code. But not everyone like to write friendly code. But we can learn. We can learn.

Remember the first time you were asked to write thread-safe code and your reaction was “Huh?” But now you can write thread-safe code in your sleep. You learned that through determination, lots of research, and maybe buying a few beers for that guy in the next office who really knows thread-safe code. (BTW – I am awesome at Friendly Code and I like Angry Orchard Hard Cider. Just sayin’).
Friendly means that there are plenty of comments (and not just // comments but /// comments, right?). And those comments should make sense to someone who has never seen your code. Nobody like to read comments like, “// grep dirty calcs and heft to outter int by shift-shift”.

Friendly means that you always use unit tests for each and every method. (Confession – This project represents the very first time I have ever used Test-Driven Development – I Know, I know, bad dog, no biscuit – but I am now a true believer. My unit tests found crap code that I would never have seen otherwise. ) There is just something “safe” about seeming all those green checks in VS to let you know you’re a success. It also makes the SDETs’ job way easier. And if you’re in DevOps, you probably don’t have a choice – unit test or use the customers as your testers (not a good idea). 

And friendly code also means that you use a naming convention. It really make code much more readable. 

###Fast
OK, now, after we have endured all of the niceness above, it’s time to do what we all want to do – make our code faster.


