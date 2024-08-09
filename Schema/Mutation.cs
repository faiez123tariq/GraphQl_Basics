namespace GraphQl.Schema
{
    public class Mutation
    {

        private readonly List<CourseType> _courses;

        public Mutation(List<CourseType> courses)
        {
            _courses = courses;
        }

        public bool CreateCourse(string name, subject subject, Guid InstructorId)
        {
            CourseType courseType = new CourseType
            {
                Id = Guid.NewGuid(),
                Name = name,
                Subject = subject,
                Instructor = new InstructorType()
                {
                    Id = InstructorId
                }
            };
            _courses.Add(courseType);
            return true;
        }
    }
}
