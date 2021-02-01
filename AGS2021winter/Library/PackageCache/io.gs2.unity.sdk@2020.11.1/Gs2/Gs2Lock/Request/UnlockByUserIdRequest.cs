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
using Gs2.Gs2Lock.Model;
using Gs2.Util.LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Lock.Request
{
	[Preserve]
	[System.Serializable]
	public class UnlockByUserIdRequest : Gs2Request<UnlockByUserIdRequest>
	{

        /** カテゴリー名 */
		[UnityEngine.SerializeField]
        public string namespaceName;

        /**
         * カテゴリー名を設定
         *
         * @param namespaceName カテゴリー名
         * @return this
         */
        public UnlockByUserIdRequest WithNamespaceName(string namespaceName) {
            this.namespaceName = namespaceName;
            return this;
        }


        /** プロパティID */
		[UnityEngine.SerializeField]
        public string propertyId;

        /**
         * プロパティIDを設定
         *
         * @param propertyId プロパティID
         * @return this
         */
        public UnlockByUserIdRequest WithPropertyId(string propertyId) {
            this.propertyId = propertyId;
            return this;
        }


        /** ユーザーID */
		[UnityEngine.SerializeField]
        public string userId;

        /**
         * ユーザーIDを設定
         *
         * @param userId ユーザーID
         * @return this
         */
        public UnlockByUserIdRequest WithUserId(string userId) {
            this.userId = userId;
            return this;
        }


        /** ロックを取得したトランザクションID */
		[UnityEngine.SerializeField]
        public string transactionId;

        /**
         * ロックを取得したトランザクションIDを設定
         *
         * @param transactionId ロックを取得したトランザクションID
         * @return this
         */
        public UnlockByUserIdRequest WithTransactionId(string transactionId) {
            this.transactionId = transactionId;
            return this;
        }


        /** 重複実行回避機能に使用するID */
		[UnityEngine.SerializeField]
        public string duplicationAvoider;

        /**
         * 重複実行回避機能に使用するIDを設定
         *
         * @param duplicationAvoider 重複実行回避機能に使用するID
         * @return this
         */
        public UnlockByUserIdRequest WithDuplicationAvoider(string duplicationAvoider) {
            this.duplicationAvoider = duplicationAvoider;
            return this;
        }


    	[Preserve]
        public static UnlockByUserIdRequest FromDict(JsonData data)
        {
            return new UnlockByUserIdRequest {
                namespaceName = data.Keys.Contains("namespaceName") && data["namespaceName"] != null ? data["namespaceName"].ToString(): null,
                propertyId = data.Keys.Contains("propertyId") && data["propertyId"] != null ? data["propertyId"].ToString(): null,
                userId = data.Keys.Contains("userId") && data["userId"] != null ? data["userId"].ToString(): null,
                transactionId = data.Keys.Contains("transactionId") && data["transactionId"] != null ? data["transactionId"].ToString(): null,
                duplicationAvoider = data.Keys.Contains("duplicationAvoider") && data["duplicationAvoider"] != null ? data["duplicationAvoider"].ToString(): null,
            };
        }

	}
}