using System;
using System.Threading;
using Neurotec.Cluster;

namespace Capturer
{
	class ClusterClient
	{
		#region Private fields

		private static ClusterClient _instance;
		private int _port;
		private string _address;

		#endregion

		#region Private constructor

		private ClusterClient()
		{
		}

		#endregion

		#region Public properties

		public static ClusterClient Instance
		{
			get
			{
				if (_instance == null) _instance = new ClusterClient();
				return _instance;
			}
		}

		public int AdminPort
		{
			get { return _port; }
			set { _port = value; }
		}

		public string Address
		{
			get { return _address; }
			set { _address = value; }
		}

		#endregion

		#region Public methods

		public bool CheckConnection()
		{
			return CheckConnection(Address, AdminPort);
		}

		public bool CheckConnection(string address, int port)
		{
			AdminPacket packet = null;
			AdminPacketReceived received = null;

			try
			{
				packet = AdminPacket.CreatePacket_NodesInfoRequest();
				received = SendReceivePacket(address, port, packet);
				if (received != null)
				{
					NodeInfo[] info;
					ClusterStatusCode res = received.GetNodesInfo(out info);
					if (res == ClusterStatusCode.OK)
					{
						return true;
					}
				}
			}
			catch
			{
				return false;
			}
			finally
			{
				if (received != null)
				{
					received.DestroyPacket();
					received = null;
				}

				if (packet != null)
				{
					packet.DestroyPacket();
					packet = null;
				}
			}

			return false;
		}

		public void EnrollTemplate(int keyIndex, object[] values)
		{
			AdminPacket insertQueryPacket = null;
			AdminPacketReceived insertIdPacket = null;

			try
			{
				insertQueryPacket = AdminPacket.CreatePacket_InsertTemplates(keyIndex, new object[][] { values });
				insertIdPacket = SendReceivePacket(Address, AdminPort, insertQueryPacket);
				int taskId;
				ClusterStatusCode res = insertIdPacket.GetInsertTaskId(out taskId);
				CheckClusterStatusCode(res);

				ClusterInsertDeleteResult result;
				do
				{
					AdminPacket insertResultReq = null;
					AdminPacketReceived insertResultReqReceived = null;

					try
					{
						insertResultReq = AdminPacket.CreatePacket_InsertRequest(taskId);
						insertResultReqReceived = SendReceivePacket(Address, AdminPort, insertResultReq);

						res = insertResultReqReceived.GetInsertTaskResult(out result);
						CheckClusterStatusCode(res);
						switch (result)
						{
							case ClusterInsertDeleteResult.ServerNotReady:
								throw new Exception(string.Format("Failed to complete insert task as server is not yet ready"));
							case ClusterInsertDeleteResult.Waiting:
								Thread.Sleep(100);
								break;

							case ClusterInsertDeleteResult.Failed:
								string error;
								insertResultReqReceived.GetInsertTaskError(0, out error);
								if (error == string.Empty)
									error = "N / A";
								throw new Exception(string.Format("Failed to complete insert task. Reason: {0}", error));
							case ClusterInsertDeleteResult.Succeeded:
								break;
							default:
								throw new Exception(string.Format("Error! Unknow status: {0}", result));
						}
					}
					finally
					{
						if (insertResultReqReceived != null)
						{
							insertResultReqReceived.DestroyPacket();
							insertResultReqReceived = null;
						}

						if (insertResultReq != null)
						{
							insertResultReq.DestroyPacket();
							insertResultReq = null;
						}
					}
				} while (result == ClusterInsertDeleteResult.Waiting);
			}
			finally
			{
				if (insertIdPacket != null)
				{
					insertIdPacket.DestroyPacket();
					insertIdPacket = null;
				}
				if (insertQueryPacket != null)
				{
					insertQueryPacket.DestroyPacket();
					insertQueryPacket = null;
				}
			}
		}

		#endregion

		#region Private methods

		private AdminPacketReceived SendReceivePacket(string address, int port, AdminPacket packet)
		{
			Communication comm = null;

			try
			{
				comm = new Communication(address, port);
				AdminPacketReceived receivedPacket;
				ClusterStatusCode communicationResult = comm.SendReceivePacket(packet, out receivedPacket);
				CheckClusterStatusCode(communicationResult);
				if (receivedPacket == null)
				{
					throw new Exception("Failed to receive result from server.");
				}
				return receivedPacket;
			}
			finally
			{
				if (comm != null) comm.Close();
			}
		}

		private void CheckClusterStatusCode(ClusterStatusCode clusterStatusCode)
		{
			if (clusterStatusCode != ClusterStatusCode.OK)
			{
				throw new Exception("Cluster error: " + clusterStatusCode.ToString());
			}
		}

		#endregion
	}
}
