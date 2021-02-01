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
using Gs2.Gs2Version.Model;
using Gs2.Util.LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Version.Request
{
	[Preserve]
	[System.Serializable]
	public class CalculateSignatureRequest : Gs2Request<CalculateSignatureRequest>
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
        public CalculateSignatureRequest WithNamespaceName(string namespaceName) {
            this.namespaceName = namespaceName;
            return this;
        }


        /** バージョンの種類名 */
		[UnityEngine.SerializeField]
        public string versionName;

        /**
         * バージョンの種類名を設定
         *
         * @param versionName バージョンの種類名
         * @return this
         */
        public CalculateSignatureRequest WithVersionName(string versionName) {
            this.versionName = versionName;
            return this;
        }


        /** バージョン */
		[UnityEngine.SerializeField]
        public global::Gs2.Gs2Version.Model.Version_ version;

        /**
         * バージョンを設定
         *
         * @param version バージョン
         * @return this
         */
        public CalculateSignatureRequest WithVersion(global::Gs2.Gs2Version.Model.Version_ version) {
            this.version = version;
            return this;
        }


    	[Preserve]
        public static CalculateSignatureRequest FromDict(JsonData data)
        {
            return new CalculateSignatureRequest {
                namespaceName = data.Keys.Contains("namespaceName") && data["namespaceName"] != null ? data["namespaceName"].ToString(): null,
                versionName = data.Keys.Contains("versionName") && data["versionName"] != null ? data["versionName"].ToString(): null,
                version = data.Keys.Contains("version") && data["version"] != null ? global::Gs2.Gs2Version.Model.Version_.FromDict(data["version"]) : null,
            };
        }

	}
}