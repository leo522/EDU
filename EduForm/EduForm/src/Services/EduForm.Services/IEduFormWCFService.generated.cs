using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using KMUH.EduForm.ApplicationLayer.DTO;


namespace KMUH.EduForm.Services
{
	[ServiceContract]
	public partial interface IEduFormWCFService : IDisposable
	{
		[OperationContract]
		[FaultContract(typeof(ErrorHandlers.ApplicationServiceError))]
		string Ping();

	}
}


