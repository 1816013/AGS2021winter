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
using Gs2.Core.Control;
using Gs2.Core.Model;
using Gs2.Gs2Quest.Model;
using Gs2.Util.LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Quest.Request
{
	[Preserve]
	[System.Serializable]
	public class UpdateQuestGroupModelMasterRequest : Gs2Request<UpdateQuestGroupModelMasterRequest>
	{

        /** カテゴリ名 */
		[UnityEngine.SerializeField]
        public string namespaceName;

        /**
         * カテゴリ名を設定
         *
         * @param namespaceName カテゴリ名
         * @return this
         */
        public UpdateQuestGroupModelMasterRequest WithNamespaceName(string namespaceName) {
            this.namespaceName = namespaceName;
            return this;
        }


        /** クエストグループモデル名 */
		[UnityEngine.SerializeField]
        public string questGroupName;

        /**
         * クエストグループモデル名を設定
         *
         * @param questGroupName クエストグループモデル名
         * @return this
         */
        public UpdateQuestGroupModelMasterRequest WithQuestGroupName(string questGroupName) {
            this.questGroupName = questGroupName;
            return this;
        }


        /** クエストグループマスターの説明 */
		[UnityEngine.SerializeField]
        public string description;

        /**
         * クエストグループマスターの説明を設定
         *
         * @param description クエストグループマスターの説明
         * @return this
         */
        public UpdateQuestGroupModelMasterRequest WithDescription(string description) {
            this.description = description;
            return this;
        }


        /** クエストグループのメタデータ */
		[UnityEngine.SerializeField]
        public string metadata;

        /**
         * クエストグループのメタデータを設定
         *
         * @param metadata クエストグループのメタデータ
         * @return this
         */
        public UpdateQuestGroupModelMasterRequest WithMetadata(string metadata) {
            this.metadata = metadata;
            return this;
        }


        /** 挑戦可能な期間を指定するイベントマスター のGRN */
		[UnityEngine.SerializeField]
        public string challengePeriodEventId;

        /**
         * 挑戦可能な期間を指定するイベントマスター のGRNを設定
         *
         * @param challengePeriodEventId 挑戦可能な期間を指定するイベントマスター のGRN
         * @return this
         */
        public UpdateQuestGroupModelMasterRequest WithChallengePeriodEventId(string challengePeriodEventId) {
            this.challengePeriodEventId = challengePeriodEventId;
            return this;
        }


    	[Preserve]
        public static UpdateQuestGroupModelMasterRequest FromDict(JsonData data)
        {
            return new UpdateQuestGroupModelMasterRequest {
                namespaceName = data.Keys.Contains("namespaceName") && data["namespaceName"] != null ? data["namespaceName"].ToString(): null,
                questGroupName = data.Keys.Contains("questGroupName") && data["questGroupName"] != null ? data["questGroupName"].ToString(): null,
                description = data.Keys.Contains("description") && data["description"] != null ? data["description"].ToString(): null,
                metadata = data.Keys.Contains("metadata") && data["metadata"] != null ? data["metadata"].ToString(): null,
                challengePeriodEventId = data.Keys.Contains("challengePeriodEventId") && data["challengePeriodEventId"] != null ? data["challengePeriodEventId"].ToString(): null,
            };
        }

	}
}