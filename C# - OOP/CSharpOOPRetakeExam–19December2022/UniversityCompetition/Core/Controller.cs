using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Repositories.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        IRepository<ISubject> subjects;
        IRepository<IStudent> students;
        IRepository<IUniversity> universities;
        private int studentId = 1;
        private int subjectId = 1;
        private int universityId = 1;

        public Controller()
        {
            this.subjects = new SubjectRepository();
            this.students = new StudentRepository();
            this.universities= new UniversityRepository();
        }

        public string AddStudent(string firstName, string lastName)
        {
            var exist = this.students.Models.Any(x=>x.FirstName== firstName && x.LastName == lastName); 

            if (exist)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            var studentId = this.students.Models.Count + 1;

            var student = new Student(studentId, firstName, lastName);
            studentId++;
            this.students.AddModel(student);

            var relevantRepositoryType = this.students.GetType().Name;

            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, relevantRepositoryType);
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            ISubject subject = null;

            if (subjectType != "EconomicalSubject" && subjectType != "HumanitySubject" && subjectType != "TechnicalSubject")
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            bool subjectExist = subjects.Models.Any(x=> x.Name == subjectName);

            if (subjectExist)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            //ISubject subject;

            //var subjectId = subjects.Models.Count + 1;

            if (subjectType == nameof(EconomicalSubject))
            {
                subject = new EconomicalSubject(subjectId, subjectName);
            }
            else if(subjectType == nameof(HumanitySubject))
            {
                subject = new HumanitySubject(subjectId, subjectName);
            }
            else if(subjectType == nameof(TechnicalSubject))
            {
                subject = new TechnicalSubject(subjectId, subjectName);
            }

            this.subjects.AddModel(subject);
            subjectId++;

            string relevantRepositoryTypeName = subjects.GetType().Name;

            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, relevantRepositoryTypeName);
         }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            bool exist = this.universities.Models.Any(x => x.Name == universityName);

            if(exist)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            List<int> requiredIds = new List<int>();
            foreach (var subject in subjects.Models)
            {
                if (requiredSubjects.Contains(subject.Name))
                {
                    requiredIds.Add(subject.Id);

                }
            }

            //var universityId = this.universities.Models.Count + 1;

            var university = new University(universityId, universityName, category,capacity, requiredIds);

            this.universities.AddModel(university);
            universityId++;
            var relevantRepositoryTypeName = universities.GetType().Name;

            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, relevantRepositoryTypeName);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] studentFullName = studentName.Split(" ");
            string firstName = studentFullName[0];  
            string lastName = studentFullName[1];

            var student = this.students.FindByName(studentName);
            var university = this.universities.FindByName(universityName);

            if(student == null)
            {
                return string.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }

            if(university == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            foreach(var exam in university.RequiredSubjects)
            {
                if (!student.CoveredExams.Contains(exam))
                {
                    return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
                }
            }

            if(student.University !=null)
            {
                if(student.University.Name == university.Name)
                {
                    return string.Format(OutputMessages.StudentAlreadyJoined, student.FirstName, student.LastName, university.Name);
                }
            }

            student.JoinUniversity(university);

            return string.Format(OutputMessages.StudentSuccessfullyJoined, student.FirstName, student.LastName, university.Name);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            var student = this.students.FindById(studentId);

            if(student == null)
            {
                return string.Format(OutputMessages.InvalidStudentId);
            }

            var subject = this.subjects.FindById(subjectId);    

            if(subject == null)
            {
                return string.Format(OutputMessages.InvalidSubjectId);
            }

            if(student.CoveredExams.Contains(subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);

            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string UniversityReport(int universityId)
        {
            var university = this.universities.FindById(universityId);

            List<IStudent> universityStudents = new List<IStudent>();
            StringBuilder sb = new StringBuilder();
            foreach (var student in students.Models)
            {
                if (student.University != null)
                {
                    if (student.University.Id == universityId)
                    {
                        universityStudents.Add(student);
                    }

                }
            }
                //StringBuilder sb = new StringBuilder();

                sb.AppendLine($"*** {university.Name} ***");
                sb.AppendLine($"Profile: {university.Category}");
                sb.AppendLine($"Students admitted: {universityStudents.Count}");
                sb.AppendLine($"University vacancy: {university.Capacity - universityStudents.Count}");
                

            
                return sb.ToString().TrimEnd();
        }
    }
}
