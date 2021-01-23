/*
 * Copyright 2016 Game Server Services, Inc. or its affiliates. All Rights
 * Reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 *
 *  http://www.apache.org/licenses/LICENSE-2.0
 *
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Gs2.Core.Model;
using Gs2.Util.LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Formation.Model
{
	[Preserve]
	public class MoldModel : IComparable
	{

        /** フォームの保存領域マスター */
        public string moldModelId { set; get; }

        /**
         * フォームの保存領域マスターを設定
         *
         * @param moldModelId フォームの保存領域マスター
         * @return this
         */
        public MoldModel WithMoldModelId(string moldModelId) {
            this.moldModelId = moldModelId;
            return this;
        }

        /** フォームの保存領域名 */
        public string name { set; get; }

        /**
         * フォームの保存領域名を設定
         *
         * @param name フォームの保存領域名
         * @return this
         */
        public MoldModel WithName(string name) {
            this.name = name;
            return this;
        }

        /** メタデータ */
        public string metadata { set; get; }

        /**
         * メタデータを設定
         *
         * @param metadata メタデータ
         * @return this
         */
        public MoldModel WithMetadata(string metadata) {
            this.metadata = metadata;
            return this;
        }

        /** None */
        public Gs2.Gs2Formation.Model.FormModel formModel { set; get; }

        /**
         * Noneを設定
         *
         * @param formModel None
         * @return this
         */
        public MoldModel WithFormModel(Gs2.Gs2Formation.Model.FormModel formModel) {
            this.formModel = formModel;
            return this;
        }

        /** フォームを保存できる初期キャパシティ */
        public int? initialMaxCapacity { set; get; }

        /**
         * フォームを保存できる初期キャパシティを設定
         *
         * @param initialMaxCapacity フォームを保存できる初期キャパシティ
         * @return this
         */
        public MoldModel WithInitialMaxCapacity(int? initialMaxCapacity) {
            this.initialMaxCapacity = initialMaxCapacity;
            return this;
        }

        /** フォームを保存できるキャパシティ */
        public int? maxCapacity { set; get; }

        /**
         * フォームを保存できるキャパシティを設定
         *
         * @param maxCapacity フォームを保存できるキャパシティ
         * @return this
         */
        public MoldModel WithMaxCapacity(int? maxCapacity) {
            this.maxCapacity = maxCapacity;
            return this;
        }

        public void WriteJson(JsonWriter writer)
        {
            writer.WriteObjectStart();
            if(this.moldModelId != null)
            {
                writer.WritePropertyName("moldModelId");
                writer.Write(this.moldModelId);
            }
            if(this.name != null)
            {
                writer.WritePropertyName("name");
                writer.Write(this.name);
            }
            if(this.metadata != null)
            {
                writer.WritePropertyName("metadata");
                writer.Write(this.metadata);
            }
            if(this.formModel != null)
            {
                writer.WritePropertyName("formModel");
                this.formModel.WriteJson(writer);
            }
            if(this.initialMaxCapacity.HasValue)
            {
                writer.WritePropertyName("initialMaxCapacity");
                writer.Write(this.initialMaxCapacity.Value);
            }
            if(this.maxCapacity.HasValue)
            {
                writer.WritePropertyName("maxCapacity");
                writer.Write(this.maxCapacity.Value);
            }
            writer.WriteObjectEnd();
        }

    public static string GetMoldNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):formation:(?<namespaceName>.*):model:(?<moldName>.*)");
        if (!match.Groups["moldName"].Success)
        {
            return null;
        }
        return match.Groups["moldName"].Value;
    }

    public static string GetNamespaceNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):formation:(?<namespaceName>.*):model:(?<moldName>.*)");
        if (!match.Groups["namespaceName"].Success)
        {
            return null;
        }
        return match.Groups["namespaceName"].Value;
    }

    public static string GetOwnerIdFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):formation:(?<namespaceName>.*):model:(?<moldName>.*)");
        if (!match.Groups["ownerId"].Success)
        {
            return null;
        }
        return match.Groups["ownerId"].Value;
    }

    public static string GetRegionFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):formation:(?<namespaceName>.*):model:(?<moldName>.*)");
        if (!match.Groups["region"].Success)
        {
            return null;
        }
        return match.Groups["region"].Value;
    }

    	[Preserve]
        public static MoldModel FromDict(JsonData data)
        {
            return new MoldModel()
                .WithMoldModelId(data.Keys.Contains("moldModelId") && data["moldModelId"] != null ? data["moldModelId"].ToString() : null)
                .WithName(data.Keys.Contains("name") && data["name"] != null ? data["name"].ToString() : null)
                .WithMetadata(data.Keys.Contains("metadata") && data["metadata"] != null ? data["metadata"].ToString() : null)
                .WithFormModel(data.Keys.Contains("formModel") && data["formModel"] != null ? Gs2.Gs2Formation.Model.FormModel.FromDict(data["formModel"]) : null)
                .WithInitialMaxCapacity(data.Keys.Contains("initialMaxCapacity") && data["initialMaxCapacity"] != null ? (int?)int.Parse(data["initialMaxCapacity"].ToString()) : null)
                .WithMaxCapacity(data.Keys.Contains("maxCapacity") && data["maxCapacity"] != null ? (int?)int.Parse(data["maxCapacity"].ToString()) : null);
        }

        public int CompareTo(object obj)
        {
            var other = obj as MoldModel;
            var diff = 0;
            if (moldModelId == null && moldModelId == other.moldModelId)
            {
                // null and null
            }
            else
            {
                diff += moldModelId.CompareTo(other.moldModelId);
            }
            if (name == null && name == other.name)
            {
                // null and null
            }
            else
            {
                diff += name.CompareTo(other.name);
            }
            if (metadata == null && metadata == other.metadata)
            {
                // null and null
            }
            else
            {
                diff += metadata.CompareTo(other.metadata);
            }
            if (formModel == null && formModel == other.formModel)
            {
                // null and null
            }
            else
            {
                diff += formModel.CompareTo(other.formModel);
            }
            if (initialMaxCapacity == null && initialMaxCapacity == other.initialMaxCapacity)
            {
                // null and null
            }
            else
            {
                diff += (int)(initialMaxCapacity - other.initialMaxCapacity);
            }
            if (maxCapacity == null && maxCapacity == other.maxCapacity)
            {
                // null and null
            }
            else
            {
                diff += (int)(maxCapacity - other.maxCapacity);
            }
            return diff;
        }
	}
}