using System;
using System.Windows.Forms;

namespace Capturer.Forms
{
	public partial class LongActionDialog : Form
	{
		#region Private constructor

		private LongActionDialog(string title)
		{
			InitializeComponent();
			lblTitle.Text = title;
		}

		#endregion

		#region Private fields

		private bool _canClose = false;
		private Delegate _target;
		private object[] _args;
		private Action _targetInvoke;
		private IAsyncResult _asyncResult;
		private object _targetResult;

		#endregion

		#region Public static methods

		public static object ShowDialog(IWin32Window owner, string title, Delegate target, params object [] args)
		{
			LongActionDialog dialog = new LongActionDialog(title)
			{
				_target = target,
				_args = args
			};
			dialog.ShowDialog();
			return dialog.CompleteAction();
		}

		public static object ShowDialog(IWin32Window owner, string title, Action target)
		{
			Delegate d = new MethodInvoker(target);
			return ShowDialog(owner, title, d, null);
		}

		#endregion

		#region Private methods

		private object CompleteAction()
		{
			_targetInvoke.EndInvoke(_asyncResult);
			return _targetResult;
		}

		private void StartAction()
		{
			_targetInvoke = () => _targetResult = _target.DynamicInvoke(_args);
			_targetInvoke.BeginInvoke(OnActionCompleted, null);
		}

		private void OnActionCompleted(IAsyncResult r)
		{
			BeginInvoke(new AsyncCallback(result =>
				{
					_asyncResult = result;
					_canClose = true;
					Close();
				}), r);
		}

		private void LongTaskFormFormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = !_canClose;
		}

		private void LongActionDialogShown(object sender, EventArgs e)
		{
			StartAction();
		}

		#endregion
	}
}
