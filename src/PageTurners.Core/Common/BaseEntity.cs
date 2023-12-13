﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PageTurners.Domain.Common
{
	public abstract class BaseEntity<TKey>
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public TKey Id { get; set; }
	}
}