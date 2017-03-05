using FormAssitControl.Model.Entities;
using FormAssitControl.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAssitControl.Model.Services
{
    public class StudentDirectoryService
    {
        public static StudentDirectory LoadStudentDirectory()
        {
            DataBaseManager dbManager = new DataBaseManager();
            ObservableCollection<Student> students = new ObservableCollection<Student>(dbManager.GetAllItem<Student>());
            StudentDirectory studentDirectory = new StudentDirectory();
            //Verificando se existe algum aluno salvo no banco
            if (students.Any())
            {
                //Se tiver retono a lista dos alunos salvos
                studentDirectory.Students = students;
                return studentDirectory;

            }

            //se não tiver alunos salvos crio um lista vazia, salvo um grupo de alunos aleatórios
            students = new ObservableCollection<Student>();

            string[] names = {"José Luis", "Miguel Ángel", "José Francisco", "Jesús Antonio",
                                "Sofía", "Camila", "Valentina", "Isabella", "Ximena" };

            string[] lastNames = { "Hernández", "García", "Martínez", "López", "González" };

            Random rdn = new Random(DateTime.Now.Millisecond);

            students = new ObservableCollection<Student>();

            for (int i = 0; i < 20; i++)
            {
                Student student = new Student();
                student.Name = names[rdn.Next(0,8)];
                student.LastName = $"{lastNames[rdn.Next(0, 5)]} {lastNames[rdn.Next(0, 5)]}";
                string group = rdn.Next(456, 458).ToString();
                student.Group = group;
                student.StudentNumber = rdn.Next(12384748, 32384748).ToString();
                student.Average = rdn.Next(100, 1000) / 10;
                student.Key = student.StudentNumber;
                students.Add(student);
                //e salvo no banco pela primeira vez
                dbManager.SaveValue<Student>(student);
            }

            studentDirectory.Students = students;
            return studentDirectory;
        }
    }
}
