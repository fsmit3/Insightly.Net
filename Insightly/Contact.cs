﻿/*
 * Copyright 2014 Beckersoft, Inc.
 *
 * Author(s):
 *  John Becker (john@beckersoft.com)
 *  
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insightly
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Contact
    {
        public Contact() { }

        public Contact(string fullName)
        {
            //string[] salutations = new string[] { "MR", "MS", "MRS", "MISS", "DR" };
            if(!string.IsNullOrWhiteSpace(fullName))
            {
                int lastSpace = fullName.LastIndexOf(' ');
                if (lastSpace > 0)
                {
                    this.FirstName = fullName.Substring(0, fullName.Length - lastSpace);
                    this.LastName = fullName.Substring(lastSpace);
                }
                else
                {
                    this.FirstName = fullName;
                }
            }
        }

        [JsonProperty(PropertyName = "CONTACT_ID", NullValueHandling = NullValueHandling.Ignore)]
        public int? Id { get; set; }

        [JsonProperty(PropertyName = "SALUTATION", NullValueHandling = NullValueHandling.Ignore)]
        public string Salutation { get; set; }

        [JsonProperty(PropertyName = "FIRST_NAME", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "LAST_NAME", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Infos"), JsonProperty(PropertyName = "CONTACTINFOS", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<ContactInfo> ContactInfos { get; set; }
    }
}