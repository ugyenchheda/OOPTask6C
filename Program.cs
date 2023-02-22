using OOPTask6C;
Student student;
UserName userName;

//All the student information:
List<Student> students = new List<Student>();
//All the username information here:
Dictionary<int, UserName> userNames = new Dictionary<int, UserName>();
bool moreStudents;
bool moreUserNames;
bool continueWorking;
string received;
string sName;
string sAddress;
string sUserName;
int sIdNumber;
do
{
    Console.Write("Entering student info or username info S/U?: ");
    received = Console.ReadLine().ToUpper();
    if (received.StartsWith("S"))
    {
        do
        {
            Console.WriteLine("You chose to enter student information");
            Console.Write("Enter student name: ");
            sName = Console.ReadLine();
            Console.WriteLine("If the student's address " +
                "is not yet known, press ENTER");
            Console.Write("Enter student address: ");
            sAddress = Console.ReadLine();
            if(String.IsNullOrEmpty(sAddress))
                sAddress = null;       
            
            
            //Create a Student object
            student = new Student(Student.ProvideUniqueIdNumber(), 
                sName, sAddress);
            //Add to your collection:
            students.Add(student);

            Console.Write("Continue to enter student information Y/N?: ");
            received = Console.ReadLine().ToUpper();
            if (received.StartsWith("Y"))
                moreStudents = true;
            else
                moreStudents = false;

        } while (moreStudents);        
    }
    else if (received.StartsWith("U"))
    {
        Console.WriteLine("You chose to enter user data.");
        do
        {
            Console.Write("Enter student name: ");
            sName = Console.ReadLine();
            
            //Any students found?           
            var found=from item in students
                      where item.StudentName.Contains(sName)
                      select item;

            int numberOfStudents=students.Count();

            if (found.Any())
            {
                for (int i = 0; i < numberOfStudents; i++)
                {
                    if(students[i].StudentName.Contains(sName))
                    {
                        Console.WriteLine("There is student {0}.", students[i].StudentName);
                        Console.Write("Would you like to enter user data to " +
                            "the above student (Y/N)?: ");
                        received = Console.ReadLine().ToUpper();
                        if(received.StartsWith("Y"))
                        {
                            Console.Write("Enter username: ");
                            sUserName = Console.ReadLine();
                            userName=new UserName(students[i].Id, sUserName);

                            //CAN the information be saved?????
                            try
                            {
                                userNames.Add(students[i].Id, userName);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Did not work and here is why:");
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                }              
            }
            else
            {
                Console.WriteLine("Before entering user data, " +
                    "the student's data must be stored");
                Console.WriteLine("The student's information has " +
                    "not been saved yet.");
            }

            Console.Write("Continue to enter user information Y/N?: ");
            received = Console.ReadLine().ToUpper();
            if (received.StartsWith("Y"))
                moreUserNames = true;
            else
                moreUserNames = false;

        } while (moreUserNames);
    }
    else
        Console.WriteLine("This option is not available here.");

    Console.Write("Keep on working Y/N?: ");
    received = Console.ReadLine().ToUpper();
    if(received.StartsWith("Y"))
        continueWorking=true;
    else
        continueWorking=false;


} while (continueWorking);

Console.WriteLine("Student collection:");
foreach (var item in students)
{
    //Console.WriteLine("Id: " + item.Id + ", student name: " +
    //    item.StudentName);
    Console.WriteLine(item);
}

Console.WriteLine("UserName collection:");
foreach (var item in userNames)
{
    //Console.WriteLine("Student Id: {0}, username: {1}",
    //    item.Value.StudentId, item.Value.Username);
    Console.WriteLine(item);
}


