using StudentsController;


const string server = "localhost\\sqlexpress";
const string database = "EdDb";

var studctr1 = new StudentController(server, database);
studctr1.OpenConnection();

var majctr1 = new MajorController(server, database);
majctr1.OpenConnection();

var majors = majctr1.GetAllMajors();
var students = studctr1.GetAllStudents();

var studentsMajors = from s in students
                     join m in majors
                     on s.MajorId equals m.Id
                     where s.StateCode == "OH"
                     orderby s.Lastname descending
                     select new {
                         Fullname = s.Firstname + " " + s.Lastname,
                         Major = m.Description
                     };

foreach(var sm in studentsMajors) {
    Console.WriteLine(sm);
}


//var student = studctr1.GetStudentByPK(6);
//Console.WriteLine(student);

//var students = studctr1.GetAllStudents();




//var studentsFromOhio = students.Where(s => s.StateCode == "OH");


//var studentWithHighestSAT = (from s in students where s.SAT >= 0 && s.StateCode == "OH"
//                       orderby s.SAT descending
//                       select s).FirstOrDefault();

//var FirstLastMajor = from s in students 
//                     orderby s.Major.Description
//                     select new {
//    s.Firstname, s.Lastname, Major = s.Major.Description
//};



//var studentsFromOhio = from s in students where s.SAT >= 0 && s.StateCode == "OH"
//           orderby s.Lastname
//           select s;


//foreach (var s in FirstLastMajor) {
//    Console.WriteLine($"{s.Firstname} {s.Lastname}, Major = {s.Major}");
//}


//var student = new Student() {
//    Firstname = "Andy", Lastname = "Baldwin", StateCode = "OH", GPA = 3.0m,
//    SAT = 1200, MajorId = 1
//};

//var rc = studctr1.AddStudent(student);

//var rc = studctr1.ChangeStudent(student);

//student.Id = 1061;
//var del = studctr1.DeleteStudent(student.Id);


studctr1.CloseConnection();

