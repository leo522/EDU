using System;
using System.Linq.Expressions;
using System.Linq.QueryBuilder;
using AppFramework.Specifications;
using KMU.EduActivity.DomainModel.Entities;

namespace KMU.EduActivity.DomainModel.Specifications
{
  /// <summary>
  /// The EduTermCode specifications
  /// </summary>
  public static partial class EduTermCodeSpecifications
  {
      public static ISpecification<EduTermCode> Eval(Expression<Func<EduTermCode, bool>> expression)
      {
          /*
          string[] selectedValues = new string[] { };
          var queryBuilder = QueryBuilder.Create<EduTermCode>()
              .Like(c => c.Customer.ContactName, txtCustomer.Text)
              .Between(c => c.OrderDate, DateTime.Parse(txtDateFrom.Text), DateTime.Parse(txtDateTo.Text))
              .Equals(c => c.EmployeeID, int.Parse(ddlEmployee.SelectedValue))
              //.Equals(c => c.EmployeeID, null)
              .In(c => c.ShipCountry, selectedValues);
          */
          return Specification<EduTermCode>.Eval(expression);
      }
  }

  /// <summary>
  /// The Member specifications
  /// </summary>
  public static partial class MemberSpecifications
  {
      public static ISpecification<Member> Eval(Expression<Func<Member, bool>> expression)
      {
          /*
          string[] selectedValues = new string[] { };
          var queryBuilder = QueryBuilder.Create<Member>()
              .Like(c => c.Customer.ContactName, txtCustomer.Text)
              .Between(c => c.OrderDate, DateTime.Parse(txtDateFrom.Text), DateTime.Parse(txtDateTo.Text))
              .Equals(c => c.EmployeeID, int.Parse(ddlEmployee.SelectedValue))
              //.Equals(c => c.EmployeeID, null)
              .In(c => c.ShipCountry, selectedValues);
          */
          return Specification<Member>.Eval(expression);
      }
  }

  /// <summary>
  /// The EduTeamMember specifications
  /// </summary>
  public static partial class EduTeamMemberSpecifications
  {
      public static ISpecification<EduTeamMember> Eval(Expression<Func<EduTeamMember, bool>> expression)
      {
          /*
          string[] selectedValues = new string[] { };
          var queryBuilder = QueryBuilder.Create<EduTeamMember>()
              .Like(c => c.Customer.ContactName, txtCustomer.Text)
              .Between(c => c.OrderDate, DateTime.Parse(txtDateFrom.Text), DateTime.Parse(txtDateTo.Text))
              .Equals(c => c.EmployeeID, int.Parse(ddlEmployee.SelectedValue))
              //.Equals(c => c.EmployeeID, null)
              .In(c => c.ShipCountry, selectedValues);
          */
          return Specification<EduTeamMember>.Eval(expression);
      }
  }

  /// <summary>
  /// The EduTeamRundown specifications
  /// </summary>
  public static partial class EduTeamRundownSpecifications
  {
      public static ISpecification<EduTeamRundown> Eval(Expression<Func<EduTeamRundown, bool>> expression)
      {
          /*
          string[] selectedValues = new string[] { };
          var queryBuilder = QueryBuilder.Create<EduTeamRundown>()
              .Like(c => c.Customer.ContactName, txtCustomer.Text)
              .Between(c => c.OrderDate, DateTime.Parse(txtDateFrom.Text), DateTime.Parse(txtDateTo.Text))
              .Equals(c => c.EmployeeID, int.Parse(ddlEmployee.SelectedValue))
              //.Equals(c => c.EmployeeID, null)
              .In(c => c.ShipCountry, selectedValues);
          */
          return Specification<EduTeamRundown>.Eval(expression);
      }
  }

  /// <summary>
  /// The EduTeamMemberRundown specifications
  /// </summary>
  public static partial class EduTeamMemberRundownSpecifications
  {
      public static ISpecification<EduTeamMemberRundown> Eval(Expression<Func<EduTeamMemberRundown, bool>> expression)
      {
          /*
          string[] selectedValues = new string[] { };
          var queryBuilder = QueryBuilder.Create<EduTeamMemberRundown>()
              .Like(c => c.Customer.ContactName, txtCustomer.Text)
              .Between(c => c.OrderDate, DateTime.Parse(txtDateFrom.Text), DateTime.Parse(txtDateTo.Text))
              .Equals(c => c.EmployeeID, int.Parse(ddlEmployee.SelectedValue))
              //.Equals(c => c.EmployeeID, null)
              .In(c => c.ShipCountry, selectedValues);
          */
          return Specification<EduTeamMemberRundown>.Eval(expression);
      }
  }

  /// <summary>
  /// The EduTeam specifications
  /// </summary>
  public static partial class EduTeamSpecifications
  {
      public static ISpecification<EduTeam> Eval(Expression<Func<EduTeam, bool>> expression)
      {
          /*
          string[] selectedValues = new string[] { };
          var queryBuilder = QueryBuilder.Create<EduTeam>()
              .Like(c => c.Customer.ContactName, txtCustomer.Text)
              .Between(c => c.OrderDate, DateTime.Parse(txtDateFrom.Text), DateTime.Parse(txtDateTo.Text))
              .Equals(c => c.EmployeeID, int.Parse(ddlEmployee.SelectedValue))
              //.Equals(c => c.EmployeeID, null)
              .In(c => c.ShipCountry, selectedValues);
          */
          return Specification<EduTeam>.Eval(expression);
      }
  }

