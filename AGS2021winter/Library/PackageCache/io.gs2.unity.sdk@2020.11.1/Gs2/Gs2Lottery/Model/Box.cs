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
	public class Box : IComparable
	{

        /** ボックス */
        public string boxId { set; get; }

        /**
         * ボックスを設定
         *
         * @param boxId ボックス
         * @return this
         */
        public Box WithBoxId(string boxId) {
            this.boxId = boxId;
            return this;
        }

        /** 排出確率テーブル名 */
        public string prizeTableName { set; get; }

        /**
         * 排出確率テーブル名を設定
         *
         * @param prizeTableName 排出確率テーブル名
         * @return this
         */
        public Box WithPrizeTableName(string prizeTableName) {
            this.prizeTableName = prizeTableName;
            return this;
        }

        /** ユーザーID */
        public string userId { set; get; }

        /**
         * ユーザーIDを設定
         *
         * @param userId ユーザーID
         * @return this
         */
        public Box WithUserId(string userId) {
            this.userId = userId;
            return this;
        }

        /** 排出済み景品のインデックスのリスト */
        public List<int?> drawnIndexes { set; get; }

        /**
         * 排出済み景品のインデックスのリストを設定
         *
         * @param drawnIndexes 排出済み景品のインデックスのリスト
         * @return this
         */
        public Box WithDrawnIndexes(List<int?> drawnIndexes) {
            this.drawnIndexes = drawnIndexes;
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
        public Box WithCreatedAt(long? createdAt) {
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
        public Box WithUpdatedAt(long? updatedAt) {
            this.updatedAt = updatedAt;
            return this;
        }

        public void WriteJson(JsonWriter writer)
        {
            writer.WriteObjectStart();
            if(this.boxId != null)
            {
                writer.WritePropertyName("boxId");
                writer.Write(this.boxId);
            }
            if(this.prizeTableName != null)
            {
                writer.WritePropertyName("prizeTableName");
                writer.Write(this.prizeTableName);
            }
            if(this.userId != null)
            {
                writer.WritePropertyName("userId");
                writer.Write(this.userId);
            }
            if(this.drawnIndexes != null)
            {
                writer.WritePropertyName("drawnIndexes");
                writer.WriteArrayStart();
                foreach(var item in this.drawnIndexes)
                {
                    writer.Write(item.Value);
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):lottery:(?<namespaceName>.*):user:(?<userId>.*):box:table:(?<prizeTableName>.*)");
        if (!match.Groups["prizeTableName"].Success)
        {
            return null;
        }
        return match.Groups["prizeTableName"].Value;
    }

    public static string GetUserIdFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):lottery:(?<namespaceName>.*):user:(?<userId>.*):box:table:(?<prizeTableName>.*)");
        if (!match.Groups["userId"].Success)
        {
            return null;
        }
        return match.Groups["userId"].Value;
    }

    public static string GetNamespaceNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):lottery:(?<namespaceName>.*):user:(?<userId>.*):box:table:(?<prizeTableName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):lottery:(?<namespaceName>.*):user:(?<userId>.*):box:table:(?<prizeTableName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):lottery:(?<namespaceName>.*):user:(?<userId>.*):box:table:(?<prizeTableName>.*)");
        if (!match.Groups["region"].Success)
        {
            return null;
        }
        return match.Groups["region"].Value;
    }

    	[Preserve]
        public static Box FromDict(JsonData data)
        {
            return new Box()
                .WithBoxId(data.Keys.Contains("boxId") && data["boxId"] != null ? data["boxId"].ToString() : null)
                .WithPrizeTableName(data.Keys.Contains("prizeTableName") && data["prizeTableName"] != null ? data["prizeTableName"].ToString() : null)
                .WithUserId(data.Keys.Contains("userId") && data["userId"] != null ? data["userId"].ToString() : null)
                .WithDrawnIndexes(data.Keys.Contains("drawnIndexes") && data["drawnIndexes"] != null ? data["drawnIndexes"].Cast<JsonData>().Select(value =>
                    {
                        return (int?)int.Parse(value.ToString());
                    }
                ).ToList() : null)
                .WithCreatedAt(data.Keys.Contains("createdAt") && data["createdAt"] != null ? (long?)long.Parse(data["createdAt"].ToString()) : null)
                .WithUpdatedAt(data.Keys.Contains("updatedAt") && data["updatedAt"] != null ? (long?)long.Parse(data["updatedAt"].ToString()) : null);
        }

        public int CompareTo(object obj)
        {
            var other = obj as Box;
            var diff = 0;
            if (boxId == null && boxId == other.boxId)
            {
                // null and null
            }
            else
            {
                diff += boxId.CompareTo(other.boxId);
            }
            if (prizeTableName == null && prizeTableName == other.prizeTableName)
            {
                // null and null
            }
            else
            {
                diff += prizeTableName.CompareTo(other.prizeTableName);
            }
            if (userId == null && userId == other.userId)
            {
                // null and null
            }
            else
            {
                diff += userId.CompareTo(other.userId);
            }
            if (drawnIndexes == null && drawnIndexes == other.drawnIndexes)
            {
                // null and null
            }
            else
            {
                diff += drawnIndexes.Count - other.drawnIndexes.Count;
                for (var i = 0; i < drawnIndexes.Count; i++)
                {
                    diff += (int)(drawnIndexes[i] - other.drawnIndexes[i]);
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