namespace Kusys.Entities
{
    public class Student : IEntity
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<StudentCourse> StudentCourse { get; set; }

        public int RoleID { get; set; }
        public Role Role { get; set; }

    }
}