# WindowsFormsCalculator

I created this State-Diagram in order to setup the logic.

![stateDiagramCalculator](https://user-images.githubusercontent.com/29587190/141698753-8b694c20-c169-4da9-9de0-c58ac0a64e45.PNG)





The only thing I needed was to distingish between NUMBER-, OPERATOR- and EQUAL-button. For those button types I set up cases according to the diagram.
For example:

NumberButtonPressed -> Which State? -> WaitingForSecondNumber -> SaveNumber in variable2

NumberButtonPressed -> Which State? ->  WaitingForFirstNumber -> SaveNumber in variable1



![Calculator](https://user-images.githubusercontent.com/29587190/141697909-0cb36415-3928-4f7b-b94c-1c9dd5196e79.PNG)



Features:

Chaining Operations

Continue Calculation after Equals (by pressing next Operand) or start fresh (by Pressing Digit)

Autocalc by repeatedly pressing Equals.
