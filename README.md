# First part of [Fury Lion Unity Course](https://furylion.net/courses/junior-unity-developer)  
This part is about covering C# basics by completing simple logic tasks and 2 console projects. </br>
All tasks is divided by file structure of this repository.
# Task1
1. 3 numbers entered from keyboard. Write 3 numbers in asc order. (4, 7, 2 → 2, 4, 7)
2. Number entered from keyboard. Write it in reverse order. (358 → 853)
3. Implement method that calculate factorial of a number writed from keyboard.
4. Get sum of first N numbers with M step from X. (X=10 N=5 M=2 → 10+12+14+16+18=70)
5. Implement method that gets X number and returns all even numbers in the range from 0..X. (X=10 → 0, 2, 4, 6, 8, 10)
6. Implement method that gets X number and returns all [perfect numbers](https://en.wikipedia.org/wiki/Perfect_number) in range 0..X. (X=10 → 6)
7. One-dimensional array given, get 2 sums of all elements on even and odd positions.
8. One-dimensional array given, sort negative numbers ([4, -1, 1, -2] → [4, -2, 1, -1])
9. Array given transform it so that last and first elements swapped, then second and last by one swapped and ets.
10. One-dimensional array given, get sum of elements that are: a) greater than the number M, b) less than number N.
11. Two-dimensional array given, swap even and odd strings in it.
12. Two-dimensional array given, get max element for each column
13. Two-dimensional array given, swap elements on positions of main diagonal with the positions of opposite diagonal
14. String given, count symbols 'A' in it
15. String given, count words in it
16. String given, reverse it (computer -> retupmoc)
17. String given, swap all symbols 'С' on 'E'
18. String given, count words that starts with 'К' symbol in it
# Task 2
Implement classes with inheritance: base class "Human", subclasses of it is Student and Employee, subclass of Employee is Driver.  
Classes has fields:  
* Human: subname, name, patronymic, birthdate
* Student: faculty, course, group
* Employee: organisation, salary, work experience
* Driver: auto mark, auto model  
  
Human can't have own instance, only subclasses. Driver is sealed.  
For classes implement parameterless constructor, constructor with parameters, copy constructor, destructor. Debug messages for constructor/destructor invocations.  
In classes body define methods that allows user to:
1. Edit params content.
2. Present class information in comfort format.
3. Possibility to get number of full years.
  
Functionality of app allows:
1. Add info about new Human.
2. Edit info of existing record.
3. Delete info about human.
4. Write info about human in comfort format.
5. Write info about all humans in comfort format.
# Task 3
Weather Forecast  
Requirements:
1. Possibility for get current weather for definite city.
2. Possibility for get weather forecast for 5 days for definite city. (enum)
3. Choosing city from pre-prepared city list (5 at least)
4. Possibility for get weather for city, that not in the enum. (keyboard input)
5. Information about weather should be presented in the most beautiful format.
  
For realization use [OpenWeatherMap](https://openweathermap.org/) Rest API.  
For getting results from service you need to use asynchronous way for communicate through await/async or delegates.  
Requirements for task completion:  
1. Handle try/catch exceptions.
2. Handle OpenWeatherMap service HTTP status codes.
3. Follow code style agreements.