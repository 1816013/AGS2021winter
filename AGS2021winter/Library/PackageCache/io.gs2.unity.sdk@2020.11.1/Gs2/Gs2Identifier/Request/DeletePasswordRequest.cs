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
using Gs2.Gs2Identifier.Model;
using Gs2.Util.LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Identifier.Request
{
	[Preserve]
	[System.Serializable]
	public class DeletePasswordRequest : Gs2Request<DeletePasswordRequest>
	{

        /** ユーザー名 */
		[UnityEngine.SerializeField]
        public string userName;

        /**
         * ユーザー名を設定
         *
         * @param userName ユーザー名
         * @return this
         */
        public DeletePasswordRequest WithUserName(string userName) {
            this.userName = userName;
            return this;
        }


    	[Preserve]
        public static DeletePasswordRequest FromDict(JsonData data)
        {
            return new DeletePasswordRequest {
                userName = data.Keys.Contains("userName") && data["userName"] != null ? data["userName"].ToString(): null,
            };
        }

	}
}