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
using Gs2.Gs2Dictionary.Model;
using Gs2.Util.LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Dictionary.Request
{
	[Preserve]
	[System.Serializable]
	public class CreateNamespaceRequest : Gs2Request<CreateNamespaceRequest>
	{

        /** ネームスペース名 */
		[UnityEngine.SerializeField]
        public string name;

        /**
         * ネームスペース名を設定
         *
         * @param name ネームスペース名
         * @return this
         */
        public CreateNamespaceRequest WithName(string name) {
            this.name = name;
            return this;
        }


        /** ネームスペースの説明 */
		[UnityEngine.SerializeField]
        public string description;

        /**
         * ネームスペースの説明を設定
         *
         * @param description ネームスペースの説明
         * @return this
         */
        public CreateNamespaceRequest WithDescription(string description) {
            this.description = description;
            return this;
        }


        /** エントリー登録時に実行するスクリプト */
		[UnityEngine.SerializeField]
        public global::Gs2.Gs2Dictionary.Model.ScriptSetting entryScript;

        /**
         * エントリー登録時に実行するスクリプトを設定
         *
         * @param entryScript エントリー登録時に実行するスクリプト
         * @return this
         */
        public CreateNamespaceRequest WithEntryScript(global::Gs2.Gs2Dictionary.Model.ScriptSetting entryScript) {
            this.entryScript = entryScript;
            return this;
        }


        /** 登録済みのエントリーを再度登録しようとした時に実行するスクリプト */
		[UnityEngine.SerializeField]
        public global::Gs2.Gs2Dictionary.Model.ScriptSetting duplicateEntryScript;

        /**
         * 登録済みのエントリーを再度登録しようとした時に実行するスクリプトを設定
         *
         * @param duplicateEntryScript 登録済みのエントリーを再度登録しようとした時に実行するスクリプト
         * @return this
         */
        public CreateNamespaceRequest WithDuplicateEntryScript(global::Gs2.Gs2Dictionary.Model.ScriptSetting duplicateEntryScript) {
            this.duplicateEntryScript = duplicateEntryScript;
            return this;
        }


        /** ログの出力設定 */
		[UnityEngine.SerializeField]
        public global::Gs2.Gs2Dictionary.Model.LogSetting logSetting;

        /**
         * ログの出力設定を設定
         *
         * @param logSetting ログの出力設定
         * @return this
         */
        public CreateNamespaceRequest WithLogSetting(global::Gs2.Gs2Dictionary.Model.LogSetting logSetting) {
            this.logSetting = logSetting;
            return this;
        }


    	[Preserve]
        public static CreateNamespaceRequest FromDict(JsonData data)
        {
            return new CreateNamespaceRequest {
                name = data.Keys.Contains("name") && data["name"] != null ? data["name"].ToString(): null,
                description = data.Keys.Contains("description") && data["description"] != null ? data["description"].ToString(): null,
                entryScript = data.Keys.Contains("entryScript") && data["entryScript"] != null ? global::Gs2.Gs2Dictionary.Model.ScriptSetting.FromDict(data["entryScript"]) : null,
                duplicateEntryScript = data.Keys.Contains("duplicateEntryScript") && data["duplicateEntryScript"] != null ? global::Gs2.Gs2Dictionary.Model.ScriptSetting.FromDict(data["duplicateEntryScript"]) : null,
                logSetting = data.Keys.Contains("logSetting") && data["logSetting"] != null ? global::Gs2.Gs2Dictionary.Model.LogSetting.FromDict(data["logSetting"]) : null,
            };
        }

	}
}