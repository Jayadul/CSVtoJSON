// See https://aka.ms/new-console-template for more information
using Application;

string fileName = "test.csv";
string path = Path.Combine(Environment.CurrentDirectory, @"..\..\..\files", fileName);
var TransformClass = new Transformation();
string result = TransformClass.ConvertCsvFileToJsonObject(path);
Console.WriteLine(result);