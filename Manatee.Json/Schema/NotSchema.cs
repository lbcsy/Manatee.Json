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
 
	File Name:		AnyOfSchema.cs
	Namespace:		Manatee.Json.Schema
	Class Name:		AnyOfSchema
	Purpose:		Used to define a collection of schema conditions, none of
					which may be satisfied.

***************************************************************************************/
using System.Collections.Generic;
using System.Linq;

namespace Manatee.Json.Schema
{
	/// <summary>
	/// Used to define a collection of schema conditions, none of which may be satisfied.
	/// </summary>
	public class NotSchema : IJsonSchema
	{
		/// <summary>
		/// A collection of schema which must not be satisfied.
		/// </summary>
		public IEnumerable<IJsonSchema> Restrictions { get; set; }
		/// <summary>
		/// The default value for this schema.
		/// </summary>
		/// <remarks>
		/// The default value is defined as a JSON value which may need to be deserialized
		/// to a .Net data structure.
		/// </remarks>
		public JsonValue Default { get; set; }

		/// <summary>
		/// Validates a <see cref="JsonValue"/> against the schema.
		/// </summary>
		/// <param name="json">A <see cref="JsonValue"/></param>
		/// <param name="root">The root schema serialized to a <see cref="JsonValue"/>.  Used internally for resolving references.</param>
		/// <returns>True if the <see cref="JsonValue"/> passes validation; otherwise false.</returns>
		public SchemaValidationResults Validate(JsonValue json, JsonValue root = null)
		{
			var jValue = root ?? ToJson();
			var errors = Restrictions.Select(s => s.Validate(json, jValue)).ToList();
			return errors.All(r => !r.Valid)
				? new SchemaValidationResults()
				: new SchemaValidationResults(errors);
		}
		/// <summary>
		/// Builds an object from a <see cref="JsonValue"/>.
		/// </summary>
		/// <param name="json">The <see cref="JsonValue"/> representation of the object.</param>
		public void FromJson(JsonValue json)
		{
			var obj = json.Object;
			Restrictions = obj["not"].Array.Select(JsonSchemaFactory.FromJson);
			if (obj.ContainsKey("default")) Default = obj["default"];
		}
		/// <summary>
		/// Converts an object to a <see cref="JsonValue"/>.
		/// </summary>
		/// <returns>The <see cref="JsonValue"/> representation of the object.</returns>
		public JsonValue ToJson()
		{
			var json = new JsonObject {{"not", Restrictions.ToJson()}};
			if (Default != null) json["default"] = Default;
			return json;
		}
	}
}