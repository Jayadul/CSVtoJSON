using Application;

var validation = new Validation();
var TransformClass = new Transformation(validation);
string result = TransformClass.Transform();
Console.WriteLine(result);