  /// <summary>
  /// The EduActTopic specifications
  /// </summary>
  public static partial class EduActTopicSpecifications
  {
      public static ISpecification<EduActTopic> Eval(Expression<Func<EduActTopic, bool>> expression)
      {
          /*
          string[] selectedValues = new string[] { };
          var queryBuilder = QueryBuilder.Create<EduActTopic>()
              .Like(c => c.Customer.ContactName, txtCustomer.Text)
              .Between(c => c.OrderDate, DateTime.Parse(txtDateFrom.Text), DateTime.Parse(txtDateTo.Text))
              .Equals(c => c.EmployeeID, int.Parse(ddlEmployee.SelectedValue))
              //.Equals(c => c.EmployeeID, null)
              .In(c => c.ShipCountry, selectedValues);
          */
          return Specification<EduActTopic>.Eval(expression);
      }
  }

  /// <summary>
  /// The EduStopActSchedule specifications
  /// </summary>
  public static partial class EduStopActScheduleSpecifications
  {
      public static ISpecification<EduStopActSchedule> Eval(Expression<Func<EduStopActSchedule, bool>> expression)
      {
          /*
          string[] selectedValues = new string[] { };
          var queryBuilder = QueryBuilder.Create<EduStopActSchedule>()
              .Like(c => c.Customer.ContactName, txtCustomer.Text)
              .Between(c => c.OrderDate, DateTime.Parse(txtDateFrom.Text), DateTime.Parse(txtDateTo.Text))
              .Equals(c => c.EmployeeID, int.Parse(ddlEmployee.SelectedValue))
              //.Equals(c => c.EmployeeID, null)
              .In(c => c.ShipCountry, selectedValues);
          */
          return Specification<EduStopActSchedule>.Eval(expression);
      }
  }

  /// <summary>
  /// The Form_ToDo_List specifications
  /// </summary>
  public static partial class Form_ToDo_ListSpecifications
  {
      public static ISpecification<Form_ToDo_List> Eval(Expression<Func<Form_ToDo_List, bool>> expression)
      {
          /*
          string[] selectedValues = new string[] { };
          var queryBuilder = QueryBuilder.Create<Form_ToDo_List>()
              .Like(c => c.Customer.ContactName, txtCustomer.Text)
              .Between(c => c.OrderDate, DateTime.Parse(txtDateFrom.Text), DateTime.Parse(txtDateTo.Text))
              .Equals(c => c.EmployeeID, int.Parse(ddlEmployee.SelectedValue))
              //.Equals(c => c.EmployeeID, null)
              .In(c => c.ShipCountry, selectedValues);
          */
          return Specification<Form_ToDo_List>.Eval(expression);
      }
  }

  /// <summary>
  /// The EduTermFormInstance specifications
  /// </summary>
  public static partial class EduTermFormInstanceSpecifications
  {
      public static ISpecification<EduTermFormInstance> Eval(Expression<Func<EduTermFormInstance, bool>> expression)
      {
          /*
          string[] selectedValues = new string[] { };
          var queryBuilder = QueryBuilder.Create<EduTermFormInstance>()
              .Like(c => c.Customer.ContactName, txtCustomer.Text)
              .Between(c => c.OrderDate, DateTime.Parse(txtDateFrom.Text), DateTime.Parse(txtDateTo.Text))
              .Equals(c => c.EmployeeID, int.Parse(ddlEmployee.SelectedValue))
              //.Equals(c => c.EmployeeID, null)
              .In(c => c.ShipCountry, selectedValues);
          */
          return Specification<EduTermFormInstance>.Eval(expression);
      }
  }

  /// <summary>
  /// The EduFormTemplateTarget specifications
  /// </summary>
  public static partial class EduFormTemplateTargetSpecifications
  {
      public static ISpecification<EduFormTemplateTarget> Eval(Expression<Func<EduFormTemplateTarget, bool>> expression)
      {
          /*
          string[] selectedValues = new string[] { };
          var queryBuilder = QueryBuilder.Create<EduFormTemplateTarget>()
              .Like(c => c.Customer.ContactName, txtCustomer.Text)
              .Between(c => c.OrderDate, DateTime.Parse(txtDateFrom.Text), DateTime.Parse(txtDateTo.Text))
              .Equals(c => c.EmployeeID, int.Parse(ddlEmployee.SelectedValue))
              //.Equals(c => c.EmployeeID, null)
              .In(c => c.ShipCountry, selectedValues);
          */
          return Specification<EduFormTemplateTarget>.Eval(expression);
      }
  }

