using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using AppFramework.ApplicationLayer.DTO;
using KMUH.EduForm.ApplicationLayer.DTO;
using KMUH.EduForm.ApplicationLayer.Services;


namespace KMUH.EduForm.Services
{
	[ServiceContract]
	public interface ICodeRefWCFService
	{
		[OperationContract]
		[FaultContract(typeof(ErrorHandlers.ApplicationServiceError))]
		IEnumerable<CodeRefDto> GetCodeReferenceItems(CodeReferenceType type);
	}
}	


