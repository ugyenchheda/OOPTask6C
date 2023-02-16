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

            //Create a Student object
            student = new Student(Student.ProvideUniqueIdNumber(), sName);
            //Add to your collection:
            students.Add(student);

            Console.Write("Continue to enter student information Y/N?: ");
            received = Console.ReadLine().ToUpper();
            if (received.StartsWith("Y"))
                moreStudents = true;
            else
                moreStudents = false;

        } while (moreStudents);

        //Situation at the end:
        //foreach (var item in students)
        //{
        //    Console.WriteLine("Id: " + item.Id + ", student name: " +
        //        item.StudentName);
        //}
    }
    else if (received.StartsWith("U"))
    {
        Console.WriteLine("You chose to enter user data.");
        do
        {
            Console.Write("Enter student id number: ");
            received = Console.ReadLine();
            while (!Int32.TryParse(received, out sIdNumber) || sIdNumber<1)
            {
                Console.Write("Not accepted, try again: ");
                received = Console.ReadLine();
            }
            //Any students found?
           
            var found=from item in students
                      where item.Id == sIdNumber
                      select item;
            if (found.Any())
            {
                Console.Write("Enter username: ");
                sUserName = Console.ReadLine();
                //All the info now available:
                userName=new UserName(sIdNumber, sUserName);

                //NOW comes the exciting MOMENT OF TRUTH:
                //CAN the information be saved?????
                try
                {
                    userNames.Add(sIdNumber, userName);
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Did not work and here is why:");
                    Console.WriteLine(ex.Message);
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
