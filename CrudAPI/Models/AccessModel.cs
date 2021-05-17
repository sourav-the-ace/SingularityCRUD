using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Models
{
	public class AccessModel
	{
		public int ID { get; set; }
		public string ACC_POL_ID { get; set; }
		public string USER_ID { get; set; }
		public string USER_NAME { get; set; }
		public string INSERT_ACCESS { get; set; }
		public string UPDATE_ACCESS { get; set; }
		public string DELETE_ACCESS { get; set; }
	}
}
