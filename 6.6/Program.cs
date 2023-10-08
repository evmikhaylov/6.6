using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._6
{
	internal class Program
	{
		static void WriteWorker()
		{
			int IdWork = System.IO.File.ReadAllLines("ListWork.txt").Length + 1;
			Console.WriteLine();
			Console.Clear();


			using (StreamWriter WriteTxt = new StreamWriter("ListWork.txt", true))
			{

				Console.WriteLine("Введите ФИО сотрудника");
				string FullName = Console.ReadLine();

				Console.WriteLine("Введите возраст");
				ushort AgeWork = Convert.ToUInt16(Console.ReadLine());

				Console.WriteLine("Введите рост");
				byte HeightWork = Convert.ToByte(Console.ReadLine());

				Console.WriteLine("Введите дату рождения");
				DateTime BirthDay = Convert.ToDateTime(Console.ReadLine());

				Console.WriteLine("Введите место рождения");
				string PlaceBirth = Console.ReadLine();

				WriteTxt.WriteLine($"{IdWork}#{DateTime.Now.ToString("g")}#{FullName}#{AgeWork}#{HeightWork}#{BirthDay.ToShortDateString()}#{PlaceBirth}");
				WriteTxt.Flush();
			}
		}

		static void ReadWorker()
		{
			using (StreamReader ReadWriteTxt = new StreamReader("ListWork.txt", false))
			{
                Console.WriteLine();
				Console.Clear();
                string[] Lines = File.ReadAllLines("ListWork.txt");
				StringBuilder sb = new StringBuilder();
				foreach (string Line in Lines)
				{
					sb.Insert(0, Line);
					sb.Replace('#', ' ');
                    Console.WriteLine(sb);
					sb.Clear();	
                }     
			}
		}
		static void Main(string[] args)
		{
			using (FileStream FStream = new FileStream("ListWork.txt", FileMode.Append))
			FStream.Close();

			bool ExitProg = true;
			while (ExitProg)
			{
				Console.WriteLine("Нажмите 1 для вывода данных на экран\nНажмите 2 для ввода нового сотрудника\nНажмите 3 для выхода");
				switch (Console.ReadKey().Key)
				{
					case ConsoleKey.D1:
						{
							ReadWorker();
							continue;
						}
					case ConsoleKey.D2:
						{
							WriteWorker();
							continue;
						}
					case ConsoleKey.D3:
						{
							ExitProg = false;
							break;
						}
				}
			}
		}
	}
}
