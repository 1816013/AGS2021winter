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

namespace Gs2.Gs2Experience.Model
{
	[Preserve]
	public class Status : IComparable
	{

        /** ステータス */
        public string statusId { set; get; }

        /**
         * ステータスを設定
         *
         * @param statusId ステータス
         * @return this
         */
        public Status WithStatusId(string statusId) {
            this.statusId = statusId;
            return this;
        }

        /** 経験値の種類の名前 */
        public string experienceName { set; get; }

        /**
         * 経験値の種類の名前を設定
         *
         * @param experienceName 経験値の種類の名前
         * @return this
         */
        public Status WithExperienceName(string experienceName) {
            this.experienceName = experienceName;
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
        public Status WithUserId(string userId) {
            this.userId = userId;
            return this;
        }

        /** プロパティID */
        public string propertyId { set; get; }

        /**
         * プロパティIDを設定
         *
         * @param propertyId プロパティID
         * @return this
         */
        public Status WithPropertyId(string propertyId) {
            this.propertyId = propertyId;
            return this;
        }

        /** 累計獲得経験値 */
        public long? experienceValue { set; get; }

        /**
         * 累計獲得経験値を設定
         *
         * @param experienceValue 累計獲得経験値
         * @return this
         */
        public Status WithExperienceValue(long? experienceValue) {
            this.experienceValue = experienceValue;
            return this;
        }

        /** 現在のランク */
        public long? rankValue { set; get; }

        /**
         * 現在のランクを設定
         *
         * @param rankValue 現在のランク
         * @return this
         */
        public Status WithRankValue(long? rankValue) {
            this.rankValue = rankValue;
            return this;
        }

        /** 現在のランクキャップ */
        public long? rankCapValue { set; get; }

        /**
         * 現在のランクキャップを設定
         *
         * @param rankCapValue 現在のランクキャップ
         * @return this
         */
        public Status WithRankCapValue(long? rankCapValue) {
            this.rankCapValue = rankCapValue;
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
        public Status WithCreatedAt(long? createdAt) {
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
        public Status WithUpdatedAt(long? updatedAt) {
            this.updatedAt = updatedAt;
            return this;
        }

        public void WriteJson(JsonWriter writer)
        {
            writer.WriteObjectStart();
            if(this.statusId != null)
            {
                writer.WritePropertyName("statusId");
                writer.Write(this.statusId);
            }
            if(this.experienceName != null)
            {
                writer.WritePropertyName("experienceName");
                writer.Write(this.experienceName);
            }
            if(this.userId != null)
            {
                writer.WritePropertyName("userId");
                writer.Write(this.userId);
            }
            if(this.propertyId != null)
            {
                writer.WritePropertyName("propertyId");
                writer.Write(this.propertyId);
            }
            if(this.experienceValue.HasValue)
            {
                writer.WritePropertyName("experienceValue");
                writer.Write(this.experienceValue.Value);
            }
            if(this.rankValue.HasValue)
            {
                writer.WritePropertyName("rankValue");
                writer.Write(this.rankValue.Value);
            }
            if(this.rankCapValue.HasValue)
            {
                writer.WritePropertyName("rankCapValue");
                writer.Write(this.rankCapValue.Value);
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

    public static string GetPropertyIdFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):experience:(?<namespaceName>.*):user:(?<userId>.*):experienceModel:(?<experienceName>.*):property:(?<propertyId>.*)");
        if (!match.Groups["propertyId"].Success)
        {
            return null;
        }
        return match.Groups["propertyId"].Value;
    }

    public static string GetExperienceNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):experience:(?<namespaceName>.*):user:(?<userId>.*):experienceModel:(?<experienceName>.*):property:(?<propertyId>.*)");
        if (!match.Groups["experienceName"].Success)
        {
            return null;
        }
        return match.Groups["experienceName"].Value;
    }

    public static string GetUserIdFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):experience:(?<namespaceName>.*):user:(?<userId>.*):experienceModel:(?<experienceName>.*):property:(?<propertyId>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):experience:(?<namespaceName>.*):user:(?<userId>.*):experienceModel:(?<experienceName>.*):property:(?<propertyId>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):experience:(?<namespaceName>.*):user:(?<userId>.*):experienceModel:(?<experienceName>.*):property:(?<propertyId>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):experience:(?<namespaceName>.*):user:(?<userId>.*):experienceModel:(?<experienceName>.*):property:(?<propertyId>.*)");
        if (!match.Groups["region"].Success)
        {
            return null;
        }
        return match.Groups["region"].Value;
    }

    	[Preserve]
        public static Status FromDict(JsonData data)
        {
            return new Status()
                .WithStatusId(data.Keys.Contains("statusId") && data["statusId"] != null ? data["statusId"].ToString() : null)
                .WithExperienceName(data.Keys.Contains("experienceName") && data["experienceName"] != null ? data["experienceName"].ToString() : null)
                .WithUserId(data.Keys.Contains("userId") && data["userId"] != null ? data["userId"].ToString() : null)
                .WithPropertyId(data.Keys.Contains("propertyId") && data["propertyId"] != null ? data["propertyId"].ToString() : null)
                .WithExperienceValue(data.Keys.Contains("experienceValue") && data["experienceValue"] != null ? (long?)long.Parse(data["experienceValue"].ToString()) : null)
                .WithRankValue(data.Keys.Contains("rankValue") && data["rankValue"] != null ? (long?)long.Parse(data["rankValue"].ToString()) : null)
                .WithRankCapValue(data.Keys.Contains("rankCapValue") && data["rankCapValue"] != null ? (long?)long.Parse(data["rankCapValue"].ToString()) : null)
                .WithCreatedAt(data.Keys.Contains("createdAt") && data["createdAt"] != null ? (long?)long.Parse(data["createdAt"].ToString()) : null)
                .WithUpdatedAt(data.Keys.Contains("updatedAt") && data["updatedAt"] != null ? (long?)long.Parse(data["updatedAt"].ToString()) : null);
        }

        public int CompareTo(object obj)
        {
            var other = obj as Status;
            var diff = 0;
            if (statusId == null && statusId == other.statusId)
            {
                // null and null
            }
            else
            {
                diff += statusId.CompareTo(other.statusId);
            }
            if (experienceName == null && experienceName == other.experienceName)
            {
                // null and null
            }
            else
            {
                diff += experienceName.CompareTo(other.experienceName);
            }
            if (userId == null && userId == other.userId)
            {
                // null and null
            }
            else
            {
                diff += userId.CompareTo(other.userId);
            }
            if (propertyId == null && propertyId == other.propertyId)
            {
                // null and null
            }
            else
            {
                diff += propertyId.CompareTo(other.propertyId);
            }
            if (experienceValue == null && experienceValue == other.experienceValue)
            {
                // null and null
            }
            else
            {
                diff += (int)(experienceValue - other.experienceValue);
            }
            if (rankValue == null && rankValue == other.rankValue)
            {
                // null and null
            }
            else
            {
                diff += (int)(rankValue - other.rankValue);
            }
            if (rankCapValue == null && rankCapValue == other.rankCapValue)
            {
                // null and null
            }
            else
            {
                diff += (int)(rankCapValue - other.rankCapValue);
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