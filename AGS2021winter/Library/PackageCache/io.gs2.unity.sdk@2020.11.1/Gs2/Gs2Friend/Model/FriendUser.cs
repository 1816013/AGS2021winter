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

namespace Gs2.Gs2Friend.Model
{
	[Preserve]
	public class FriendUser : IComparable
	{

        /** ユーザーID */
        public string userId { set; get; }

        /**
         * ユーザーIDを設定
         *
         * @param userId ユーザーID
         * @return this
         */
        public FriendUser WithUserId(string userId) {
            this.userId = userId;
            return this;
        }

        /** 公開されるプロフィール */
        public string publicProfile { set; get; }

        /**
         * 公開されるプロフィールを設定
         *
         * @param publicProfile 公開されるプロフィール
         * @return this
         */
        public FriendUser WithPublicProfile(string publicProfile) {
            this.publicProfile = publicProfile;
            return this;
        }

        /** フレンド向けに公開されるプロフィール */
        public string friendProfile { set; get; }

        /**
         * フレンド向けに公開されるプロフィールを設定
         *
         * @param friendProfile フレンド向けに公開されるプロフィール
         * @return this
         */
        public FriendUser WithFriendProfile(string friendProfile) {
            this.friendProfile = friendProfile;
            return this;
        }

        public void WriteJson(JsonWriter writer)
        {
            writer.WriteObjectStart();
            if(this.userId != null)
            {
                writer.WritePropertyName("userId");
                writer.Write(this.userId);
            }
            if(this.publicProfile != null)
            {
                writer.WritePropertyName("publicProfile");
                writer.Write(this.publicProfile);
            }
            if(this.friendProfile != null)
            {
                writer.WritePropertyName("friendProfile");
                writer.Write(this.friendProfile);
            }
            writer.WriteObjectEnd();
        }

    	[Preserve]
        public static FriendUser FromDict(JsonData data)
        {
            return new FriendUser()
                .WithUserId(data.Keys.Contains("userId") && data["userId"] != null ? data["userId"].ToString() : null)
                .WithPublicProfile(data.Keys.Contains("publicProfile") && data["publicProfile"] != null ? data["publicProfile"].ToString() : null)
                .WithFriendProfile(data.Keys.Contains("friendProfile") && data["friendProfile"] != null ? data["friendProfile"].ToString() : null);
        }

        public int CompareTo(object obj)
        {
            var other = obj as FriendUser;
            var diff = 0;
            if (userId == null && userId == other.userId)
            {
                // null and null
            }
            else
            {
                diff += userId.CompareTo(other.userId);
            }
            if (publicProfile == null && publicProfile == other.publicProfile)
            {
                // null and null
            }
            else
            {
                diff += publicProfile.CompareTo(other.publicProfile);
            }
            if (friendProfile == null && friendProfile == other.friendProfile)
            {
                // null and null
            }
            else
            {
                diff += friendProfile.CompareTo(other.friendProfile);
            }
            return diff;
        }
	}
}