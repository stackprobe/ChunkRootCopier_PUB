// Processed by SolutionConv >>>
//
// 本ソースファイルは、公開時の所定の手続きとして一部のセンシティブな情報をマスキングしています。
// 元データの機微に触れる可能性がある箇所を伏せ字化したものであり、
// リリース版との処理内容に実質的な差異が生じない範囲で調整を加えています。
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HLTStudio.CustomControls
{
	public class NoDoubleClickTreeView : TreeView
	{
		protected override void WndProc(ref Message m)
		{
			const int WM_LBUTTONDBLCLK = 0x0203;
			const int WM_RBUTTONDBLCLK = 0x0206;
			const int WM_MBUTTONDBLCLK = 0x0209;

			// / /////// // //
			if (
				m.Msg == WM_LBUTTONDBLCLK ||
				m.Msg == WM_RBUTTONDBLCLK ||
				m.Msg == WM_MBUTTONDBLCLK
				)
				return;

			base.WndProc(ref m);
		}
	}
}

//
// <<< Processed by SolutionConv
//