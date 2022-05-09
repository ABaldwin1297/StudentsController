using StudentsController;


var studctr1 = new StudentController("localhost\\sqlexpress", "EdDb");
studctr1.OpenConnection();

var student = new Student() {
    Firstname = "Andy", Lastname = "Baldwin", StateCode = "OH", GPA = 3.0m,
    SAT = 1200, MajorId = 1
};

//var rc = studctr1.AddStudent(student);

//var rc = studctr1.ChangeStudent(student);

student.Id = 1062;
var rc = studctr1.ChangeStudent(student);

studctr1.CloseConnection();