  /// <summary>
  /// The EduFormTemplateList specifications
  /// </summary>
  public static partial class EduFormTemplateListSpecifications
  {
      public static ISpecification<EduFormTemplateList> Eval(Expression<Func<EduFormTemplateList, bool>> expression)
      {
          /*
          string[] selectedValues = new string[] { };
          var queryBuilder = QueryBuilder.Create<EduFormTemplateList>()
              .Like(c => c.Customer.ContactName, txtCustomer.Text)
              .Between(c => c.OrderDate, DateTime.Parse(txtDateFrom.Text), DateTime.Parse(txtDateTo.Text))
              .Equals(c => c.EmployeeID, int.Parse(ddlEmployee.SelectedValue))
              //.Equals(c => c.EmployeeID, null)
              .In(c => c.ShipCountry, selectedValues);
          */
          return Specification<EduFormTemplateList>.Eval(expression);
      }
  }

  /// <summary>
  /// The EduStop specifications
  /// </summary>
  public static partial class EduStopSpecifications
  {
      public static ISpecification<EduStop> Eval(Expression<Func<EduStop, bool>> expression)
      {
          /*
          string[] selectedValues = new string[] { };
          var queryBuilder = QueryBuilder.Create<EduStop>()
              .Like(c => c.Customer.ContactName, txtCustomer.Text)
              .Between(c => c.OrderDate, DateTime.Parse(txtDateFrom.Text), DateTime.Parse(txtDateTo.Text))
              .Equals(c => c.EmployeeID, int.Parse(ddlEmployee.SelectedValue))
              //.Equals(c => c.EmployeeID, null)
              .In(c => c.ShipCountry, selectedValues);
          */
          return Specification<EduStop>.Eval(expression);
      }
  }

  /// <summary>
  /// The EduTerm specifications
  /// </summary>
  public static partial class EduTermSpecifications
  {
      public static ISpecification<EduTerm> Eval(Expression<Func<EduTerm, bool>> expression)
      {
          /*
          string[] selectedValues = new string[] { };
          var queryBuilder = QueryBuilder.Create<EduTerm>()
              .Like(c => c.Customer.ContactName, txtCustomer.Text)
              .Between(c => c.OrderDate, DateTime.Parse(txtDateFrom.Text), DateTime.Parse(txtDateTo.Text))
              .Equals(c => c.EmployeeID, int.Parse(ddlEmployee.SelectedValue))
              //.Equals(c => c.EmployeeID, null)
              .In(c => c.ShipCountry, selectedValues);
          */
          return Specification<EduTerm>.Eval(expression);
      }
  }

  /// <summary>
  /// The V_ExpireFormInstance specifications
  /// </summary>
  public static partial class V_ExpireFormInstanceSpecifications
  {
      public static ISpecification<V_ExpireFormInstance> Eval(Expression<Func<V_ExpireFormInstance, bool>> expression)
      {
          /*
          string[] selectedValues = new string[] { };
          var queryBuilder = QueryBuilder.Create<V_ExpireFormInstance>()
              .Like(c => c.Customer.ContactName, txtCustomer.Text)
              .Between(c => c.OrderDate, DateTime.Parse(txtDateFrom.Text), DateTime.Parse(txtDateTo.Text))
              .Equals(c => c.EmployeeID, int.Parse(ddlEmployee.SelectedValue))
              //.Equals(c => c.EmployeeID, null)
              .In(c => c.ShipCountry, selectedValues);
          */
          return Specification<V_ExpireFormInstance>.Eval(expression);
      }
  }

  /// <summary>
  /// The EduTeacherType specifications
  /// </summary>
  public static partial class EduTeacherTypeSpecifications
  {
      public static ISpecification<EduTeacherType> Eval(Expression<Func<EduTeacherType, bool>> expression)
      {
          /*
          string[] selectedValues = new string[] { };
          var queryBuilder = QueryBuilder.Create<EduTeacherType>()
              .Like(c => c.Customer.ContactName, txtCustomer.Text)
              .Between(c => c.OrderDate, DateTime.Parse(txtDateFrom.Text), DateTime.Parse(txtDateTo.Text))
              .Equals(c => c.EmployeeID, int.Parse(ddlEmployee.SelectedValue))
              //.Equals(c => c.EmployeeID, null)
              .In(c => c.ShipCountry, selectedValues);
          */
          return Specification<EduTeacherType>.Eval(expression);
      }
  }

  /// <summary>
  /// The EduRefTeacher specifications
  /// </summary>
  public static partial class EduRefTeacherSpecifications
  {
      public static ISpecification<EduRefTeacher> Eval(Expression<Func<EduRefTeacher, bool>> expression)
      {
          /*
          string[] selectedValues = new string[] { };
          var queryBuilder = QueryBuilder.Create<EduRefTeacher>()
              .Like(c => c.Customer.ContactName, txtCustomer.Text)
              .Between(c => c.OrderDate, DateTime.Parse(txtDateFrom.Text), DateTime.Parse(txtDateTo.Text))
              .Equals(c => c.EmployeeID, int.Parse(ddlEmployee.SelectedValue))
              //.Equals(c => c.EmployeeID, null)
              .In(c => c.ShipCountry, selectedValues);
          */
          return Specification<EduRefTeacher>.Eval(expression);
      }
  }

}

