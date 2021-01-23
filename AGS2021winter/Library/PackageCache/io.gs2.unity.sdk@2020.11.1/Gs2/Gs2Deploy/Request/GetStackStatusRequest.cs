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
using Gs2.Gs2Deploy.Model;
using Gs2.Util.LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Deploy.Request
{
	[Preserve]
	[System.Serializable]
	public class GetStackStatusRequest : Gs2Request<GetStackStatusRequest>
	{

        /** スタック名 */
		[UnityEngine.SerializeField]
        public string stackName;

        /**
         * スタック名を設定
         *
         * @param stackName スタック名
         * @return this
         */
        public GetStackStatusRequest WithStackName(string stackName) {
            this.stackName = stackName;
            return this;
        }


    	[Preserve]
        public static GetStackStatusRequest FromDict(JsonData data)
        {
            return new GetStackStatusRequest {
                stackName = data.Keys.Contains("stackName") && data["stackName"] != null ? data["stackName"].ToString(): null,
            };
        }

	}
}