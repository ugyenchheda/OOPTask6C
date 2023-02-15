using OOPTask6C;
Student student;

//All the student information:
List<Student> students = new List<Student>();
bool moreStudents;
string received;
string sName;

do
{
    Console.Write("Enter student name: ");
    sName = Console.ReadLine();

    //Create a Student object
    student=new Student(Student.ProvideUniqueIdNumber(), sName);
    //Add to your collection:
    students.Add(student);

    Console.Write("Continue to enter student information Y/N?: ");
    received = Console.ReadLine().ToUpper();
    if(received.StartsWith("Y"))
        moreStudents= true;
    else
        moreStudents= false;

} while (moreStudents);

//Situation at the end:
foreach (var item in students)
{
    Console.WriteLine("Id: "+item.Id+", student name: "+
        item.StudentName);
}
