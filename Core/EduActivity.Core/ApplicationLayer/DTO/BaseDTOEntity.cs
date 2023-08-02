
using System;
using System.Collections.Generic;

namespace KMU.EduActivity.ApplicationLayer.DTO
{
	public enum RowState : int
	{
		/// <summary>
		/// The object has no changes.
		/// </summary>
		Unchanged,
		/// <summary>
		/// The object has been inserted.
		/// </summary>
		Insert,
		/// <summary>
		/// The object has been updated.
		/// </summary>
		Update,
		/// <summary>
		/// The object has been deleted.
		/// </summary>
		Delete
	}
    [Serializable]
	public class BaseDTOEntity
	{
		public RowState RowState { get;set; }
	}
}


