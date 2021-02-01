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

namespace Gs2.Gs2Gateway.Model
{
	[Preserve]
	public class WebSocketSession : IComparable
	{

        /** コネクションID */
        public string connectionId { set; get; }

        /**
         * コネクションIDを設定
         *
         * @param connectionId コネクションID
         * @return this
         */
        public WebSocketSession WithConnectionId(string connectionId) {
            this.connectionId = connectionId;
            return this;
        }

        /** API ID */
        public string apiId { set; get; }

        /**
         * API IDを設定
         *
         * @param apiId API ID
         * @return this
         */
        public WebSocketSession WithApiId(string apiId) {
            this.apiId = apiId;
            return this;
        }

        /** オーナーID */
        public string ownerId { set; get; }

        /**
         * オーナーIDを設定
         *
         * @param ownerId オーナーID
         * @return this
         */
        public WebSocketSession WithOwnerId(string ownerId) {
            this.ownerId = ownerId;
            return this;
        }

        /** ネームスペース名 */
        public string namespaceName { set; get; }

        /**
         * ネームスペース名を設定
         *
         * @param namespaceName ネームスペース名
         * @return this
         */
        public WebSocketSession WithNamespaceName(string namespaceName) {
            this.namespaceName = namespaceName;
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
        public WebSocketSession WithUserId(string userId) {
            this.userId = userId;
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
        public WebSocketSession WithCreatedAt(long? createdAt) {
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
        public WebSocketSession WithUpdatedAt(long? updatedAt) {
            this.updatedAt = updatedAt;
            return this;
        }

        public void WriteJson(JsonWriter writer)
        {
            writer.WriteObjectStart();
            if(this.connectionId != null)
            {
                writer.WritePropertyName("connectionId");
                writer.Write(this.connectionId);
            }
            if(this.apiId != null)
            {
                writer.WritePropertyName("apiId");
                writer.Write(this.apiId);
            }
            if(this.ownerId != null)
            {
                writer.WritePropertyName("ownerId");
                writer.Write(this.ownerId);
            }
            if(this.namespaceName != null)
            {
                writer.WritePropertyName("namespaceName");
                writer.Write(this.namespaceName);
            }
            if(this.userId != null)
            {
                writer.WritePropertyName("userId");
                writer.Write(this.userId);
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

    	[Preserve]
        public static WebSocketSession FromDict(JsonData data)
        {
            return new WebSocketSession()
                .WithConnectionId(data.Keys.Contains("connectionId") && data["connectionId"] != null ? data["connectionId"].ToString() : null)
                .WithApiId(data.Keys.Contains("apiId") && data["apiId"] != null ? data["apiId"].ToString() : null)
                .WithOwnerId(data.Keys.Contains("ownerId") && data["ownerId"] != null ? data["ownerId"].ToString() : null)
                .WithNamespaceName(data.Keys.Contains("namespaceName") && data["namespaceName"] != null ? data["namespaceName"].ToString() : null)
                .WithUserId(data.Keys.Contains("userId") && data["userId"] != null ? data["userId"].ToString() : null)
                .WithCreatedAt(data.Keys.Contains("createdAt") && data["createdAt"] != null ? (long?)long.Parse(data["createdAt"].ToString()) : null)
                .WithUpdatedAt(data.Keys.Contains("updatedAt") && data["updatedAt"] != null ? (long?)long.Parse(data["updatedAt"].ToString()) : null);
        }

        public int CompareTo(object obj)
        {
            var other = obj as WebSocketSession;
            var diff = 0;
            if (connectionId == null && connectionId == other.connectionId)
            {
                // null and null
            }
            else
            {
                diff += connectionId.CompareTo(other.connectionId);
            }
            if (apiId == null && apiId == other.apiId)
            {
                // null and null
            }
            else
            {
                diff += apiId.CompareTo(other.apiId);
            }
            if (ownerId == null && ownerId == other.ownerId)
            {
                // null and null
            }
            else
            {
                diff += ownerId.CompareTo(other.ownerId);
            }
            if (namespaceName == null && namespaceName == other.namespaceName)
            {
                // null and null
            }
            else
            {
                diff += namespaceName.CompareTo(other.namespaceName);
            }
            if (userId == null && userId == other.userId)
            {
                // null and null
            }
            else
            {
                diff += userId.CompareTo(other.userId);
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