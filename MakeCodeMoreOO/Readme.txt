Content: Rendering Branching Over Boolean Tests Obsolete

Bad Design: 
- A class which is doing everything itself
-  this typically leads to if-then-else instructions everywhere

Better Design: 
- Move separate implements to separate state class
- Substitute the state object to subsitute implementation

Benefits of the State pattern
- Class that uses states becomes simple
- It can focus on its primary role
- Other roles are delegated to concrete state class
- Each concrete class is simple

