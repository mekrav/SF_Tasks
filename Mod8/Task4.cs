using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Mod8
{
    // Описываем наш класс и помечаем его атрибутом для последующей сериализации   
    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Student(string name, string group, DateTime dateOfBirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateOfBirth;
        }
        public override string ToString()
        {
            return Name + ", " + DateOfBirth.ToString();
        }
    }

    class Task4
    {
        public static void Run()
        {
            string DesktopPath = @"C:\\Users\\mibot.ru\\Desktop";
            string DataFile = CreateFile(10);
            Student[] StudentsList = ExtractData(DataFile);
            try { SortStudents(DesktopPath, StudentsList); }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e}");
            }
            Console.ReadLine();
        }

        //Возникли проблемы с предоставленным бинарником,
        //в чате с менторами нашла старый вопрос по той же теме, где сказано что можно сделать это задания со своими исходными данными.
        //метод нужен ровно для того что бы заполнить бинарный файл
        static string CreateFile(int count) //По-хорошему нужно разбить на 2 метода, но это не суть задания, поэтому оставляю так
        {
            var Names = new string[] { "Иван", "Пётр", "Алексеё", "Ирина", "Мария", "Татьяна" };
            var Groups = new string[] { "22-1", "22-2", "22-3", "22-4", "22-4b" };

            Random rand = new Random();
            var Students = new Student[count];
            for (int i = 0; i < count; i++)
            {
                Students[i] = new Student(Names[rand.Next(Names.Length)], Groups[rand.Next(Groups.Length)], DateTime.Now);
            }

            BinaryFormatter formatter = new BinaryFormatter();
            string fileName = "myStudents.dat";
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Students);
            }
            return fileName;
        }

        static Student[] ExtractData(string FileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Student[] StudentsList;
            using (var fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                StudentsList = (Student[])formatter.Deserialize(fs);
            }
            return StudentsList;
        }

        static void SortStudents(string RootFolder, Student[] ListOfStudents)
        {
            if (Directory.Exists(RootFolder))
            {
                DirectoryInfo StudentsDir = new DirectoryInfo(RootFolder + @"\\Students");
                if (!StudentsDir.Exists)
                    StudentsDir.Create();
                foreach (Student student in ListOfStudents)
                {
                    string GroupFilePath = StudentsDir + @"\\" + student.Group + ".txt";
                    FileInfo GroupFile = new FileInfo(GroupFilePath);
                    using (StreamWriter sw = GroupFile.AppendText()) //Файлы создаются автоматически
                    {
                        sw.WriteLine(student.ToString());
                    }
                }
            }
            else throw new Exception($"Не корректный путь, папка не найдена или нет доступа.");
        }
    }
}
