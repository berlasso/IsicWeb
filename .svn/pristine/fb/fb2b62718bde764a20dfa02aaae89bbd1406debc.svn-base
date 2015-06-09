using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Capturer.Forms
{
	public partial class LongTaskForm : Form
	{
		#region Private fields

		private readonly DoWorkEventHandler _callback;
		private object _argument;
		private RunWorkerCompletedEventArgs _results;
		private Exception _error;

		#endregion

		#region Private constructor

		private LongTaskForm(string title, DoWorkEventHandler callback)
		{
			InitializeComponent();

			lblTitle.Text = title;
			_callback = callback;
		}

		#endregion

		#region Public methods

		public static RunWorkerCompletedEventArgs RunLongTask(string title, DoWorkEventHandler callback, object arg)
		{
			using (LongTaskForm frmLongTask = new LongTaskForm(title, callback))
			{
				frmLongTask._argument = arg;
				frmLongTask.ShowDialog();
				if (frmLongTask._error != null)
				{
					throw frmLongTask._error;
				}
				return frmLongTask._results;
			}
		}

		private delegate RunWorkerCompletedEventArgs RunLongTaskDel(string title, DoWorkEventHandler callback, object arg, Control ctrl);
		public static RunWorkerCompletedEventArgs RunLongTask(string title, DoWorkEventHandler callback, object arg, Control ctrl)
		{
			if (ctrl.InvokeRequired)
			{
				RunLongTaskDel del = RunLongTask;
				{
					IAsyncResult res = ctrl.BeginInvoke(del, title, callback, arg, ctrl);
					RunWorkerCompletedEventArgs args = (RunWorkerCompletedEventArgs)ctrl.EndInvoke(res);
					if (args.Error != null)
						throw args.Error;
					return args;
				}
			}
			using (LongTaskForm frmLongTask = new LongTaskForm(title, callback))
			{
				frmLongTask._argument = arg;
				frmLongTask.ShowDialog();
				if (frmLongTask._error != null)
				{
					return new RunWorkerCompletedEventArgs(frmLongTask._results, frmLongTask._error, false);

				}
				return frmLongTask._results;
			}
		}

		#endregion

		#region Private form events

		private void LongTaskFormShown(object sender, EventArgs e)
		{
			bwLongTask.RunWorkerAsync(_argument);
		}

		private void BwLongTaskDoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				if (_callback != null)
				{
					_callback(sender, e);
				}
			}
			catch (Exception ex)
			{
				_error = ex;
			}
		}

		private void BwRefresherRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			_results = e;
			Close();
		}

		#endregion
	}
}
