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

namespace Gs2.Gs2Lottery.Model
{
	[Preserve]
	public class PrizeTableMaster : IComparable
	{

        /** 排出確率テーブルマスター */
        public string prizeTableId { set; get; }

        /**
         * 排出確率テーブルマスターを設定
         *
         * @param prizeTableId 排出確率テーブルマスター
         * @return this
         */
        public PrizeTableMaster WithPrizeTableId(string prizeTableId) {
            this.prizeTableId = prizeTableId;
            return this;
        }

        /** 排出確率テーブル名 */
        public string name { set; get; }

        /**
         * 排出確率テーブル名を設定
         *
         * @param name 排出確率テーブル名
         * @return this
         */
        public PrizeTableMaster WithName(string name) {
            this.name = name;
            return this;
        }

        /** 排出確率テーブルのメタデータ */
        public string metadata { set; get; }

        /**
         * 排出確率テーブルのメタデータを設定
         *
         * @param metadata 排出確率テーブルのメタデータ
         * @return this
         */
        public PrizeTableMaster WithMetadata(string metadata) {
            this.metadata = metadata;
            return this;
        }

        /** 排出確率テーブルマスターの説明 */
        public string description { set; get; }

        /**
         * 排出確率テーブルマスターの説明を設定
         *
         * @param description 排出確率テーブルマスターの説明
         * @return this
         */
        public PrizeTableMaster WithDescription(string description) {
            this.description = description;
            return this;
        }

        /** 景品リスト */
        public List<Prize> prizes { set; get; }

        /**
         * 景品リストを設定
         *
         * @param prizes 景品リスト
         * @return this
         */
        public PrizeTableMaster WithPrizes(List<Prize> prizes) {
            this.prizes = prizes;
            return this;
        }

        /** 作成日時 */
        public long? createdAt { set; get; }

        /**
         * 作成日時を設定
         *
         * @param createdAt 作成日時
         * @return this
         */
        public PrizeTableMaster WithCreatedAt(long? createdAt) {
            this.createdAt = createdAt;
            return this;
        }

        /** 最終更新日時 */
        public long? updatedAt { set; get; }

        /**
         * 最終更新日時を設定
         *
         * @param updatedAt 最終更新日時
         * @return this
         */
        public PrizeTableMaster WithUpdatedAt(long? updatedAt) {
            this.updatedAt = updatedAt;
            return this;
        }

        public void WriteJson(JsonWriter writer)
        {
            writer.WriteObjectStart();
            if(this.prizeTableId != null)
            {
                writer.WritePropertyName("prizeTableId");
                writer.Write(this.prizeTableId);
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
            if(this.description != null)
            {
                writer.WritePropertyName("description");
                writer.Write(this.description);
            }
            if(this.prizes != null)
            {
                writer.WritePropertyName("prizes");
                writer.WriteArrayStart();
                foreach(var item in this.prizes)
                {
                    item.WriteJson(writer);
                }
                writer.WriteArrayEnd();
            }
            if(this.createdAt.HasValue)
            {
                writer.WritePropertyName("createdAt");
                writer.Write(this.createdAt.Value);
            }
            if(this.updatedAt.HasValue)
            {
                writer.WritePropertyName("updatedAt");
                writer.Write(this.updatedAt.Value);
            }
            writer.WriteObjectEnd();
        }

    public static string GetPrizeTableNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):lottery:(?<namespaceName>.*):table:(?<prizeTableName>.*)");
        if (!match.Groups["prizeTableName"].Success)
        {
            return null;
        }
        return match.Groups["prizeTableName"].Value;
    }

    public static string GetNamespaceNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):lottery:(?<namespaceName>.*):table:(?<prizeTableName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):lottery:(?<namespaceName>.*):table:(?<prizeTableName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):lottery:(?<namespaceName>.*):table:(?<prizeTableName>.*)");
        if (!match.Groups["region"].Success)
        {
            return null;
        }
        return match.Groups["region"].Value;
    }

    	[Preserve]
        public static PrizeTableMaster FromDict(JsonData data)
        {
            return new PrizeTableMaster()
                .WithPrizeTableId(data.Keys.Contains("prizeTableId") && data["prizeTableId"] != null ? data["prizeTableId"].ToString() : null)
                .WithName(data.Keys.Contains("name") && data["name"] != null ? data["name"].ToString() : null)
                .WithMetadata(data.Keys.Contains("metadata") && data["metadata"] != null ? data["metadata"].ToString() : null)
                .WithDescription(data.Keys.Contains("description") && data["description"] != null ? data["description"].ToString() : null)
                .WithPrizes(data.Keys.Contains("prizes") && data["prizes"] != null ? data["prizes"].Cast<JsonData>().Select(value =>
                    {
                        return Gs2.Gs2Lottery.Model.Prize.FromDict(value);
                    }
                ).ToList() : null)
                .WithCreatedAt(data.Keys.Contains("createdAt") && data["createdAt"] != null ? (long?)long.Parse(data["createdAt"].ToString()) : null)
                .WithUpdatedAt(data.Keys.Contains("updatedAt") && data["updatedAt"] != null ? (long?)long.Parse(data["updatedAt"].ToString()) : null);
        }

        public int CompareTo(object obj)
        {
            var other = obj as PrizeTableMaster;
            var diff = 0;
            if (prizeTableId == null && prizeTableId == other.prizeTableId)
            {
                // null and null
            }
            else
            {
                diff += prizeTableId.CompareTo(other.prizeTableId);
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
            if (description == null && description == other.description)
            {
                // null and null
            }
            else
            {
                diff += description.CompareTo(other.description);
            }
            if (prizes == null && prizes == other.prizes)
            {
                // null and null
            }
            else
            {
                diff += prizes.Count - other.prizes.Count;
                for (var i = 0; i < prizes.Count; i++)
                {
                    diff += prizes[i].CompareTo(other.prizes[i]);
                }
            }
            if (createdAt == null && createdAt == other.createdAt)
            {
                // null and null
            }
            else
            {
                diff += (int)(createdAt - other.createdAt);
            }
            if (updatedAt == null && updatedAt == other.updatedAt)
            {
                // null and null
            }
            else
            {
                diff += (int)(updatedAt - other.updatedAt);
            }
            return diff;
        }
	}
}