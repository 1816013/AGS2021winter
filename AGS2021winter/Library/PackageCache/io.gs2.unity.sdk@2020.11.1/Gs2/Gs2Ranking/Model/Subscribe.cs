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

namespace Gs2.Gs2Ranking.Model
{
	[Preserve]
	public class Subscribe : IComparable
	{

        /** 購読 */
        public string subscribeId { set; get; }

        /**
         * 購読を設定
         *
         * @param subscribeId 購読
         * @return this
         */
        public Subscribe WithSubscribeId(string subscribeId) {
            this.subscribeId = subscribeId;
            return this;
        }

        /** カテゴリ名 */
        public string categoryName { set; get; }

        /**
         * カテゴリ名を設定
         *
         * @param categoryName カテゴリ名
         * @return this
         */
        public Subscribe WithCategoryName(string categoryName) {
            this.categoryName = categoryName;
            return this;
        }

        /** 購読するユーザID */
        public string userId { set; get; }

        /**
         * 購読するユーザIDを設定
         *
         * @param userId 購読するユーザID
         * @return this
         */
        public Subscribe WithUserId(string userId) {
            this.userId = userId;
            return this;
        }

        /** 購読されるユーザIDリスト */
        public List<string> targetUserIds { set; get; }

        /**
         * 購読されるユーザIDリストを設定
         *
         * @param targetUserIds 購読されるユーザIDリスト
         * @return this
         */
        public Subscribe WithTargetUserIds(List<string> targetUserIds) {
            this.targetUserIds = targetUserIds;
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
        public Subscribe WithCreatedAt(long? createdAt) {
            this.createdAt = createdAt;
            return this;
        }

        public void WriteJson(JsonWriter writer)
        {
            writer.WriteObjectStart();
            if(this.subscribeId != null)
            {
                writer.WritePropertyName("subscribeId");
                writer.Write(this.subscribeId);
            }
            if(this.categoryName != null)
            {
                writer.WritePropertyName("categoryName");
                writer.Write(this.categoryName);
            }
            if(this.userId != null)
            {
                writer.WritePropertyName("userId");
                writer.Write(this.userId);
            }
            if(this.targetUserIds != null)
            {
                writer.WritePropertyName("targetUserIds");
                writer.WriteArrayStart();
                foreach(var item in this.targetUserIds)
                {
                    writer.Write(item);
                }
                writer.WriteArrayEnd();
            }
            if(this.createdAt.HasValue)
            {
                writer.WritePropertyName("createdAt");
                writer.Write(this.createdAt.Value);
            }
            writer.WriteObjectEnd();
        }

    public static string GetCategoryNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):ranking:(?<namespaceName>.*):user:(?<userId>.*):subscribe:category:(?<categoryName>.*)");
        if (!match.Groups["categoryName"].Success)
        {
            return null;
        }
        return match.Groups["categoryName"].Value;
    }

    public static string GetUserIdFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):ranking:(?<namespaceName>.*):user:(?<userId>.*):subscribe:category:(?<categoryName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):ranking:(?<namespaceName>.*):user:(?<userId>.*):subscribe:category:(?<categoryName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):ranking:(?<namespaceName>.*):user:(?<userId>.*):subscribe:category:(?<categoryName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):ranking:(?<namespaceName>.*):user:(?<userId>.*):subscribe:category:(?<categoryName>.*)");
        if (!match.Groups["region"].Success)
        {
            return null;
        }
        return match.Groups["region"].Value;
    }

    	[Preserve]
        public static Subscribe FromDict(JsonData data)
        {
            return new Subscribe()
                .WithSubscribeId(data.Keys.Contains("subscribeId") && data["subscribeId"] != null ? data["subscribeId"].ToString() : null)
                .WithCategoryName(data.Keys.Contains("categoryName") && data["categoryName"] != null ? data["categoryName"].ToString() : null)
                .WithUserId(data.Keys.Contains("userId") && data["userId"] != null ? data["userId"].ToString() : null)
                .WithTargetUserIds(data.Keys.Contains("targetUserIds") && data["targetUserIds"] != null ? data["targetUserIds"].Cast<JsonData>().Select(value =>
                    {
                        return value.ToString();
                    }
                ).ToList() : null)
                .WithCreatedAt(data.Keys.Contains("createdAt") && data["createdAt"] != null ? (long?)long.Parse(data["createdAt"].ToString()) : null);
        }

        public int CompareTo(object obj)
        {
            var other = obj as Subscribe;
            var diff = 0;
            if (subscribeId == null && subscribeId == other.subscribeId)
            {
                // null and null
            }
            else
            {
                diff += subscribeId.CompareTo(other.subscribeId);
            }
            if (categoryName == null && categoryName == other.categoryName)
            {
                // null and null
            }
            else
            {
                diff += categoryName.CompareTo(other.categoryName);
            }
            if (userId == null && userId == other.userId)
            {
                // null and null
            }
            else
            {
                diff += userId.CompareTo(other.userId);
            }
            if (targetUserIds == null && targetUserIds == other.targetUserIds)
            {
                // null and null
            }
            else
            {
                diff += targetUserIds.Count - other.targetUserIds.Count;
                for (var i = 0; i < targetUserIds.Count; i++)
                {
                    diff += targetUserIds[i].CompareTo(other.targetUserIds[i]);
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
            return diff;
        }
	}
}