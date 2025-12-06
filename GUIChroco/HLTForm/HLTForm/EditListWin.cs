// Processed by SolutionConv >>>
//
// 本ソースファイルは、公開時の所定の手続きとして一部のセンシティブな情報をマスキングしています。
// 元データの機微に触れる可能性がある箇所を伏せ字化したものであり、
// リリース版との処理内容に実質的な差異が生じない範囲で調整を加えています。
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HLTStudio.Commons;

namespace HLTStudio
{
	public partial class EditListWin : Form
	{
		public string RootDir;
		public string[] TargetRelPaths;
		public bool ValueChanged = false;

		// //// //////

		private EditListWin_MainSheetModel MainSheetModel;

		public EditListWin()
		{
			InitializeComponent();
		}

		private void EditListWin_Load(object sender, EventArgs e)
		{
			this.MinimumSize = this.Size;
		}

		private void EditListWin_Shown(object sender, EventArgs e)
		{
			// ///// /////////////////////////////////////////////////////////////
			//
			new Thread(() =>
			{
				Thread.Sleep(500);

				this.BeginInvoke((MethodInvoker)delegate
				{
					Shown_Delay();
				});
			})
			.Start();
		}

		private void Shown_Delay()
		{
			this.MainSheetModel = new EditListWin_MainSheetModel(this.MainSheet, this.MainSheetMenu);
			this.MainSheetModel.SetRelPaths(
				Directory.GetFiles(this.RootDir, "*", SearchOption.AllDirectories)
					.Select(file => SCommon.EraseRoot(file, this.RootDir))
					.OrderBy(SCommon.CompIgnoreCase)
					.ToArray(),
				this.TargetRelPaths
				);
		}

		private void EditListWin_Click(object sender, EventArgs e)
		{
			this.MainSheet.ClearSelection();
		}

		private void MainSheetMenu_選択されている行を対象にする_Click(object sender, EventArgs e)
		{
			this.MainSheetModel.選択されている行アクション(row =>
			{
				row.対象 = true;
			});
		}

		private void MainSheetMenu_選択されている行を対象から外す_Click(object sender, EventArgs e)
		{
			this.MainSheetModel.選択されている行アクション(row =>
			{
				row.対象 = false;
			});
		}

		private void Btn検索_Click(object sender, EventArgs e)
		{
			using (SearchCondDlg f = new SearchCondDlg())
			{
				f.ShowDialog();

				if (f.ExecuteFlag)
				{
					string searchWord = f.SearchWord;
					SearchCondDlg.MatchType_e matchType = f.MatchType;

					this.MainSheetModel.Search(searchWord, matchType);
				}
			}
		}

		private void BtnOK_Click(object sender, EventArgs e)
		{
			this.TargetRelPaths = this.MainSheetModel.GetCheckedRelPaths();
			this.ValueChanged = true;
			this.Close();
		}

		private void Btnキャンセル_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void MainSheet_SelectionChanged(object sender, EventArgs e)
		{
			this.RefreshView();
		}

		private void MainSheet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			this.RefreshView();
		}

		private bool RefreshView_Scheduled = false;

		private void RefreshView()
		{
			if (this.RefreshView_Scheduled)
				return;

			this.RefreshView_Scheduled = true;

			this.BeginInvoke((MethodInvoker)delegate
			{
				this.RefreshView_Delay();
			});
		}

		private void RefreshView_Delay()
		{
			this.LblStatus.Text = $@"

選択：{this.MainSheet.SelectedRows.Count} 件
対象：{this.MainSheetModel.Get対象件数()} 件
総数：{this.MainSheet.RowCount} 件

				".Trim();

			this.RefreshView_Scheduled = false;
		}
	}
}

//
// <<< Processed by SolutionConv
//