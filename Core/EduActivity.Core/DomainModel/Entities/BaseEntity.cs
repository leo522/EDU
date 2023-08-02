
using System;
using System.Collections.Generic;
using AppFramework.Sequence;

namespace KMU.EduActivity.DomainModel.Entities
{
	public abstract class Entity
	{
		#region Public Methods

		/// <summary>
		/// Generate identity for this entity
		/// </summary>
		public virtual string GenerateNewIdentity()
		{
			return GenerateNewIdentity(this.GetType().Name + "Identity");
		}

		/// <summary>
		/// Generate identity for this entity
		/// </summary>
		public virtual string GenerateNewIdentity(string sequenceKey)
		{
			var sequence = SequenceProviderFactory.CreateSequenceProvider(SequenceType.Custom);
			sequence.sequenceKey = sequenceKey;
			var seqId = sequence.getNext();
			return seqId;
		}

		#endregion Public Methods
	}
}


