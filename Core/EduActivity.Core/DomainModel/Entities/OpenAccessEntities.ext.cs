using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AppFramework.Repository;
using Telerik.OpenAccess.Data.Common;
using System.Data;
using Telerik.OpenAccess;

namespace KMU.EduActivity.DomainModel.Entities
{
    public partial class EduActivityContext : OpenAccessContext, IEduActivityContextUnitOfWork
    {
        public string Fn_GetTopTeamCodeX(string inTeamCode)
        {
            OAParameter parameterInTeamCode = new OAParameter();
            parameterInTeamCode.ParameterName = "inTeamCode";
            parameterInTeamCode.Size = 50;
            if (inTeamCode != null)
            {
                parameterInTeamCode.Value = inTeamCode;
            }
            else
            {
                parameterInTeamCode.DbType = DbType.String;
                parameterInTeamCode.Value = DBNull.Value;
            }

            var queryResult = this.ExecuteQuery<string>("SELECT dbo.[fn_GetTopTeamCode](@inTeamCode)", parameterInTeamCode);

            return queryResult[0];
        }

    }

  public partial class EduTermCode : IValidatableObject
  {
      #region Properties

      #endregion Properties

      #region Methods

      #endregion Methods

      #region IValidatableObject Members

      /// <summary>
      /// <see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/>
      /// </summary>
      /// <param name="validationContext"><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></param>
      /// <returns><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></returns>
      public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
      {
          var validationResults = new List<ValidationResult>();

          //if (Discount < 0 || Discount > 1)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineDiscountCannotBeLessThanZeroOrGreaterThanOne,
          //                                                new string[] { "Discount" }));
          //if (OrderId == Guid.Empty)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineOrderIdIsEmpty,
          //                                               new string[] { "OrderId" }));

          //if (Amount <= 0)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineAmountLessThanOne,
          //                                               new string[] { "Amount" }));

          //if (UnitPrice < 0)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineUnitPriceLessThanZero,
          //                                               new string[] { "UnitPrice" }));

          //if ( ProductId == Guid.Empty)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineProductIdCannotBeNull,
          //                                             new string[]{"ProductId"}));

          return validationResults;
      }

      #endregion
  }

  public partial class Member : IValidatableObject
  {
      #region Properties

      #endregion Properties

      #region Methods

      #endregion Methods

      #region IValidatableObject Members

      /// <summary>
      /// <see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/>
      /// </summary>
      /// <param name="validationContext"><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></param>
      /// <returns><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></returns>
      public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
      {
          var validationResults = new List<ValidationResult>();

          //if (Discount < 0 || Discount > 1)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineDiscountCannotBeLessThanZeroOrGreaterThanOne,
          //                                                new string[] { "Discount" }));
          //if (OrderId == Guid.Empty)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineOrderIdIsEmpty,
          //                                               new string[] { "OrderId" }));

          //if (Amount <= 0)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineAmountLessThanOne,
          //                                               new string[] { "Amount" }));

          //if (UnitPrice < 0)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineUnitPriceLessThanZero,
          //                                               new string[] { "UnitPrice" }));

          //if ( ProductId == Guid.Empty)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineProductIdCannotBeNull,
          //                                             new string[]{"ProductId"}));

          return validationResults;
      }

      #endregion
  }

  public partial class EduTeamMember : IValidatableObject
  {
      #region Properties

      #endregion Properties

      #region Methods

      #endregion Methods

      #region IValidatableObject Members

      /// <summary>
      /// <see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/>
      /// </summary>
      /// <param name="validationContext"><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></param>
      /// <returns><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></returns>
      public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
      {
          var validationResults = new List<ValidationResult>();

          //if (Discount < 0 || Discount > 1)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineDiscountCannotBeLessThanZeroOrGreaterThanOne,
          //                                                new string[] { "Discount" }));
          //if (OrderId == Guid.Empty)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineOrderIdIsEmpty,
          //                                               new string[] { "OrderId" }));

          //if (Amount <= 0)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineAmountLessThanOne,
          //                                               new string[] { "Amount" }));

          //if (UnitPrice < 0)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineUnitPriceLessThanZero,
          //                                               new string[] { "UnitPrice" }));

          //if ( ProductId == Guid.Empty)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineProductIdCannotBeNull,
          //                                             new string[]{"ProductId"}));

          return validationResults;
      }

      #endregion
  }

  public partial class EduTeamRundown : IValidatableObject
  {
      #region Properties

