using CodeAlong.Array;
using CodeAlong.Enum;
using CodeAlong.ModelClass;
using CodeAlong.TestFolder;
using System.Reflection;

#region test region
ArrayExamples arrayExamples = new ArrayExamples();
    arrayExamples.SetJaggedArray();

        Køretøj<double> bil = new("Audi", "A6", 3.5, "Niels","Olesen","4´34343434");

#endregion neat!

//var minibiltype = bil.GetType().GetCustomAttributes().OfType<Ulovlig>().FirstOrDefault;
//Console.WriteLine($"Bil Ulovlig bil info: {minibiltype.mærke} {minibiltype.Model}");
#region writing teacher 
Teacher teacher = new() { Firstname = "Niels", Lastname = "Olesen" };
    Console.WriteLine(teacher.Lastname);
#endregion ending of teacher
