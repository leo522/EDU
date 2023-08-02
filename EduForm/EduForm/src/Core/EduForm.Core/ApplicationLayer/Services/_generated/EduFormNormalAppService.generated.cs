namespace KMUH.EduForm.ApplicationLayer.Services
{
    using System;

    public class EduFormNormalAppService
    {
        public Type getTypeOfOperationService()
        {
           return typeof(EduFormOperationService);
        }
    }
}

