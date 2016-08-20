﻿/***************************************************************************************

	Copyright 2016 Greg Dennis

	   Licensed under the Apache License, Version 2.0 (the "License");
	   you may not use this file except in compliance with the License.
	   You may obtain a copy of the License at

		 http://www.apache.org/licenses/LICENSE-2.0

	   Unless required by applicable law or agreed to in writing, software
	   distributed under the License is distributed on an "AS IS" BASIS,
	   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	   See the License for the specific language governing permissions and
	   limitations under the License.
 
	File Name:		AnyOfSchemaValidator.cs
	Namespace:		Manatee.Json.Schema.Validators
	Class Name:		AnyOfSchemaValidator
	Purpose:		Validates schema with an "anyOf" property.

***************************************************************************************/

using System.Linq;

namespace Manatee.Json.Schema.Validators
{
	internal class AnyOfSchemaValidator : IJsonSchemaValidator
	{
		public bool Applies(JsonSchema schema)
		{
			return schema.AnyOf != null;
		}

		public SchemaValidationResults Validate(JsonSchema schema, JsonValue json, JsonValue root)
		{
			var errors = schema.AnyOf.Select(s => s.Validate(json, root)).ToList();
			return errors.Any(r => r.Valid)
					   ? new SchemaValidationResults()
					   : new SchemaValidationResults(errors);
		}
	}
}
