using Application;
using Application.services;

var validation = new Validation();
var home = new Home(validation);
string result = home.Convert();
Console.WriteLine(result);