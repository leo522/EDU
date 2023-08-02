using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using KMUH.EduForm.ApplicationLayer.DTO;
using KMUH.EduForm.ApplicationLayer.Services;


namespace KMUH.EduForm.Services
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	[ErrorHandlers.ApplicationErrorHandlerAttribute()] // manage all unhandled exceptions
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Single)]
	public partial class EduFormWCFService : IEduFormWCFService
	{
		private IEduFormAppService service = new EduFormAppService();

		#region IDisposable Members

		/// <summary>
		/// <see cref="M:System.IDisposable.Dispose"/>
		/// </summary>
		public void Dispose()
		{
			//dispose all resources
			service.Dispose();
		}

		#endregion

		#region Members

		public string Ping()
		{
			return service.Ping();
		}

		#endregion Members
	}
}


