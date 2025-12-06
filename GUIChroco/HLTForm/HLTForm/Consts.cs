// Processed by SolutionConv >>>
//
// 本ソースファイルは、公開時の所定の手続きとして一部のセンシティブな情報をマスキングしています。
// 元データの機微に触れる可能性がある箇所を伏せ字化したものであり、
// リリース版との処理内容に実質的な差異が生じない範囲で調整を加えています。
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using HLTStudio.Commons;

namespace HLTStudio
{
	public static class Consts
	{
		public static string SettingsFile => ProcMain.SelfFile + ".settings.dat";

		public static string ChrocoExeFile
		{
			get
			{
				string file = Path.Combine(ProcMain.SelfDir, @"..\Chroco\Chroco.exe"); // /////

				if (!File.Exists(file))
				{
					file = Path.Combine(ProcMain.SelfDir, @"..\..\..\..\..\Chroco\HLTConsole\HLTConsole\bin\Release\HLTConsole.exe"); // ////

					if (!File.Exists(file))
						throw null; // //////////////
				}
				return file;
			}
		}
	}
}

//
// <<< Processed by SolutionConv
//