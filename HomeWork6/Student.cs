using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Максим Торопов
/// Ярославль
/// Домашняя работа 6 урока
/// </summary>
namespace HomeWork6
{
    /// <summary>
    /// Класс Студент
    /// 
    /// Класс для 3 задания
    /// </summary>
    class Student
    {
        /// <summary>
        /// Имя
        /// </summary>
        string firstName;

        /// <summary>
        /// Фамилия
        /// </summary>
        string lastName;

        /// <summary>
        /// Университет
        /// </summary>
        string univercity;

        /// <summary>
        /// Факультет
        /// </summary>
        string faculty;

        /// <summary>
        /// Отдел
        /// </summary>
        string department;

        /// <summary>
        /// Возраст
        /// </summary>
        int age;

        /// <summary>
        /// Курс
        /// </summary>
        int course;

        /// <summary>
        /// Группа
        /// </summary>
        public int group;

        /// <summary>
        /// Город
        /// </summary>
        public string city;

        /// <summary>
        /// Свойство возвращает Имя
        /// </summary>
        public string GetFirstName
        {
            get { return firstName; }
        }

        /// <summary>
        /// Свойство возвращает Фамилию
        /// </summary>
        public string GetLastName
        {
            get { return lastName; }
        }

        /// <summary>
        /// Свойство возвращает Университет
        /// </summary>
        public string GetUnivercity
        {
            get { return univercity; }
        }

        /// <summary>
        /// Свойство возвращает Факультет
        /// </summary>
        public string GetFaculty
        {
            get { return faculty; }
        }

        /// <summary>
        /// Свойство возвращает Отдел
        /// </summary>
        public string GetDepartment
        {
            get { return department; }
        }

        /// <summary>
        /// Свойство возвращает Возраст
        /// </summary>
        public int GetAge
        {
            get { return age; }
        }

        /// <summary>
        /// Свойство возвращает Курс
        /// </summary>
        public int GetCourse
        {
            get { return course; }
        }

        /// <summary>
        /// Свойство возвращает Группу
        /// </summary>
        public int GetGroup
        {
            get { return group; }
        }

        /// <summary>
        /// Свойство возвращает Город
        /// </summary>
        public string GetCity
        {
            get { return city; }
        }

        /// <summary>
        /// Create Student record
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="univercity">Университет</param>
        /// <param name="faculty">Факультет</param>
        /// <param name="department">Отдел</param>
        /// <param name="age">Возраст</param>
        /// <param name="course">Курс</param>
        /// <param name="group">Группа</param>
        /// <param name="city">Город</param>
        public Student(string firstName, string lastName, string univercity, string faculty, string department, int age, int course, int group, string city)
        {
            this.firstName = firstName;
            this.lastName = lastName;            
            this.univercity = univercity;
            this.faculty = faculty;
            this.department = department;
            this.age = age;
            this.course = course;
            this.group = group;
            this.city = city;
        }

        /// <summary>
        /// Перегружаем ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format($"{firstName,25}{lastName,25}{age,3}{course,2}{group,2}{city,15}");
        }

        /// <summary>
        /// Method Fr array to String
        /// </summary>
        /// <param name="ar">array</param>
        /// <param name="message1">message before number of element in array</param>
        /// <param name="message2">message before value of element in array</param>
        /// <returns></returns>
        public static string FrequencyArrayToString(ref int[] ar, string message1, string message2)
        {
            string str = String.Empty;
            for (int i = 0; i < ar.Length; i++) str = $"{str} {message1}:{i+1} {message2}:{ar[i]}\n";
            return str;
        }
    }
}