      #endregion Properties

      #region Methods

      #endregion Methods

      #region IValidatableObject Members

      /// <summary>
      /// <see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/>
      /// </summary>
      /// <param name="validationContext"><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></param>
      /// <returns><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></returns>
      public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
      {
          var validationResults = new List<ValidationResult>();

          //if (Discount < 0 || Discount > 1)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineDiscountCannotBeLessThanZeroOrGreaterThanOne,
          //                                                new string[] { "Discount" }));
          //if (OrderId == Guid.Empty)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineOrderIdIsEmpty,
          //                                               new string[] { "OrderId" }));

          //if (Amount <= 0)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineAmountLessThanOne,
          //                                               new string[] { "Amount" }));

          //if (UnitPrice < 0)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineUnitPriceLessThanZero,
          //                                               new string[] { "UnitPrice" }));

          //if ( ProductId == Guid.Empty)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineProductIdCannotBeNull,
          //                                             new string[]{"ProductId"}));

          return validationResults;
      }

      #endregion
  }

  public partial class EduTeamMemberRundown : IValidatableObject
  {
      #region Properties

      #endregion Properties

      #region Methods

      #endregion Methods

      #region IValidatableObject Members

      /// <summary>
      /// <see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/>
      /// </summary>
      /// <param name="validationContext"><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></param>
      /// <returns><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></returns>
      public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
      {
          var validationResults = new List<ValidationResult>();

          //if (Discount < 0 || Discount > 1)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineDiscountCannotBeLessThanZeroOrGreaterThanOne,
          //                                                new string[] { "Discount" }));
          //if (OrderId == Guid.Empty)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineOrderIdIsEmpty,
          //                                               new string[] { "OrderId" }));

          //if (Amount <= 0)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineAmountLessThanOne,
          //                                               new string[] { "Amount" }));

          //if (UnitPrice < 0)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineUnitPriceLessThanZero,
          //                                               new string[] { "UnitPrice" }));

          //if ( ProductId == Guid.Empty)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineProductIdCannotBeNull,
          //                                             new string[]{"ProductId"}));

          return validationResults;
      }

      #endregion
  }

  public partial class EduTeam : IValidatableObject
  {
      #region Properties

      #endregion Properties

      #region Methods

      #endregion Methods

      #region IValidatableObject Members

      /// <summary>
      /// <see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/>
      /// </summary>
      /// <param name="validationContext"><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></param>
      /// <returns><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></returns>
      public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
      {
          var validationResults = new List<ValidationResult>();

          //if (Discount < 0 || Discount > 1)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineDiscountCannotBeLessThanZeroOrGreaterThanOne,
          //                                                new string[] { "Discount" }));
          //if (OrderId == Guid.Empty)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineOrderIdIsEmpty,
          //                                               new string[] { "OrderId" }));

          //if (Amount <= 0)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineAmountLessThanOne,
          //                                               new string[] { "Amount" }));

          //if (UnitPrice < 0)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineUnitPriceLessThanZero,
          //                                               new string[] { "UnitPrice" }));

          //if ( ProductId == Guid.Empty)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineProductIdCannotBeNull,
          //                                             new string[]{"ProductId"}));

          return validationResults;
      }

      #endregion
  }

  public partial class EduActTopic : IValidatableObject
  {
      #region Properties

      #endregion Properties

      #region Methods

      #endregion Methods

      #region IValidatableObject Members

      /// <summary>
      /// <see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/>
      /// </summary>
      /// <param name="validationContext"><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></param>
      /// <returns><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></returns>
      public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
      {
          var validationResults = new List<ValidationResult>();

          //if (Discount < 0 || Discount > 1)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineDiscountCannotBeLessThanZeroOrGreaterThanOne,
          //                                                new string[] { "Discount" }));
          //if (OrderId == Guid.Empty)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineOrderIdIsEmpty,
          //                                               new string[] { "OrderId" }));

          //if (Amount <= 0)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineAmountLessThanOne,
          //                                               new string[] { "Amount" }));

          //if (UnitPrice < 0)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineUnitPriceLessThanZero,
          //                                               new string[] { "UnitPrice" }));

          //if ( ProductId == Guid.Empty)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineProductIdCannotBeNull,
          //                                             new string[]{"ProductId"}));

          return validationResults;
      }

      #endregion
  }

  public partial class EduActType : IValidatableObject
  {
      #region Properties

