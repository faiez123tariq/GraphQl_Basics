namespace GraphQl.Schema
{

    public enum subject
    {
        math,
        english,
        science
    }


    public class CourseType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<StudentType> Students { get; set; }

        [GraphQLNonNullType]
        public InstructorType Instructor { get; set; }
        public subject Subject { get; set; }
    }
}
