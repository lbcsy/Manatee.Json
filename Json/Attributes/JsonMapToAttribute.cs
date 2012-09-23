﻿/***************************************************************************************

	Copyright 2012 Greg Dennis

	   Licensed under the Apache License, Version 2.0 (the "License");
	   you may not use this file except in compliance with the License.
	   You may obtain a copy of the License at

		 http://www.apache.org/licenses/LICENSE-2.0

	   Unless required by applicable law or agreed to in writing, software
	   distributed under the License is distributed on an "AS IS" BASIS,
	   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	   See the License for the specific language governing permissions and
	   limitations under the License.
 
	File Name:		JsonMapToAttribute.cs
	Namespace:		Manatee.Json.Attributes
	Class Name:		JsonMapToAttribute
	Purpose:		Applied to properties to customize how they are to be
					serialized.

***************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manatee.Json.Attributes
{
	/// <summary>
	/// Allows the user to specify how a property is mapped during serialization.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class JsonMapToAttribute : Attribute
	{
		public string MapToKey { get; set; }

		public JsonMapToAttribute(string key)
		{
			MapToKey = key;
		}
	}
}