      #endregion Properties

      #region Methods

      #endregion Methods

      #region IValidatableObject Members

      /// <summary>
      /// <see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/>
      /// </summary>
      /// <param name="validationContext"><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></param>
      /// <returns><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></returns>
      public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
      {
          var validationResults = new List<ValidationResult>();

          //if (Discount < 0 || Discount > 1)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineDiscountCannotBeLessThanZeroOrGreaterThanOne,
          //                                                new string[] { "Discount" }));
          //if (OrderId == Guid.Empty)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineOrderIdIsEmpty,
          //                                               new string[] { "OrderId" }));

          //if (Amount <= 0)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineAmountLessThanOne,
          //                                               new string[] { "Amount" }));

          //if (UnitPrice < 0)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineUnitPriceLessThanZero,
          //                                               new string[] { "UnitPrice" }));

          //if ( ProductId == Guid.Empty)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineProductIdCannotBeNull,
          //                                             new string[]{"ProductId"}));

          return validationResults;
      }

      #endregion
  }

  public partial class EduTerm : IValidatableObject
  {
      #region Properties

      #endregion Properties

      #region Methods

      #endregion Methods

      #region IValidatableObject Members

      /// <summary>
      /// <see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/>
      /// </summary>
      /// <param name="validationContext"><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></param>
      /// <returns><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></returns>
      public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
      {
          var validationResults = new List<ValidationResult>();

          //if (Discount < 0 || Discount > 1)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineDiscountCannotBeLessThanZeroOrGreaterThanOne,
          //                                                new string[] { "Discount" }));
          //if (OrderId == Guid.Empty)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineOrderIdIsEmpty,
          //                                               new string[] { "OrderId" }));

          //if (Amount <= 0)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineAmountLessThanOne,
          //                                               new string[] { "Amount" }));

          //if (UnitPrice < 0)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineUnitPriceLessThanZero,
          //                                               new string[] { "UnitPrice" }));

          //if ( ProductId == Guid.Empty)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineProductIdCannotBeNull,
          //                                             new string[]{"ProductId"}));

          return validationResults;
      }

      #endregion
  }

  public partial class EduStopActSchedule : IValidatableObject
  {
      #region Properties

      #endregion Properties

      #region Methods

      #endregion Methods

      #region IValidatableObject Members

      /// <summary>
      /// <see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/>
      /// </summary>
      /// <param name="validationContext"><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></param>
      /// <returns><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></returns>
      public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
      {
          var validationResults = new List<ValidationResult>();

          //if (Discount < 0 || Discount > 1)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineDiscountCannotBeLessThanZeroOrGreaterThanOne,
          //                                                new string[] { "Discount" }));
          //if (OrderId == Guid.Empty)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineOrderIdIsEmpty,
          //                                               new string[] { "OrderId" }));

          //if (Amount <= 0)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineAmountLessThanOne,
          //                                               new string[] { "Amount" }));

          //if (UnitPrice < 0)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineUnitPriceLessThanZero,
          //                                               new string[] { "UnitPrice" }));

          //if ( ProductId == Guid.Empty)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineProductIdCannotBeNull,
          //                                             new string[]{"ProductId"}));

          return validationResults;
      }

      #endregion
  }

  public partial class Form_ToDo_List : IValidatableObject
  {
      #region Properties

      #endregion Properties

      #region Methods

      #endregion Methods

      #region IValidatableObject Members

      /// <summary>
      /// <see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/>
      /// </summary>
      /// <param name="validationContext"><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></param>
      /// <returns><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></returns>
      public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
      {
          var validationResults = new List<ValidationResult>();

          //if (Discount < 0 || Discount > 1)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineDiscountCannotBeLessThanZeroOrGreaterThanOne,
          //                                                new string[] { "Discount" }));
          //if (OrderId == Guid.Empty)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineOrderIdIsEmpty,
          //                                               new string[] { "OrderId" }));

          //if (Amount <= 0)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineAmountLessThanOne,
          //                                               new string[] { "Amount" }));

          //if (UnitPrice < 0)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineUnitPriceLessThanZero,
          //                                               new string[] { "UnitPrice" }));

          //if ( ProductId == Guid.Empty)
          //    validationResults.Add(new ValidationResult(Messages.validation_OrderLineProductIdCannotBeNull,
          //                                             new string[]{"ProductId"}));

          return validationResults;
      }

      #endregion
  }


}

