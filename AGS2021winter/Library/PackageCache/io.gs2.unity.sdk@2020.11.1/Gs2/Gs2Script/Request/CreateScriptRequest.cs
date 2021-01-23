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
using Gs2.Gs2Script.Model;
using Gs2.Util.LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Script.Request
{
	[Preserve]
	[System.Serializable]
	public class CreateScriptRequest : Gs2Request<CreateScriptRequest>
	{

        /** ネームスペース名 */
		[UnityEngine.SerializeField]
        public string namespaceName;

        /**
         * ネームスペース名を設定
         *
         * @param namespaceName ネームスペース名
         * @return this
         */
        public CreateScriptRequest WithNamespaceName(string namespaceName) {
            this.namespaceName = namespaceName;
            return this;
        }


        /** スクリプト名 */
		[UnityEngine.SerializeField]
        public string name;

        /**
         * スクリプト名を設定
         *
         * @param name スクリプト名
         * @return this
         */
        public CreateScriptRequest WithName(string name) {
            this.name = name;
            return this;
        }


        /** 説明文 */
		[UnityEngine.SerializeField]
        public string description;

        /**
         * 説明文を設定
         *
         * @param description 説明文
         * @return this
         */
        public CreateScriptRequest WithDescription(string description) {
            this.description = description;
            return this;
        }


        /** Luaスクリプト */
		[UnityEngine.SerializeField]
        public string script;

        /**
         * Luaスクリプトを設定
         *
         * @param script Luaスクリプト
         * @return this
         */
        public CreateScriptRequest WithScript(string script) {
            this.script = script;
            return this;
        }


    	[Preserve]
        public static CreateScriptRequest FromDict(JsonData data)
        {
            return new CreateScriptRequest {
                namespaceName = data.Keys.Contains("namespaceName") && data["namespaceName"] != null ? data["namespaceName"].ToString(): null,
                name = data.Keys.Contains("name") && data["name"] != null ? data["name"].ToString(): null,
                description = data.Keys.Contains("description") && data["description"] != null ? data["description"].ToString(): null,
                script = data.Keys.Contains("script") && data["script"] != null ? data["script"].ToString(): null,
            };
        }

	}
}