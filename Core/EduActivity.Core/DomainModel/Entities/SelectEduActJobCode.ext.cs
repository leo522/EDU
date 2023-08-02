using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KMU.EduActivity.DomainModel.Entities
{
  public partial class SelectEduActJobCode : IValidatableObject
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

