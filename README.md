# Pizza Exercise

High level components:
1. Ingest json file has two function: 
	a) load Json file from the web. 
	b) parse json file to iTopping array
2. Calculation Engine finds n top topping. I used dictionary to load and count same toppings. After dictionary has all toppings and total, I sort and get the top 20
3. Program - Main: run the program and print out results


=======================================

Code was developed in Visual Studio 2015, .net 4.6.1
Pizza topping is a console application you can run it in two ways:
1.	In visual studio, after loading the project press F5
2.	Build the project, then go to PizzaTopping\bin\Debug\PizzaTopping.exe and run it
Project has only unit tests for Calc Engine
