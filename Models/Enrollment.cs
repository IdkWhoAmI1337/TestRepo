using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[PrimaryKey(nameof(CourseId), nameof(StudentId))]
public class Enrollment
{
    [Column("Student_Id")] public int StudentId { get; set; }

    [Column("Course_Id")] public int CourseId { get; set; }

    public DateTime EnrollmentDate { get; set; }

    [ForeignKey(nameof(StudentId))] public virtual Student Student { get; set; } = null!;

    [ForeignKey(nameof(CourseId))] public virtual Course Course { get; set; } = null!;
}