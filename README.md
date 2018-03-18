# listify

Listify is a simple Web API written targeting .Net Core 2.0. It exposes a single method at `/api/listify` that accepts three query string parameters: `start`,`end`, and `index` (e.g. www.<app-url>.com/api/listify?start=100&end=200&index=50 should return 150). The first two parameters specify the start and end of a sequence of numbers that Listify generates internally. It uses the class `JustInTimeList` to return an `IEnumerable<int>` that provides access to any item in the range at the time of the call. 

Ex. 
```cs
var list = JustInTimeList(100,200);
var item = list[50]; //50
```

The api also accepts negative index requests in the Python style, with the `list[-1]` being the last item in the list and the maximum absolute value of the negative index being equal to the number of elements in the list. 

Ex. 
```cs
var list = JustInTimeList(100,200);
var item = list[-1]; //200
var item2 = list[-101] //100
var item3 = list[-102] //IndexOutOfRangeException

```
