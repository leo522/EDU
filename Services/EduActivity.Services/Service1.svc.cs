using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace KMU.EduActivity.Services
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	[ErrorHandlers.ApplicationErrorHandlerAttribute()] // manage all unhandled exceptions
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	public class Service1 : IService1
	{
		#region IDisposable Members

		/// <summary>
		/// <see cref="M:System.IDisposable.Dispose"/>
		/// </summary>
		public void Dispose()
		{
			//dispose all resources
		}

		#endregion

		#region IService1 Members

		public string GetData(int value)
		{
			if (value == -1)
			{
				throw ErrorHandlers.ApplicationServiceError.Create(new ArgumentException("Houston we have a problem"));
			}
			return string.Format("You entered: {0}", value);
		}

		#endregion
	}
}