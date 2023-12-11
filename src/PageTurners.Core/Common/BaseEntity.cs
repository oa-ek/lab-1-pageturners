using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Domain.Common
{
	public abstract class BaseEntity
	{
		public int Id { get; set; }
		public DateTime? Created { get; set; } = DateTime.UtcNow;
		public DateTime? Updated { get; set; } = DateTime.UtcNow;
	}
}
