﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manatee.Json.Serialization.Enumerations
{
	internal enum DateTimeSerializationFormat
	{
		/// <summary>
		/// Output conforms to ISO 8601 formatting: YYYY-MM-DDThh:mm:ss.sTZD (e.g. 1997-07-16T19:20:30.45+01:00)
		/// </summary>
		Iso8601,
		/// <summary>
		/// Output is a string in the format "/Date([ms])/", where [ms] is the number of milliseconds
		/// since January 1, 1970 UTC.
		/// </summary>
		JavaConstructor,
		/// <summary>
		/// Output is a numeric value representing the number of milliseconds since January 1, 1970 UTC.
		/// </summary>
		Milliseconds
	}
}
