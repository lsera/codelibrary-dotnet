/* 
 * Zuora API Reference
 *
 *  # Introduction  Welcome to the reference for the Zuora REST API!  <a href=\"http://en.wikipedia.org/wiki/REST_API\" target=\"_blank\">REST</a> is a web-service protocol that lends itself to rapid development by using everyday HTTP and JSON technology.  The Zuora REST API provides a broad set of operations and resources that:  * Enable Web Storefront integration between your websites. * Support self-service subscriber sign-ups and account management. * Process revenue schedules through custom revenue rule models.  ## Endpoints  The Zuora REST services are provided via the following endpoints.  | Service                 | Base URL for REST Endpoints                                                                                                                                         | |- -- -- -- -- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --| | Production REST service | https://rest.zuora.com/v1                                                                                                                                           | | Sandbox REST service    | https://rest.apisandbox.zuora.com/v1                                                                                                                                |  The production service provides access to your live user data. The sandbox environment is a good place to test your code without affecting real-world data. To use it, you must be provisioned with a sandbox tenant - your Zuora representative can help with this if needed.  ## Accessing the API  If you have a Zuora tenant, you already have access the the API.  If you don't have a Zuora tenant, go to <a href=\"https://www.zuora.com/resource/zuora-test-drive\" target=\"_blank\">https://www.zuora.com/resource/zuora-test-drive</a> and sign up for a trial tenant. The tenant comes with seed data, such as a sample product catalog.   We recommend that you <a href=\"https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/Manage_Users/Create_an_API_User\" target=\"_blank\">create an API user</a> specifically for making API calls. Don't log in to the Zuora UI with this account. Logging in to the UI enables a security feature that periodically expires the account's password, which may eventually cause authentication failures with the API. Note that a user role does not have write access to Zuora REST services unless it has the API Write Access permission as described in those instructions.   # Authentication  There are three ways to authenticate:  * Use an authorization cookie. The cookie authorizes the user to make calls to the REST API for the duration specified in  **Administration > Security Policies > Session timeout**. The cookie expiration time is reset with this duration after every call to the REST API. To obtain a cookie, call the REST  `connections` resource with the following API user information:     *   ID     *   password     *   entity Id or entity name (Only for [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity \"Multi-entity\"). See \"Entity Id and Entity Name\" below for more information.)  *   Include the following parameters in the request header, which re-authenticates the user with each request:     *   `apiAccessKeyId`     *   `apiSecretAccessKey`     *   `entityId` or `entityName` (Only for [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity \"Multi-entity\"). See \"Entity Id and Entity Name\" below for more information.) *   For CORS-enabled APIs only: Include a 'single-use' token in the request header, which re-authenticates the user with each request. See below for more details.   ## Entity Id and Entity Name  The `entityId` and `entityName`  parameters are only used for  [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity).  The  `entityId` parameter specifies the Id of the entity that you want to access. The `entityName` parameter specifies the [name of the entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity/B_Introduction_to_Entity_and_Entity_Hierarchy#Name_and_Display_Name \"Introduction to Entity and Entity Hierarchy\") that you want to access. Note that you must have permission to access the entity. You can get the entity Id and entity name through the REST GET Entities call.  You can specify either the  `entityId` or `entityName` parameter in the authentication to access and view an entity.  *   If both `entityId` and `entityName` are specified in the authentication, an error occurs.  *   If neither  `entityId` nor  `entityName` is specified in the authentication, you will log in to the entity in which your user account is created.   See [API User Authentication](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity/A_Overview_of_Multi-entity#API_User_Authentication \"Zuora Multi-entity\") for more information.  ## Token Authentication for CORS-Enabled APIs  The CORS mechanism enables REST API calls to Zuora to be made directly from your customer's browser, with all credit card and security information transmitted directly to Zuora. This minimizes your PCI compliance burden, allows you to implement advanced validation on your payment forms, and makes your payment forms look just like any other part of your website.  For security reasons, instead of using cookies, an API request via CORS uses **tokens** for authentication.  The token method of authentication is only designed for use with requests that must originate from your customer's browser; **it should not be considered a replacement to the existing cookie authentication** mechanism.  See [Zuora CORS REST ](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics/G_CORS_REST \"Zuora CORS REST\")for details on how CORS works and how you can begin to implement customer calls to the Zuora REST APIs. See  [HMAC Signatures](/BC_Developers/REST_API/B_REST_API_reference/HMAC_Signatures \"HMAC Signatures\") for details on the HMAC method that returns the authentication token.    # Requests and Responses   ## Request IDs  As a general rule, when asked to supply a \"key\" for an account or subscription (accountKey, account-key, subscriptionKey, subscription-key), you can provide either the actual ID or the number of the entity.  ## HTTP Request Body  Most of the parameters and data accompanying your requests will be contained in the body of the HTTP request.  The Zuora REST API accepts JSON in the HTTP request body.  No other data format (e.g., XML) is supported.   ## Testing a Request  Use a third party client, such as Postman or Advanced REST Client, to test the Zuora REST API.  You can test the Zuora REST API from the Zuora sandbox or  production service. If connecting to the production service, bear in mind that you are working with your live production data, not sample data or test data.  ## Testing with Credit Cards  Sooner or later it will probably be necessary to test some transactions that involve credit cards. For suggestions on how to handle this, see [Going Live With Your Payment Gateway](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/C_Managing_Payment_Gateways/B_Going_Live_Payment_Gateways#Testing_with_Credit_Cards \"C_Zuora_User_Guides/A_Billing_and_Payments/M_Payment_Gateways/C_Managing_Payment_Gateways/B_Going_Live_Payment_Gateways#Testing_with_Credit_Cards\").       ## Error Handling  Responses and error codes are detailed in [Responses and errors](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics/3_Responses_and_errors \"Responses and errors\").    # Pagination  When retrieving information (using GET methods), the optional `pageSize` query parameter sets the maximum number of rows to return in a response. The maximum is `40`; larger values are treated as `40`. If this value is empty or invalid, `pageSize` typically defaults to `10`.  The default value for the maximum number of rows retrieved can be overridden at the method level.  If more rows are available, the response will include a `nextPage` element, which contains a URL for requesting the next page.  If this value is not provided, no more rows are available. No \"previous page\" element is explicitly provided; to support backward paging, use the previous call.  ## Array Size  For data items that are not paginated, the REST API supports arrays of up to 300 rows.  Thus, for instance, repeated pagination can retrieve thousands of customer accounts, but within any account an array of no more than 300 rate plans is returned.   # API Versions  The Zuora REST API is in version control. Versioning ensures that Zuora REST API changes are backward compatible. Zuora uses a major and minor version nomenclature to manage changes. By specifying a version in a REST request, you can get expected responses regardless of future changes to the API.   ## Major Version  The major version number of the REST API appears in the REST URL. Currently, Zuora only supports the **v1** major version. For example,  `POST https://rest.zuora.com/v1/subscriptions` .   ## Minor Version  Zuora uses minor versions for the REST API to control small changes. For example, a field in a REST method is deprecated and a new field is used to replace it.   Some fields in the REST methods are supported as of minor versions. If a field is not noted with a minor version, this field is available for all minor versions. If a field is noted with a minor version, this field is in version control. You must specify the supported minor version in the request header to process without an error.   If a field is in version control, it is either with a minimum minor version or a maximum minor version, or both of them. You can only use this field with the minor version between the minimum and the maximum minor versions. For example, the  `invoiceCollect` field in the POST Subscription method is in version control and its maximum minor version is 189.0. You can only use this field with the minor version 189.0 or earlier.  The supported minor versions are not serial, see [Zuora REST API Minor Version History](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics/Zuora_REST_API_Minor_Version_History \"Zuora REST API Minor Version History\") for the fields and their supported minor versions. In our REST API documentation, if a field or feature requires a minor version number, we note that in the field description.  You only need to specify the version number when you use the fields require a minor version. To specify the minor version, set the `zuora-version` parameter to the minor version number in the request header for the request call. For example, the `collect` field is in 196.0 minor version. If you want to use this field for the POST Subscription method, set the  `zuora-version` parameter to `196.0` in the request header. The `zuora-version` parameter is case sensitive.   For all the REST API fields, by default, if the minor version is not specified in the request header, Zuora will use the minimum minor version of the REST API to avoid breaking your integration.     # Zuora Object Model The following diagram presents a high-level view of the key Zuora objects. Click the image to open it in a new tab to resize it.  <a href=\"https://www.zuora.com/wp-content/uploads/2016/10/ZuoraERD-compressor-1.jpeg\" target=\"_blank\"><img src=\"https://www.zuora.com/wp-content/uploads/2016/10/ZuoraERD-compressor-1.jpeg\" alt=\"Zuora Object Model Diagram\"></a> 
 *
 * OpenAPI spec version: 0.0.1
 * Contact: docs@zuora.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace IO.Swagger.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISubscriptionsApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get subscriptions by key
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to retrieve detailed information about a specified subscription in the latest version. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Possible values are:   * a subscription number   * a subscription ID </param>
        /// <param name="chargeDetail"> The segmented rate plan charges. When an amendment results in a change to a charge, Zuora creates a segmented rate plan charge. Use this field to track segment charges.  Possible values are:   * __last-segment__: (Default) The last rate plan charge on the subscription. The last rate plan charge is the last one in the order of time on the subscription rather than the most recent changed charge on the subscription.  * __current-segment__: The segmented charge that is active on today’s date (effectiveStartDate &lt;&#x3D; today’s date &lt; effectiveEndDate).    * __all-segments__: All the segmented charges.   * __specific-segment&amp;as-of-date&#x3D;date__: The segmented charge that is active on a date you specified (effectiveStartDate &lt;&#x3D; specific date &lt; effectiveEndDate). The format of the date is yyyy-mm-dd.  (optional)</param>
        /// <returns>GETSubscriptionTypeWithSuccess</returns>
        GETSubscriptionTypeWithSuccess GETOneSubscription (string subscriptionKey, string chargeDetail = null);

        /// <summary>
        /// Get subscriptions by key
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to retrieve detailed information about a specified subscription in the latest version. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Possible values are:   * a subscription number   * a subscription ID </param>
        /// <param name="chargeDetail"> The segmented rate plan charges. When an amendment results in a change to a charge, Zuora creates a segmented rate plan charge. Use this field to track segment charges.  Possible values are:   * __last-segment__: (Default) The last rate plan charge on the subscription. The last rate plan charge is the last one in the order of time on the subscription rather than the most recent changed charge on the subscription.  * __current-segment__: The segmented charge that is active on today’s date (effectiveStartDate &lt;&#x3D; today’s date &lt; effectiveEndDate).    * __all-segments__: All the segmented charges.   * __specific-segment&amp;as-of-date&#x3D;date__: The segmented charge that is active on a date you specified (effectiveStartDate &lt;&#x3D; specific date &lt; effectiveEndDate). The format of the date is yyyy-mm-dd.  (optional)</param>
        /// <returns>ApiResponse of GETSubscriptionTypeWithSuccess</returns>
        ApiResponse<GETSubscriptionTypeWithSuccess> GETOneSubscriptionWithHttpInfo (string subscriptionKey, string chargeDetail = null);
        /// <summary>
        /// Get subscriptions by account
        /// </summary>
        /// <remarks>
        /// Retrieves all subscriptions associated with the specified account. Zuora only returns the latest version of the subscriptions.  Subscription data is returned in reverse chronological order based on &#x60;updatedDate&#x60;. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountKey"> Possible values are: * an account number * an account ID </param>
        /// <param name="chargeDetail">The segmented rate plan charges.  When an amendment results in a change to a charge, Zuora creates a segmented rate plan charge. Use this field to track segment charges.  Possible values are:  * &#x60;last-segment&#x60;: (Default) The last rate plan charge on the subscription. The last rate plan charge is the last one in the order of time on the subscription rather than the most recent updated charge on the subscription. * &#x60;current-segment&#x60;: The segmented charge that is active on today’s date (**effectiveStartDate** &lt;&#x3D; today’s date &lt; **effectiveEndDate**). * &#x60;all-segments&#x60;: All the segmented charges. * &#x60;specific-segment&amp;as-of-date&#x3D;date&#x60;: The segmented charge that is active on a date you specified (**effectiveStartDate** &lt;&#x3D; specific date &lt; **effectiveEndDate**). The format of the date is yyyy-mm-dd.  (optional)</param>
        /// <returns>GETSubscriptionWrapper</returns>
        GETSubscriptionWrapper GETSubscription (string accountKey, string chargeDetail = null);

        /// <summary>
        /// Get subscriptions by account
        /// </summary>
        /// <remarks>
        /// Retrieves all subscriptions associated with the specified account. Zuora only returns the latest version of the subscriptions.  Subscription data is returned in reverse chronological order based on &#x60;updatedDate&#x60;. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountKey"> Possible values are: * an account number * an account ID </param>
        /// <param name="chargeDetail">The segmented rate plan charges.  When an amendment results in a change to a charge, Zuora creates a segmented rate plan charge. Use this field to track segment charges.  Possible values are:  * &#x60;last-segment&#x60;: (Default) The last rate plan charge on the subscription. The last rate plan charge is the last one in the order of time on the subscription rather than the most recent updated charge on the subscription. * &#x60;current-segment&#x60;: The segmented charge that is active on today’s date (**effectiveStartDate** &lt;&#x3D; today’s date &lt; **effectiveEndDate**). * &#x60;all-segments&#x60;: All the segmented charges. * &#x60;specific-segment&amp;as-of-date&#x3D;date&#x60;: The segmented charge that is active on a date you specified (**effectiveStartDate** &lt;&#x3D; specific date &lt; **effectiveEndDate**). The format of the date is yyyy-mm-dd.  (optional)</param>
        /// <returns>ApiResponse of GETSubscriptionWrapper</returns>
        ApiResponse<GETSubscriptionWrapper> GETSubscriptionWithHttpInfo (string accountKey, string chargeDetail = null);
        /// <summary>
        /// Create subscription
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to create a new subscription for an existing customer account.  ## Notes If invoiceCollect is &#x60;true&#x60;, the call will not return success &#x3D; &#x60;true&#x60; unless the subscription, invoice, and payment are all successful.  Default values for **customerAcceptanceDate** and **serviceActivationDate** are set as follows.  |        | serviceActivationDate(SA) specified          | serviceActivationDate (SA) NOT specified  | | - -- -- -- -- -- -- |:- -- -- -- -- -- --:| - -- --:| | customerAcceptanceDate (CA) specified| SA uses value in the request call; CA uses value in the request call| CA uses value in the request call;SA uses CE as default | | customerAcceptanceDate (CA) NOT specified      | SA uses value in the request call; CA uses SA as default |   SA and CA use CE as default | 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>POSTSubscriptionResponseType</returns>
        POSTSubscriptionResponseType POSTSubscription (POSTSubscriptionType request, string zuoraVersion = null);

        /// <summary>
        /// Create subscription
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to create a new subscription for an existing customer account.  ## Notes If invoiceCollect is &#x60;true&#x60;, the call will not return success &#x3D; &#x60;true&#x60; unless the subscription, invoice, and payment are all successful.  Default values for **customerAcceptanceDate** and **serviceActivationDate** are set as follows.  |        | serviceActivationDate(SA) specified          | serviceActivationDate (SA) NOT specified  | | - -- -- -- -- -- -- |:- -- -- -- -- -- --:| - -- --:| | customerAcceptanceDate (CA) specified| SA uses value in the request call; CA uses value in the request call| CA uses value in the request call;SA uses CE as default | | customerAcceptanceDate (CA) NOT specified      | SA uses value in the request call; CA uses SA as default |   SA and CA use CE as default | 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>ApiResponse of POSTSubscriptionResponseType</returns>
        ApiResponse<POSTSubscriptionResponseType> POSTSubscriptionWithHttpInfo (POSTSubscriptionType request, string zuoraVersion = null);
        /// <summary>
        /// Cancel subscription
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to cancel an active subscription. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID. Subscription status must be &#x60;Active&#x60;.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>POSTSubscriptionCancellationResponseType</returns>
        POSTSubscriptionCancellationResponseType POSTSubscriptionCancellation (string subscriptionKey, POSTSubscriptionCancellationType request, string zuoraVersion = null);

        /// <summary>
        /// Cancel subscription
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to cancel an active subscription. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID. Subscription status must be &#x60;Active&#x60;.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>ApiResponse of POSTSubscriptionCancellationResponseType</returns>
        ApiResponse<POSTSubscriptionCancellationResponseType> POSTSubscriptionCancellationWithHttpInfo (string subscriptionKey, POSTSubscriptionCancellationType request, string zuoraVersion = null);
        /// <summary>
        /// Preview subscription
        /// </summary>
        /// <remarks>
        /// The REST API reference describes how to create a new subscription in preview mode. This call does not require a valid customer account. It can be used to show potential new customers a preview of a subscription with complete details and charges before creating an account, or to let existing customers preview a subscription with all charges before committing.  ## Notes Default values for **customerAcceptanceDate** and **serviceActivationDate** are set as follows.  |        | serviceActivationDate (SA) specified          | serviceActivationDate (SA) NOT specified  | | - -- -- -- -- -- -- |:- -- -- -- -- -- --:| - -- --:| | customerAcceptanceDate (CA) specified      | SA uses value in the request call; CA uses value in the request call| CA uses value in the request call;SA uses CE as default | | customerAcceptanceDate (CA) NOT specified      | SA uses value in the request call; CA uses SA as default |   SA and CA use CE as default | 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>POSTSubscriptionPreviewResponseType</returns>
        POSTSubscriptionPreviewResponseType POSTSubscriptionPreview (POSTSubscriptionPreviewType request);

        /// <summary>
        /// Preview subscription
        /// </summary>
        /// <remarks>
        /// The REST API reference describes how to create a new subscription in preview mode. This call does not require a valid customer account. It can be used to show potential new customers a preview of a subscription with complete details and charges before creating an account, or to let existing customers preview a subscription with all charges before committing.  ## Notes Default values for **customerAcceptanceDate** and **serviceActivationDate** are set as follows.  |        | serviceActivationDate (SA) specified          | serviceActivationDate (SA) NOT specified  | | - -- -- -- -- -- -- |:- -- -- -- -- -- --:| - -- --:| | customerAcceptanceDate (CA) specified      | SA uses value in the request call; CA uses value in the request call| CA uses value in the request call;SA uses CE as default | | customerAcceptanceDate (CA) NOT specified      | SA uses value in the request call; CA uses SA as default |   SA and CA use CE as default | 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>ApiResponse of POSTSubscriptionPreviewResponseType</returns>
        ApiResponse<POSTSubscriptionPreviewResponseType> POSTSubscriptionPreviewWithHttpInfo (POSTSubscriptionPreviewType request);
        /// <summary>
        /// Renew subscription
        /// </summary>
        /// <remarks>
        /// Renews a termed subscription using existing renewal terms. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>PUTRenewSubscriptionResponseType</returns>
        PUTRenewSubscriptionResponseType PUTRenewSubscription (string subscriptionKey, PUTRenewSubscriptionType request, string zuoraVersion = null);

        /// <summary>
        /// Renew subscription
        /// </summary>
        /// <remarks>
        /// Renews a termed subscription using existing renewal terms. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>ApiResponse of PUTRenewSubscriptionResponseType</returns>
        ApiResponse<PUTRenewSubscriptionResponseType> PUTRenewSubscriptionWithHttpInfo (string subscriptionKey, PUTRenewSubscriptionType request, string zuoraVersion = null);
        /// <summary>
        /// Update subscription
        /// </summary>
        /// <remarks>
        /// Use this call to make the following kinds of changes to a subscription:   * Add a note   * Change the renewal term or auto-renewal flag   * Change the term length or change between evergreen and termed   * Add a new product rate plan   * Remove an existing subscription rate plan   * Change the quantity or price of an existing subscription rate plan  ## Notes * The Update Subscription call creates a new subscription, which has the old subscription number but a new subscription ID.  The old subscription is canceled but remains in the system. * In one request, this call can make:   * Up to 9 combined add, update, and remove changes   * No more than 1 change to terms &amp; conditions * Updates are performed in the following sequence:   1. First change the notes on the existing subscription, if requested.   2. Then change the terms and conditions, if requested.   3. Then perform the remaining amendments based upon the effective dates specified. If multiple amendments have the same contract-effective dates, then execute adds before updates, and updates before removes. * The update operation is atomic. If any of the updates fails, the entire operation is rolled back.  ## Override a Tiered Price There are two ways you override a tiered price:  * Override a specific tier number For example: &#x60;tiers[{tier:1,price:8},{tier:2,price:6}]&#x60;  * Override the entire tier structure For example:  &#x60;tiers[{tier:1,price:8,startingUnit:1,endingUnit:100,priceFormat:\&quot;FlatFee\&quot;}, {tier:2,price:6,startingUnit:101,priceFormat:\&quot;FlatFee\&quot;}]&#x60;  If you just override a specific tier, do not include the &#x60;startingUnit&#x60; field in the request. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>PUTSubscriptionResponseType</returns>
        PUTSubscriptionResponseType PUTSubscription (string subscriptionKey, PUTSubscriptionType request, string zuoraVersion = null);

        /// <summary>
        /// Update subscription
        /// </summary>
        /// <remarks>
        /// Use this call to make the following kinds of changes to a subscription:   * Add a note   * Change the renewal term or auto-renewal flag   * Change the term length or change between evergreen and termed   * Add a new product rate plan   * Remove an existing subscription rate plan   * Change the quantity or price of an existing subscription rate plan  ## Notes * The Update Subscription call creates a new subscription, which has the old subscription number but a new subscription ID.  The old subscription is canceled but remains in the system. * In one request, this call can make:   * Up to 9 combined add, update, and remove changes   * No more than 1 change to terms &amp; conditions * Updates are performed in the following sequence:   1. First change the notes on the existing subscription, if requested.   2. Then change the terms and conditions, if requested.   3. Then perform the remaining amendments based upon the effective dates specified. If multiple amendments have the same contract-effective dates, then execute adds before updates, and updates before removes. * The update operation is atomic. If any of the updates fails, the entire operation is rolled back.  ## Override a Tiered Price There are two ways you override a tiered price:  * Override a specific tier number For example: &#x60;tiers[{tier:1,price:8},{tier:2,price:6}]&#x60;  * Override the entire tier structure For example:  &#x60;tiers[{tier:1,price:8,startingUnit:1,endingUnit:100,priceFormat:\&quot;FlatFee\&quot;}, {tier:2,price:6,startingUnit:101,priceFormat:\&quot;FlatFee\&quot;}]&#x60;  If you just override a specific tier, do not include the &#x60;startingUnit&#x60; field in the request. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>ApiResponse of PUTSubscriptionResponseType</returns>
        ApiResponse<PUTSubscriptionResponseType> PUTSubscriptionWithHttpInfo (string subscriptionKey, PUTSubscriptionType request, string zuoraVersion = null);
        /// <summary>
        /// Resume subscription
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to resume a suspended subscription.   This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://suport.zuora.com).  
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID. Subscription status must be Active.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>PUTSubscriptionResumeResponseType</returns>
        PUTSubscriptionResumeResponseType PUTSubscriptionResume (string subscriptionKey, PUTSubscriptionResumeType request, string zuoraVersion = null);

        /// <summary>
        /// Resume subscription
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to resume a suspended subscription.   This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://suport.zuora.com).  
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID. Subscription status must be Active.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>ApiResponse of PUTSubscriptionResumeResponseType</returns>
        ApiResponse<PUTSubscriptionResumeResponseType> PUTSubscriptionResumeWithHttpInfo (string subscriptionKey, PUTSubscriptionResumeType request, string zuoraVersion = null);
        /// <summary>
        /// Suspend subscription
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to suspend an active subscription.   This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://suport.zuora.com). 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID. Subscription status must be Active.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>PUTSubscriptionSuspendResponseType</returns>
        PUTSubscriptionSuspendResponseType PUTSubscriptionSuspend (string subscriptionKey, PUTSubscriptionSuspendType request, string zuoraVersion = null);

        /// <summary>
        /// Suspend subscription
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to suspend an active subscription.   This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://suport.zuora.com). 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID. Subscription status must be Active.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>ApiResponse of PUTSubscriptionSuspendResponseType</returns>
        ApiResponse<PUTSubscriptionSuspendResponseType> PUTSubscriptionSuspendWithHttpInfo (string subscriptionKey, PUTSubscriptionSuspendType request, string zuoraVersion = null);
        /// <summary>
        /// CRUD: Delete Subscription
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <returns>ProxyDeleteResponse</returns>
        ProxyDeleteResponse ProxyDELETESubscription (string id);

        /// <summary>
        /// CRUD: Delete Subscription
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <returns>ApiResponse of ProxyDeleteResponse</returns>
        ApiResponse<ProxyDeleteResponse> ProxyDELETESubscriptionWithHttpInfo (string id);
        /// <summary>
        /// CRUD: Retrieve Subscription
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="fields">Object fields to return (optional)</param>
        /// <returns>ProxyGetSubscription</returns>
        ProxyGetSubscription ProxyGETSubscription (string id, string fields = null);

        /// <summary>
        /// CRUD: Retrieve Subscription
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="fields">Object fields to return (optional)</param>
        /// <returns>ApiResponse of ProxyGetSubscription</returns>
        ApiResponse<ProxyGetSubscription> ProxyGETSubscriptionWithHttpInfo (string id, string fields = null);
        /// <summary>
        /// CRUD: Create Subscription
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createRequest"></param>
        /// <returns>ProxyCreateOrModifyResponse</returns>
        ProxyCreateOrModifyResponse ProxyPOSTSubscription (ProxyCreateSubscription createRequest);

        /// <summary>
        /// CRUD: Create Subscription
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createRequest"></param>
        /// <returns>ApiResponse of ProxyCreateOrModifyResponse</returns>
        ApiResponse<ProxyCreateOrModifyResponse> ProxyPOSTSubscriptionWithHttpInfo (ProxyCreateSubscription createRequest);
        /// <summary>
        /// CRUD: Update Subscription
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="modifyRequest"></param>
        /// <returns>ProxyCreateOrModifyResponse</returns>
        ProxyCreateOrModifyResponse ProxyPUTSubscription (string id, ProxyModifySubscription modifyRequest);

        /// <summary>
        /// CRUD: Update Subscription
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="modifyRequest"></param>
        /// <returns>ApiResponse of ProxyCreateOrModifyResponse</returns>
        ApiResponse<ProxyCreateOrModifyResponse> ProxyPUTSubscriptionWithHttpInfo (string id, ProxyModifySubscription modifyRequest);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Get subscriptions by key
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to retrieve detailed information about a specified subscription in the latest version. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Possible values are:   * a subscription number   * a subscription ID </param>
        /// <param name="chargeDetail"> The segmented rate plan charges. When an amendment results in a change to a charge, Zuora creates a segmented rate plan charge. Use this field to track segment charges.  Possible values are:   * __last-segment__: (Default) The last rate plan charge on the subscription. The last rate plan charge is the last one in the order of time on the subscription rather than the most recent changed charge on the subscription.  * __current-segment__: The segmented charge that is active on today’s date (effectiveStartDate &lt;&#x3D; today’s date &lt; effectiveEndDate).    * __all-segments__: All the segmented charges.   * __specific-segment&amp;as-of-date&#x3D;date__: The segmented charge that is active on a date you specified (effectiveStartDate &lt;&#x3D; specific date &lt; effectiveEndDate). The format of the date is yyyy-mm-dd.  (optional)</param>
        /// <returns>Task of GETSubscriptionTypeWithSuccess</returns>
        System.Threading.Tasks.Task<GETSubscriptionTypeWithSuccess> GETOneSubscriptionAsync (string subscriptionKey, string chargeDetail = null);

        /// <summary>
        /// Get subscriptions by key
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to retrieve detailed information about a specified subscription in the latest version. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Possible values are:   * a subscription number   * a subscription ID </param>
        /// <param name="chargeDetail"> The segmented rate plan charges. When an amendment results in a change to a charge, Zuora creates a segmented rate plan charge. Use this field to track segment charges.  Possible values are:   * __last-segment__: (Default) The last rate plan charge on the subscription. The last rate plan charge is the last one in the order of time on the subscription rather than the most recent changed charge on the subscription.  * __current-segment__: The segmented charge that is active on today’s date (effectiveStartDate &lt;&#x3D; today’s date &lt; effectiveEndDate).    * __all-segments__: All the segmented charges.   * __specific-segment&amp;as-of-date&#x3D;date__: The segmented charge that is active on a date you specified (effectiveStartDate &lt;&#x3D; specific date &lt; effectiveEndDate). The format of the date is yyyy-mm-dd.  (optional)</param>
        /// <returns>Task of ApiResponse (GETSubscriptionTypeWithSuccess)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETSubscriptionTypeWithSuccess>> GETOneSubscriptionAsyncWithHttpInfo (string subscriptionKey, string chargeDetail = null);
        /// <summary>
        /// Get subscriptions by account
        /// </summary>
        /// <remarks>
        /// Retrieves all subscriptions associated with the specified account. Zuora only returns the latest version of the subscriptions.  Subscription data is returned in reverse chronological order based on &#x60;updatedDate&#x60;. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountKey"> Possible values are: * an account number * an account ID </param>
        /// <param name="chargeDetail">The segmented rate plan charges.  When an amendment results in a change to a charge, Zuora creates a segmented rate plan charge. Use this field to track segment charges.  Possible values are:  * &#x60;last-segment&#x60;: (Default) The last rate plan charge on the subscription. The last rate plan charge is the last one in the order of time on the subscription rather than the most recent updated charge on the subscription. * &#x60;current-segment&#x60;: The segmented charge that is active on today’s date (**effectiveStartDate** &lt;&#x3D; today’s date &lt; **effectiveEndDate**). * &#x60;all-segments&#x60;: All the segmented charges. * &#x60;specific-segment&amp;as-of-date&#x3D;date&#x60;: The segmented charge that is active on a date you specified (**effectiveStartDate** &lt;&#x3D; specific date &lt; **effectiveEndDate**). The format of the date is yyyy-mm-dd.  (optional)</param>
        /// <returns>Task of GETSubscriptionWrapper</returns>
        System.Threading.Tasks.Task<GETSubscriptionWrapper> GETSubscriptionAsync (string accountKey, string chargeDetail = null);

        /// <summary>
        /// Get subscriptions by account
        /// </summary>
        /// <remarks>
        /// Retrieves all subscriptions associated with the specified account. Zuora only returns the latest version of the subscriptions.  Subscription data is returned in reverse chronological order based on &#x60;updatedDate&#x60;. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountKey"> Possible values are: * an account number * an account ID </param>
        /// <param name="chargeDetail">The segmented rate plan charges.  When an amendment results in a change to a charge, Zuora creates a segmented rate plan charge. Use this field to track segment charges.  Possible values are:  * &#x60;last-segment&#x60;: (Default) The last rate plan charge on the subscription. The last rate plan charge is the last one in the order of time on the subscription rather than the most recent updated charge on the subscription. * &#x60;current-segment&#x60;: The segmented charge that is active on today’s date (**effectiveStartDate** &lt;&#x3D; today’s date &lt; **effectiveEndDate**). * &#x60;all-segments&#x60;: All the segmented charges. * &#x60;specific-segment&amp;as-of-date&#x3D;date&#x60;: The segmented charge that is active on a date you specified (**effectiveStartDate** &lt;&#x3D; specific date &lt; **effectiveEndDate**). The format of the date is yyyy-mm-dd.  (optional)</param>
        /// <returns>Task of ApiResponse (GETSubscriptionWrapper)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETSubscriptionWrapper>> GETSubscriptionAsyncWithHttpInfo (string accountKey, string chargeDetail = null);
        /// <summary>
        /// Create subscription
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to create a new subscription for an existing customer account.  ## Notes If invoiceCollect is &#x60;true&#x60;, the call will not return success &#x3D; &#x60;true&#x60; unless the subscription, invoice, and payment are all successful.  Default values for **customerAcceptanceDate** and **serviceActivationDate** are set as follows.  |        | serviceActivationDate(SA) specified          | serviceActivationDate (SA) NOT specified  | | - -- -- -- -- -- -- |:- -- -- -- -- -- --:| - -- --:| | customerAcceptanceDate (CA) specified| SA uses value in the request call; CA uses value in the request call| CA uses value in the request call;SA uses CE as default | | customerAcceptanceDate (CA) NOT specified      | SA uses value in the request call; CA uses SA as default |   SA and CA use CE as default | 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>Task of POSTSubscriptionResponseType</returns>
        System.Threading.Tasks.Task<POSTSubscriptionResponseType> POSTSubscriptionAsync (POSTSubscriptionType request, string zuoraVersion = null);

        /// <summary>
        /// Create subscription
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to create a new subscription for an existing customer account.  ## Notes If invoiceCollect is &#x60;true&#x60;, the call will not return success &#x3D; &#x60;true&#x60; unless the subscription, invoice, and payment are all successful.  Default values for **customerAcceptanceDate** and **serviceActivationDate** are set as follows.  |        | serviceActivationDate(SA) specified          | serviceActivationDate (SA) NOT specified  | | - -- -- -- -- -- -- |:- -- -- -- -- -- --:| - -- --:| | customerAcceptanceDate (CA) specified| SA uses value in the request call; CA uses value in the request call| CA uses value in the request call;SA uses CE as default | | customerAcceptanceDate (CA) NOT specified      | SA uses value in the request call; CA uses SA as default |   SA and CA use CE as default | 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>Task of ApiResponse (POSTSubscriptionResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<POSTSubscriptionResponseType>> POSTSubscriptionAsyncWithHttpInfo (POSTSubscriptionType request, string zuoraVersion = null);
        /// <summary>
        /// Cancel subscription
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to cancel an active subscription. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID. Subscription status must be &#x60;Active&#x60;.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>Task of POSTSubscriptionCancellationResponseType</returns>
        System.Threading.Tasks.Task<POSTSubscriptionCancellationResponseType> POSTSubscriptionCancellationAsync (string subscriptionKey, POSTSubscriptionCancellationType request, string zuoraVersion = null);

        /// <summary>
        /// Cancel subscription
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to cancel an active subscription. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID. Subscription status must be &#x60;Active&#x60;.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>Task of ApiResponse (POSTSubscriptionCancellationResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<POSTSubscriptionCancellationResponseType>> POSTSubscriptionCancellationAsyncWithHttpInfo (string subscriptionKey, POSTSubscriptionCancellationType request, string zuoraVersion = null);
        /// <summary>
        /// Preview subscription
        /// </summary>
        /// <remarks>
        /// The REST API reference describes how to create a new subscription in preview mode. This call does not require a valid customer account. It can be used to show potential new customers a preview of a subscription with complete details and charges before creating an account, or to let existing customers preview a subscription with all charges before committing.  ## Notes Default values for **customerAcceptanceDate** and **serviceActivationDate** are set as follows.  |        | serviceActivationDate (SA) specified          | serviceActivationDate (SA) NOT specified  | | - -- -- -- -- -- -- |:- -- -- -- -- -- --:| - -- --:| | customerAcceptanceDate (CA) specified      | SA uses value in the request call; CA uses value in the request call| CA uses value in the request call;SA uses CE as default | | customerAcceptanceDate (CA) NOT specified      | SA uses value in the request call; CA uses SA as default |   SA and CA use CE as default | 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>Task of POSTSubscriptionPreviewResponseType</returns>
        System.Threading.Tasks.Task<POSTSubscriptionPreviewResponseType> POSTSubscriptionPreviewAsync (POSTSubscriptionPreviewType request);

        /// <summary>
        /// Preview subscription
        /// </summary>
        /// <remarks>
        /// The REST API reference describes how to create a new subscription in preview mode. This call does not require a valid customer account. It can be used to show potential new customers a preview of a subscription with complete details and charges before creating an account, or to let existing customers preview a subscription with all charges before committing.  ## Notes Default values for **customerAcceptanceDate** and **serviceActivationDate** are set as follows.  |        | serviceActivationDate (SA) specified          | serviceActivationDate (SA) NOT specified  | | - -- -- -- -- -- -- |:- -- -- -- -- -- --:| - -- --:| | customerAcceptanceDate (CA) specified      | SA uses value in the request call; CA uses value in the request call| CA uses value in the request call;SA uses CE as default | | customerAcceptanceDate (CA) NOT specified      | SA uses value in the request call; CA uses SA as default |   SA and CA use CE as default | 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (POSTSubscriptionPreviewResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<POSTSubscriptionPreviewResponseType>> POSTSubscriptionPreviewAsyncWithHttpInfo (POSTSubscriptionPreviewType request);
        /// <summary>
        /// Renew subscription
        /// </summary>
        /// <remarks>
        /// Renews a termed subscription using existing renewal terms. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>Task of PUTRenewSubscriptionResponseType</returns>
        System.Threading.Tasks.Task<PUTRenewSubscriptionResponseType> PUTRenewSubscriptionAsync (string subscriptionKey, PUTRenewSubscriptionType request, string zuoraVersion = null);

        /// <summary>
        /// Renew subscription
        /// </summary>
        /// <remarks>
        /// Renews a termed subscription using existing renewal terms. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>Task of ApiResponse (PUTRenewSubscriptionResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<PUTRenewSubscriptionResponseType>> PUTRenewSubscriptionAsyncWithHttpInfo (string subscriptionKey, PUTRenewSubscriptionType request, string zuoraVersion = null);
        /// <summary>
        /// Update subscription
        /// </summary>
        /// <remarks>
        /// Use this call to make the following kinds of changes to a subscription:   * Add a note   * Change the renewal term or auto-renewal flag   * Change the term length or change between evergreen and termed   * Add a new product rate plan   * Remove an existing subscription rate plan   * Change the quantity or price of an existing subscription rate plan  ## Notes * The Update Subscription call creates a new subscription, which has the old subscription number but a new subscription ID.  The old subscription is canceled but remains in the system. * In one request, this call can make:   * Up to 9 combined add, update, and remove changes   * No more than 1 change to terms &amp; conditions * Updates are performed in the following sequence:   1. First change the notes on the existing subscription, if requested.   2. Then change the terms and conditions, if requested.   3. Then perform the remaining amendments based upon the effective dates specified. If multiple amendments have the same contract-effective dates, then execute adds before updates, and updates before removes. * The update operation is atomic. If any of the updates fails, the entire operation is rolled back.  ## Override a Tiered Price There are two ways you override a tiered price:  * Override a specific tier number For example: &#x60;tiers[{tier:1,price:8},{tier:2,price:6}]&#x60;  * Override the entire tier structure For example:  &#x60;tiers[{tier:1,price:8,startingUnit:1,endingUnit:100,priceFormat:\&quot;FlatFee\&quot;}, {tier:2,price:6,startingUnit:101,priceFormat:\&quot;FlatFee\&quot;}]&#x60;  If you just override a specific tier, do not include the &#x60;startingUnit&#x60; field in the request. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>Task of PUTSubscriptionResponseType</returns>
        System.Threading.Tasks.Task<PUTSubscriptionResponseType> PUTSubscriptionAsync (string subscriptionKey, PUTSubscriptionType request, string zuoraVersion = null);

        /// <summary>
        /// Update subscription
        /// </summary>
        /// <remarks>
        /// Use this call to make the following kinds of changes to a subscription:   * Add a note   * Change the renewal term or auto-renewal flag   * Change the term length or change between evergreen and termed   * Add a new product rate plan   * Remove an existing subscription rate plan   * Change the quantity or price of an existing subscription rate plan  ## Notes * The Update Subscription call creates a new subscription, which has the old subscription number but a new subscription ID.  The old subscription is canceled but remains in the system. * In one request, this call can make:   * Up to 9 combined add, update, and remove changes   * No more than 1 change to terms &amp; conditions * Updates are performed in the following sequence:   1. First change the notes on the existing subscription, if requested.   2. Then change the terms and conditions, if requested.   3. Then perform the remaining amendments based upon the effective dates specified. If multiple amendments have the same contract-effective dates, then execute adds before updates, and updates before removes. * The update operation is atomic. If any of the updates fails, the entire operation is rolled back.  ## Override a Tiered Price There are two ways you override a tiered price:  * Override a specific tier number For example: &#x60;tiers[{tier:1,price:8},{tier:2,price:6}]&#x60;  * Override the entire tier structure For example:  &#x60;tiers[{tier:1,price:8,startingUnit:1,endingUnit:100,priceFormat:\&quot;FlatFee\&quot;}, {tier:2,price:6,startingUnit:101,priceFormat:\&quot;FlatFee\&quot;}]&#x60;  If you just override a specific tier, do not include the &#x60;startingUnit&#x60; field in the request. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>Task of ApiResponse (PUTSubscriptionResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<PUTSubscriptionResponseType>> PUTSubscriptionAsyncWithHttpInfo (string subscriptionKey, PUTSubscriptionType request, string zuoraVersion = null);
        /// <summary>
        /// Resume subscription
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to resume a suspended subscription.   This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://suport.zuora.com).  
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID. Subscription status must be Active.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>Task of PUTSubscriptionResumeResponseType</returns>
        System.Threading.Tasks.Task<PUTSubscriptionResumeResponseType> PUTSubscriptionResumeAsync (string subscriptionKey, PUTSubscriptionResumeType request, string zuoraVersion = null);

        /// <summary>
        /// Resume subscription
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to resume a suspended subscription.   This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://suport.zuora.com).  
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID. Subscription status must be Active.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>Task of ApiResponse (PUTSubscriptionResumeResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<PUTSubscriptionResumeResponseType>> PUTSubscriptionResumeAsyncWithHttpInfo (string subscriptionKey, PUTSubscriptionResumeType request, string zuoraVersion = null);
        /// <summary>
        /// Suspend subscription
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to suspend an active subscription.   This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://suport.zuora.com). 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID. Subscription status must be Active.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>Task of PUTSubscriptionSuspendResponseType</returns>
        System.Threading.Tasks.Task<PUTSubscriptionSuspendResponseType> PUTSubscriptionSuspendAsync (string subscriptionKey, PUTSubscriptionSuspendType request, string zuoraVersion = null);

        /// <summary>
        /// Suspend subscription
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to suspend an active subscription.   This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://suport.zuora.com). 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID. Subscription status must be Active.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>Task of ApiResponse (PUTSubscriptionSuspendResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<PUTSubscriptionSuspendResponseType>> PUTSubscriptionSuspendAsyncWithHttpInfo (string subscriptionKey, PUTSubscriptionSuspendType request, string zuoraVersion = null);
        /// <summary>
        /// CRUD: Delete Subscription
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <returns>Task of ProxyDeleteResponse</returns>
        System.Threading.Tasks.Task<ProxyDeleteResponse> ProxyDELETESubscriptionAsync (string id);

        /// <summary>
        /// CRUD: Delete Subscription
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <returns>Task of ApiResponse (ProxyDeleteResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ProxyDeleteResponse>> ProxyDELETESubscriptionAsyncWithHttpInfo (string id);
        /// <summary>
        /// CRUD: Retrieve Subscription
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="fields">Object fields to return (optional)</param>
        /// <returns>Task of ProxyGetSubscription</returns>
        System.Threading.Tasks.Task<ProxyGetSubscription> ProxyGETSubscriptionAsync (string id, string fields = null);

        /// <summary>
        /// CRUD: Retrieve Subscription
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="fields">Object fields to return (optional)</param>
        /// <returns>Task of ApiResponse (ProxyGetSubscription)</returns>
        System.Threading.Tasks.Task<ApiResponse<ProxyGetSubscription>> ProxyGETSubscriptionAsyncWithHttpInfo (string id, string fields = null);
        /// <summary>
        /// CRUD: Create Subscription
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createRequest"></param>
        /// <returns>Task of ProxyCreateOrModifyResponse</returns>
        System.Threading.Tasks.Task<ProxyCreateOrModifyResponse> ProxyPOSTSubscriptionAsync (ProxyCreateSubscription createRequest);

        /// <summary>
        /// CRUD: Create Subscription
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createRequest"></param>
        /// <returns>Task of ApiResponse (ProxyCreateOrModifyResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ProxyCreateOrModifyResponse>> ProxyPOSTSubscriptionAsyncWithHttpInfo (ProxyCreateSubscription createRequest);
        /// <summary>
        /// CRUD: Update Subscription
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="modifyRequest"></param>
        /// <returns>Task of ProxyCreateOrModifyResponse</returns>
        System.Threading.Tasks.Task<ProxyCreateOrModifyResponse> ProxyPUTSubscriptionAsync (string id, ProxyModifySubscription modifyRequest);

        /// <summary>
        /// CRUD: Update Subscription
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="modifyRequest"></param>
        /// <returns>Task of ApiResponse (ProxyCreateOrModifyResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ProxyCreateOrModifyResponse>> ProxyPUTSubscriptionAsyncWithHttpInfo (string id, ProxyModifySubscription modifyRequest);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class SubscriptionsApi : ISubscriptionsApi
    {
        private IO.Swagger.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SubscriptionsApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public SubscriptionsApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public IO.Swagger.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public Dictionary<String, String> DefaultHeader()
        {
            return this.Configuration.DefaultHeader;
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Get subscriptions by key This REST API reference describes how to retrieve detailed information about a specified subscription in the latest version. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Possible values are:   * a subscription number   * a subscription ID </param>
        /// <param name="chargeDetail"> The segmented rate plan charges. When an amendment results in a change to a charge, Zuora creates a segmented rate plan charge. Use this field to track segment charges.  Possible values are:   * __last-segment__: (Default) The last rate plan charge on the subscription. The last rate plan charge is the last one in the order of time on the subscription rather than the most recent changed charge on the subscription.  * __current-segment__: The segmented charge that is active on today’s date (effectiveStartDate &lt;&#x3D; today’s date &lt; effectiveEndDate).    * __all-segments__: All the segmented charges.   * __specific-segment&amp;as-of-date&#x3D;date__: The segmented charge that is active on a date you specified (effectiveStartDate &lt;&#x3D; specific date &lt; effectiveEndDate). The format of the date is yyyy-mm-dd.  (optional)</param>
        /// <returns>GETSubscriptionTypeWithSuccess</returns>
        public GETSubscriptionTypeWithSuccess GETOneSubscription (string subscriptionKey, string chargeDetail = null)
        {
             ApiResponse<GETSubscriptionTypeWithSuccess> localVarResponse = GETOneSubscriptionWithHttpInfo(subscriptionKey, chargeDetail);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get subscriptions by key This REST API reference describes how to retrieve detailed information about a specified subscription in the latest version. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Possible values are:   * a subscription number   * a subscription ID </param>
        /// <param name="chargeDetail"> The segmented rate plan charges. When an amendment results in a change to a charge, Zuora creates a segmented rate plan charge. Use this field to track segment charges.  Possible values are:   * __last-segment__: (Default) The last rate plan charge on the subscription. The last rate plan charge is the last one in the order of time on the subscription rather than the most recent changed charge on the subscription.  * __current-segment__: The segmented charge that is active on today’s date (effectiveStartDate &lt;&#x3D; today’s date &lt; effectiveEndDate).    * __all-segments__: All the segmented charges.   * __specific-segment&amp;as-of-date&#x3D;date__: The segmented charge that is active on a date you specified (effectiveStartDate &lt;&#x3D; specific date &lt; effectiveEndDate). The format of the date is yyyy-mm-dd.  (optional)</param>
        /// <returns>ApiResponse of GETSubscriptionTypeWithSuccess</returns>
        public ApiResponse< GETSubscriptionTypeWithSuccess > GETOneSubscriptionWithHttpInfo (string subscriptionKey, string chargeDetail = null)
        {
            // verify the required parameter 'subscriptionKey' is set
            if (subscriptionKey == null)
                throw new ApiException(400, "Missing required parameter 'subscriptionKey' when calling SubscriptionsApi->GETOneSubscription");

            var localVarPath = "/subscriptions/{subscription-key}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (subscriptionKey != null) localVarPathParams.Add("subscription-key", Configuration.ApiClient.ParameterToString(subscriptionKey)); // path parameter
            if (chargeDetail != null) localVarQueryParams.Add("charge-detail", Configuration.ApiClient.ParameterToString(chargeDetail)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GETOneSubscription", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GETSubscriptionTypeWithSuccess>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (GETSubscriptionTypeWithSuccess) Configuration.ApiClient.Deserialize(localVarResponse, typeof(GETSubscriptionTypeWithSuccess)));
            
        }

        /// <summary>
        /// Get subscriptions by key This REST API reference describes how to retrieve detailed information about a specified subscription in the latest version. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Possible values are:   * a subscription number   * a subscription ID </param>
        /// <param name="chargeDetail"> The segmented rate plan charges. When an amendment results in a change to a charge, Zuora creates a segmented rate plan charge. Use this field to track segment charges.  Possible values are:   * __last-segment__: (Default) The last rate plan charge on the subscription. The last rate plan charge is the last one in the order of time on the subscription rather than the most recent changed charge on the subscription.  * __current-segment__: The segmented charge that is active on today’s date (effectiveStartDate &lt;&#x3D; today’s date &lt; effectiveEndDate).    * __all-segments__: All the segmented charges.   * __specific-segment&amp;as-of-date&#x3D;date__: The segmented charge that is active on a date you specified (effectiveStartDate &lt;&#x3D; specific date &lt; effectiveEndDate). The format of the date is yyyy-mm-dd.  (optional)</param>
        /// <returns>Task of GETSubscriptionTypeWithSuccess</returns>
        public async System.Threading.Tasks.Task<GETSubscriptionTypeWithSuccess> GETOneSubscriptionAsync (string subscriptionKey, string chargeDetail = null)
        {
             ApiResponse<GETSubscriptionTypeWithSuccess> localVarResponse = await GETOneSubscriptionAsyncWithHttpInfo(subscriptionKey, chargeDetail);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get subscriptions by key This REST API reference describes how to retrieve detailed information about a specified subscription in the latest version. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Possible values are:   * a subscription number   * a subscription ID </param>
        /// <param name="chargeDetail"> The segmented rate plan charges. When an amendment results in a change to a charge, Zuora creates a segmented rate plan charge. Use this field to track segment charges.  Possible values are:   * __last-segment__: (Default) The last rate plan charge on the subscription. The last rate plan charge is the last one in the order of time on the subscription rather than the most recent changed charge on the subscription.  * __current-segment__: The segmented charge that is active on today’s date (effectiveStartDate &lt;&#x3D; today’s date &lt; effectiveEndDate).    * __all-segments__: All the segmented charges.   * __specific-segment&amp;as-of-date&#x3D;date__: The segmented charge that is active on a date you specified (effectiveStartDate &lt;&#x3D; specific date &lt; effectiveEndDate). The format of the date is yyyy-mm-dd.  (optional)</param>
        /// <returns>Task of ApiResponse (GETSubscriptionTypeWithSuccess)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<GETSubscriptionTypeWithSuccess>> GETOneSubscriptionAsyncWithHttpInfo (string subscriptionKey, string chargeDetail = null)
        {
            // verify the required parameter 'subscriptionKey' is set
            if (subscriptionKey == null)
                throw new ApiException(400, "Missing required parameter 'subscriptionKey' when calling SubscriptionsApi->GETOneSubscription");

            var localVarPath = "/subscriptions/{subscription-key}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (subscriptionKey != null) localVarPathParams.Add("subscription-key", Configuration.ApiClient.ParameterToString(subscriptionKey)); // path parameter
            if (chargeDetail != null) localVarQueryParams.Add("charge-detail", Configuration.ApiClient.ParameterToString(chargeDetail)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GETOneSubscription", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GETSubscriptionTypeWithSuccess>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (GETSubscriptionTypeWithSuccess) Configuration.ApiClient.Deserialize(localVarResponse, typeof(GETSubscriptionTypeWithSuccess)));
            
        }

        /// <summary>
        /// Get subscriptions by account Retrieves all subscriptions associated with the specified account. Zuora only returns the latest version of the subscriptions.  Subscription data is returned in reverse chronological order based on &#x60;updatedDate&#x60;. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountKey"> Possible values are: * an account number * an account ID </param>
        /// <param name="chargeDetail">The segmented rate plan charges.  When an amendment results in a change to a charge, Zuora creates a segmented rate plan charge. Use this field to track segment charges.  Possible values are:  * &#x60;last-segment&#x60;: (Default) The last rate plan charge on the subscription. The last rate plan charge is the last one in the order of time on the subscription rather than the most recent updated charge on the subscription. * &#x60;current-segment&#x60;: The segmented charge that is active on today’s date (**effectiveStartDate** &lt;&#x3D; today’s date &lt; **effectiveEndDate**). * &#x60;all-segments&#x60;: All the segmented charges. * &#x60;specific-segment&amp;as-of-date&#x3D;date&#x60;: The segmented charge that is active on a date you specified (**effectiveStartDate** &lt;&#x3D; specific date &lt; **effectiveEndDate**). The format of the date is yyyy-mm-dd.  (optional)</param>
        /// <returns>GETSubscriptionWrapper</returns>
        public GETSubscriptionWrapper GETSubscription (string accountKey, string chargeDetail = null)
        {
             ApiResponse<GETSubscriptionWrapper> localVarResponse = GETSubscriptionWithHttpInfo(accountKey, chargeDetail);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get subscriptions by account Retrieves all subscriptions associated with the specified account. Zuora only returns the latest version of the subscriptions.  Subscription data is returned in reverse chronological order based on &#x60;updatedDate&#x60;. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountKey"> Possible values are: * an account number * an account ID </param>
        /// <param name="chargeDetail">The segmented rate plan charges.  When an amendment results in a change to a charge, Zuora creates a segmented rate plan charge. Use this field to track segment charges.  Possible values are:  * &#x60;last-segment&#x60;: (Default) The last rate plan charge on the subscription. The last rate plan charge is the last one in the order of time on the subscription rather than the most recent updated charge on the subscription. * &#x60;current-segment&#x60;: The segmented charge that is active on today’s date (**effectiveStartDate** &lt;&#x3D; today’s date &lt; **effectiveEndDate**). * &#x60;all-segments&#x60;: All the segmented charges. * &#x60;specific-segment&amp;as-of-date&#x3D;date&#x60;: The segmented charge that is active on a date you specified (**effectiveStartDate** &lt;&#x3D; specific date &lt; **effectiveEndDate**). The format of the date is yyyy-mm-dd.  (optional)</param>
        /// <returns>ApiResponse of GETSubscriptionWrapper</returns>
        public ApiResponse< GETSubscriptionWrapper > GETSubscriptionWithHttpInfo (string accountKey, string chargeDetail = null)
        {
            // verify the required parameter 'accountKey' is set
            if (accountKey == null)
                throw new ApiException(400, "Missing required parameter 'accountKey' when calling SubscriptionsApi->GETSubscription");

            var localVarPath = "/subscriptions/accounts/{account-key}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (accountKey != null) localVarPathParams.Add("account-key", Configuration.ApiClient.ParameterToString(accountKey)); // path parameter
            if (chargeDetail != null) localVarQueryParams.Add("charge-detail", Configuration.ApiClient.ParameterToString(chargeDetail)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GETSubscription", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GETSubscriptionWrapper>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (GETSubscriptionWrapper) Configuration.ApiClient.Deserialize(localVarResponse, typeof(GETSubscriptionWrapper)));
            
        }

        /// <summary>
        /// Get subscriptions by account Retrieves all subscriptions associated with the specified account. Zuora only returns the latest version of the subscriptions.  Subscription data is returned in reverse chronological order based on &#x60;updatedDate&#x60;. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountKey"> Possible values are: * an account number * an account ID </param>
        /// <param name="chargeDetail">The segmented rate plan charges.  When an amendment results in a change to a charge, Zuora creates a segmented rate plan charge. Use this field to track segment charges.  Possible values are:  * &#x60;last-segment&#x60;: (Default) The last rate plan charge on the subscription. The last rate plan charge is the last one in the order of time on the subscription rather than the most recent updated charge on the subscription. * &#x60;current-segment&#x60;: The segmented charge that is active on today’s date (**effectiveStartDate** &lt;&#x3D; today’s date &lt; **effectiveEndDate**). * &#x60;all-segments&#x60;: All the segmented charges. * &#x60;specific-segment&amp;as-of-date&#x3D;date&#x60;: The segmented charge that is active on a date you specified (**effectiveStartDate** &lt;&#x3D; specific date &lt; **effectiveEndDate**). The format of the date is yyyy-mm-dd.  (optional)</param>
        /// <returns>Task of GETSubscriptionWrapper</returns>
        public async System.Threading.Tasks.Task<GETSubscriptionWrapper> GETSubscriptionAsync (string accountKey, string chargeDetail = null)
        {
             ApiResponse<GETSubscriptionWrapper> localVarResponse = await GETSubscriptionAsyncWithHttpInfo(accountKey, chargeDetail);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get subscriptions by account Retrieves all subscriptions associated with the specified account. Zuora only returns the latest version of the subscriptions.  Subscription data is returned in reverse chronological order based on &#x60;updatedDate&#x60;. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountKey"> Possible values are: * an account number * an account ID </param>
        /// <param name="chargeDetail">The segmented rate plan charges.  When an amendment results in a change to a charge, Zuora creates a segmented rate plan charge. Use this field to track segment charges.  Possible values are:  * &#x60;last-segment&#x60;: (Default) The last rate plan charge on the subscription. The last rate plan charge is the last one in the order of time on the subscription rather than the most recent updated charge on the subscription. * &#x60;current-segment&#x60;: The segmented charge that is active on today’s date (**effectiveStartDate** &lt;&#x3D; today’s date &lt; **effectiveEndDate**). * &#x60;all-segments&#x60;: All the segmented charges. * &#x60;specific-segment&amp;as-of-date&#x3D;date&#x60;: The segmented charge that is active on a date you specified (**effectiveStartDate** &lt;&#x3D; specific date &lt; **effectiveEndDate**). The format of the date is yyyy-mm-dd.  (optional)</param>
        /// <returns>Task of ApiResponse (GETSubscriptionWrapper)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<GETSubscriptionWrapper>> GETSubscriptionAsyncWithHttpInfo (string accountKey, string chargeDetail = null)
        {
            // verify the required parameter 'accountKey' is set
            if (accountKey == null)
                throw new ApiException(400, "Missing required parameter 'accountKey' when calling SubscriptionsApi->GETSubscription");

            var localVarPath = "/subscriptions/accounts/{account-key}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (accountKey != null) localVarPathParams.Add("account-key", Configuration.ApiClient.ParameterToString(accountKey)); // path parameter
            if (chargeDetail != null) localVarQueryParams.Add("charge-detail", Configuration.ApiClient.ParameterToString(chargeDetail)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GETSubscription", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GETSubscriptionWrapper>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (GETSubscriptionWrapper) Configuration.ApiClient.Deserialize(localVarResponse, typeof(GETSubscriptionWrapper)));
            
        }

        /// <summary>
        /// Create subscription This REST API reference describes how to create a new subscription for an existing customer account.  ## Notes If invoiceCollect is &#x60;true&#x60;, the call will not return success &#x3D; &#x60;true&#x60; unless the subscription, invoice, and payment are all successful.  Default values for **customerAcceptanceDate** and **serviceActivationDate** are set as follows.  |        | serviceActivationDate(SA) specified          | serviceActivationDate (SA) NOT specified  | | - -- -- -- -- -- -- |:- -- -- -- -- -- --:| - -- --:| | customerAcceptanceDate (CA) specified| SA uses value in the request call; CA uses value in the request call| CA uses value in the request call;SA uses CE as default | | customerAcceptanceDate (CA) NOT specified      | SA uses value in the request call; CA uses SA as default |   SA and CA use CE as default | 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>POSTSubscriptionResponseType</returns>
        public POSTSubscriptionResponseType POSTSubscription (POSTSubscriptionType request, string zuoraVersion = null)
        {
             ApiResponse<POSTSubscriptionResponseType> localVarResponse = POSTSubscriptionWithHttpInfo(request, zuoraVersion);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Create subscription This REST API reference describes how to create a new subscription for an existing customer account.  ## Notes If invoiceCollect is &#x60;true&#x60;, the call will not return success &#x3D; &#x60;true&#x60; unless the subscription, invoice, and payment are all successful.  Default values for **customerAcceptanceDate** and **serviceActivationDate** are set as follows.  |        | serviceActivationDate(SA) specified          | serviceActivationDate (SA) NOT specified  | | - -- -- -- -- -- -- |:- -- -- -- -- -- --:| - -- --:| | customerAcceptanceDate (CA) specified| SA uses value in the request call; CA uses value in the request call| CA uses value in the request call;SA uses CE as default | | customerAcceptanceDate (CA) NOT specified      | SA uses value in the request call; CA uses SA as default |   SA and CA use CE as default | 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>ApiResponse of POSTSubscriptionResponseType</returns>
        public ApiResponse< POSTSubscriptionResponseType > POSTSubscriptionWithHttpInfo (POSTSubscriptionType request, string zuoraVersion = null)
        {
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling SubscriptionsApi->POSTSubscription");

            var localVarPath = "/subscriptions";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (zuoraVersion != null) localVarHeaderParams.Add("zuora-version", Configuration.ApiClient.ParameterToString(zuoraVersion)); // header parameter
            if (request != null && request.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(request); // http body (model) parameter
            }
            else
            {
                localVarPostBody = request; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("POSTSubscription", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<POSTSubscriptionResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (POSTSubscriptionResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(POSTSubscriptionResponseType)));
            
        }

        /// <summary>
        /// Create subscription This REST API reference describes how to create a new subscription for an existing customer account.  ## Notes If invoiceCollect is &#x60;true&#x60;, the call will not return success &#x3D; &#x60;true&#x60; unless the subscription, invoice, and payment are all successful.  Default values for **customerAcceptanceDate** and **serviceActivationDate** are set as follows.  |        | serviceActivationDate(SA) specified          | serviceActivationDate (SA) NOT specified  | | - -- -- -- -- -- -- |:- -- -- -- -- -- --:| - -- --:| | customerAcceptanceDate (CA) specified| SA uses value in the request call; CA uses value in the request call| CA uses value in the request call;SA uses CE as default | | customerAcceptanceDate (CA) NOT specified      | SA uses value in the request call; CA uses SA as default |   SA and CA use CE as default | 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>Task of POSTSubscriptionResponseType</returns>
        public async System.Threading.Tasks.Task<POSTSubscriptionResponseType> POSTSubscriptionAsync (POSTSubscriptionType request, string zuoraVersion = null)
        {
             ApiResponse<POSTSubscriptionResponseType> localVarResponse = await POSTSubscriptionAsyncWithHttpInfo(request, zuoraVersion);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Create subscription This REST API reference describes how to create a new subscription for an existing customer account.  ## Notes If invoiceCollect is &#x60;true&#x60;, the call will not return success &#x3D; &#x60;true&#x60; unless the subscription, invoice, and payment are all successful.  Default values for **customerAcceptanceDate** and **serviceActivationDate** are set as follows.  |        | serviceActivationDate(SA) specified          | serviceActivationDate (SA) NOT specified  | | - -- -- -- -- -- -- |:- -- -- -- -- -- --:| - -- --:| | customerAcceptanceDate (CA) specified| SA uses value in the request call; CA uses value in the request call| CA uses value in the request call;SA uses CE as default | | customerAcceptanceDate (CA) NOT specified      | SA uses value in the request call; CA uses SA as default |   SA and CA use CE as default | 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>Task of ApiResponse (POSTSubscriptionResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<POSTSubscriptionResponseType>> POSTSubscriptionAsyncWithHttpInfo (POSTSubscriptionType request, string zuoraVersion = null)
        {
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling SubscriptionsApi->POSTSubscription");

            var localVarPath = "/subscriptions";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (zuoraVersion != null) localVarHeaderParams.Add("zuora-version", Configuration.ApiClient.ParameterToString(zuoraVersion)); // header parameter
            if (request != null && request.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(request); // http body (model) parameter
            }
            else
            {
                localVarPostBody = request; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("POSTSubscription", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<POSTSubscriptionResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (POSTSubscriptionResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(POSTSubscriptionResponseType)));
            
        }

        /// <summary>
        /// Cancel subscription This REST API reference describes how to cancel an active subscription. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID. Subscription status must be &#x60;Active&#x60;.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>POSTSubscriptionCancellationResponseType</returns>
        public POSTSubscriptionCancellationResponseType POSTSubscriptionCancellation (string subscriptionKey, POSTSubscriptionCancellationType request, string zuoraVersion = null)
        {
             ApiResponse<POSTSubscriptionCancellationResponseType> localVarResponse = POSTSubscriptionCancellationWithHttpInfo(subscriptionKey, request, zuoraVersion);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Cancel subscription This REST API reference describes how to cancel an active subscription. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID. Subscription status must be &#x60;Active&#x60;.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>ApiResponse of POSTSubscriptionCancellationResponseType</returns>
        public ApiResponse< POSTSubscriptionCancellationResponseType > POSTSubscriptionCancellationWithHttpInfo (string subscriptionKey, POSTSubscriptionCancellationType request, string zuoraVersion = null)
        {
            // verify the required parameter 'subscriptionKey' is set
            if (subscriptionKey == null)
                throw new ApiException(400, "Missing required parameter 'subscriptionKey' when calling SubscriptionsApi->POSTSubscriptionCancellation");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling SubscriptionsApi->POSTSubscriptionCancellation");

            var localVarPath = "/subscriptions/{subscription-key}/cancel";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (subscriptionKey != null) localVarPathParams.Add("subscription-key", Configuration.ApiClient.ParameterToString(subscriptionKey)); // path parameter
            if (zuoraVersion != null) localVarHeaderParams.Add("zuora-version", Configuration.ApiClient.ParameterToString(zuoraVersion)); // header parameter
            if (request != null && request.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(request); // http body (model) parameter
            }
            else
            {
                localVarPostBody = request; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("POSTSubscriptionCancellation", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<POSTSubscriptionCancellationResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (POSTSubscriptionCancellationResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(POSTSubscriptionCancellationResponseType)));
            
        }

        /// <summary>
        /// Cancel subscription This REST API reference describes how to cancel an active subscription. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID. Subscription status must be &#x60;Active&#x60;.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>Task of POSTSubscriptionCancellationResponseType</returns>
        public async System.Threading.Tasks.Task<POSTSubscriptionCancellationResponseType> POSTSubscriptionCancellationAsync (string subscriptionKey, POSTSubscriptionCancellationType request, string zuoraVersion = null)
        {
             ApiResponse<POSTSubscriptionCancellationResponseType> localVarResponse = await POSTSubscriptionCancellationAsyncWithHttpInfo(subscriptionKey, request, zuoraVersion);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Cancel subscription This REST API reference describes how to cancel an active subscription. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID. Subscription status must be &#x60;Active&#x60;.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>Task of ApiResponse (POSTSubscriptionCancellationResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<POSTSubscriptionCancellationResponseType>> POSTSubscriptionCancellationAsyncWithHttpInfo (string subscriptionKey, POSTSubscriptionCancellationType request, string zuoraVersion = null)
        {
            // verify the required parameter 'subscriptionKey' is set
            if (subscriptionKey == null)
                throw new ApiException(400, "Missing required parameter 'subscriptionKey' when calling SubscriptionsApi->POSTSubscriptionCancellation");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling SubscriptionsApi->POSTSubscriptionCancellation");

            var localVarPath = "/subscriptions/{subscription-key}/cancel";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (subscriptionKey != null) localVarPathParams.Add("subscription-key", Configuration.ApiClient.ParameterToString(subscriptionKey)); // path parameter
            if (zuoraVersion != null) localVarHeaderParams.Add("zuora-version", Configuration.ApiClient.ParameterToString(zuoraVersion)); // header parameter
            if (request != null && request.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(request); // http body (model) parameter
            }
            else
            {
                localVarPostBody = request; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("POSTSubscriptionCancellation", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<POSTSubscriptionCancellationResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (POSTSubscriptionCancellationResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(POSTSubscriptionCancellationResponseType)));
            
        }

        /// <summary>
        /// Preview subscription The REST API reference describes how to create a new subscription in preview mode. This call does not require a valid customer account. It can be used to show potential new customers a preview of a subscription with complete details and charges before creating an account, or to let existing customers preview a subscription with all charges before committing.  ## Notes Default values for **customerAcceptanceDate** and **serviceActivationDate** are set as follows.  |        | serviceActivationDate (SA) specified          | serviceActivationDate (SA) NOT specified  | | - -- -- -- -- -- -- |:- -- -- -- -- -- --:| - -- --:| | customerAcceptanceDate (CA) specified      | SA uses value in the request call; CA uses value in the request call| CA uses value in the request call;SA uses CE as default | | customerAcceptanceDate (CA) NOT specified      | SA uses value in the request call; CA uses SA as default |   SA and CA use CE as default | 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>POSTSubscriptionPreviewResponseType</returns>
        public POSTSubscriptionPreviewResponseType POSTSubscriptionPreview (POSTSubscriptionPreviewType request)
        {
             ApiResponse<POSTSubscriptionPreviewResponseType> localVarResponse = POSTSubscriptionPreviewWithHttpInfo(request);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Preview subscription The REST API reference describes how to create a new subscription in preview mode. This call does not require a valid customer account. It can be used to show potential new customers a preview of a subscription with complete details and charges before creating an account, or to let existing customers preview a subscription with all charges before committing.  ## Notes Default values for **customerAcceptanceDate** and **serviceActivationDate** are set as follows.  |        | serviceActivationDate (SA) specified          | serviceActivationDate (SA) NOT specified  | | - -- -- -- -- -- -- |:- -- -- -- -- -- --:| - -- --:| | customerAcceptanceDate (CA) specified      | SA uses value in the request call; CA uses value in the request call| CA uses value in the request call;SA uses CE as default | | customerAcceptanceDate (CA) NOT specified      | SA uses value in the request call; CA uses SA as default |   SA and CA use CE as default | 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>ApiResponse of POSTSubscriptionPreviewResponseType</returns>
        public ApiResponse< POSTSubscriptionPreviewResponseType > POSTSubscriptionPreviewWithHttpInfo (POSTSubscriptionPreviewType request)
        {
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling SubscriptionsApi->POSTSubscriptionPreview");

            var localVarPath = "/subscriptions/preview";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (request != null && request.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(request); // http body (model) parameter
            }
            else
            {
                localVarPostBody = request; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("POSTSubscriptionPreview", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<POSTSubscriptionPreviewResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (POSTSubscriptionPreviewResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(POSTSubscriptionPreviewResponseType)));
            
        }

        /// <summary>
        /// Preview subscription The REST API reference describes how to create a new subscription in preview mode. This call does not require a valid customer account. It can be used to show potential new customers a preview of a subscription with complete details and charges before creating an account, or to let existing customers preview a subscription with all charges before committing.  ## Notes Default values for **customerAcceptanceDate** and **serviceActivationDate** are set as follows.  |        | serviceActivationDate (SA) specified          | serviceActivationDate (SA) NOT specified  | | - -- -- -- -- -- -- |:- -- -- -- -- -- --:| - -- --:| | customerAcceptanceDate (CA) specified      | SA uses value in the request call; CA uses value in the request call| CA uses value in the request call;SA uses CE as default | | customerAcceptanceDate (CA) NOT specified      | SA uses value in the request call; CA uses SA as default |   SA and CA use CE as default | 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>Task of POSTSubscriptionPreviewResponseType</returns>
        public async System.Threading.Tasks.Task<POSTSubscriptionPreviewResponseType> POSTSubscriptionPreviewAsync (POSTSubscriptionPreviewType request)
        {
             ApiResponse<POSTSubscriptionPreviewResponseType> localVarResponse = await POSTSubscriptionPreviewAsyncWithHttpInfo(request);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Preview subscription The REST API reference describes how to create a new subscription in preview mode. This call does not require a valid customer account. It can be used to show potential new customers a preview of a subscription with complete details and charges before creating an account, or to let existing customers preview a subscription with all charges before committing.  ## Notes Default values for **customerAcceptanceDate** and **serviceActivationDate** are set as follows.  |        | serviceActivationDate (SA) specified          | serviceActivationDate (SA) NOT specified  | | - -- -- -- -- -- -- |:- -- -- -- -- -- --:| - -- --:| | customerAcceptanceDate (CA) specified      | SA uses value in the request call; CA uses value in the request call| CA uses value in the request call;SA uses CE as default | | customerAcceptanceDate (CA) NOT specified      | SA uses value in the request call; CA uses SA as default |   SA and CA use CE as default | 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (POSTSubscriptionPreviewResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<POSTSubscriptionPreviewResponseType>> POSTSubscriptionPreviewAsyncWithHttpInfo (POSTSubscriptionPreviewType request)
        {
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling SubscriptionsApi->POSTSubscriptionPreview");

            var localVarPath = "/subscriptions/preview";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (request != null && request.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(request); // http body (model) parameter
            }
            else
            {
                localVarPostBody = request; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("POSTSubscriptionPreview", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<POSTSubscriptionPreviewResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (POSTSubscriptionPreviewResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(POSTSubscriptionPreviewResponseType)));
            
        }

        /// <summary>
        /// Renew subscription Renews a termed subscription using existing renewal terms. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>PUTRenewSubscriptionResponseType</returns>
        public PUTRenewSubscriptionResponseType PUTRenewSubscription (string subscriptionKey, PUTRenewSubscriptionType request, string zuoraVersion = null)
        {
             ApiResponse<PUTRenewSubscriptionResponseType> localVarResponse = PUTRenewSubscriptionWithHttpInfo(subscriptionKey, request, zuoraVersion);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Renew subscription Renews a termed subscription using existing renewal terms. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>ApiResponse of PUTRenewSubscriptionResponseType</returns>
        public ApiResponse< PUTRenewSubscriptionResponseType > PUTRenewSubscriptionWithHttpInfo (string subscriptionKey, PUTRenewSubscriptionType request, string zuoraVersion = null)
        {
            // verify the required parameter 'subscriptionKey' is set
            if (subscriptionKey == null)
                throw new ApiException(400, "Missing required parameter 'subscriptionKey' when calling SubscriptionsApi->PUTRenewSubscription");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling SubscriptionsApi->PUTRenewSubscription");

            var localVarPath = "/subscriptions/{subscription-key}/renew";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (subscriptionKey != null) localVarPathParams.Add("subscription-key", Configuration.ApiClient.ParameterToString(subscriptionKey)); // path parameter
            if (zuoraVersion != null) localVarHeaderParams.Add("zuora-version", Configuration.ApiClient.ParameterToString(zuoraVersion)); // header parameter
            if (request != null && request.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(request); // http body (model) parameter
            }
            else
            {
                localVarPostBody = request; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PUTRenewSubscription", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<PUTRenewSubscriptionResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (PUTRenewSubscriptionResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(PUTRenewSubscriptionResponseType)));
            
        }

        /// <summary>
        /// Renew subscription Renews a termed subscription using existing renewal terms. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>Task of PUTRenewSubscriptionResponseType</returns>
        public async System.Threading.Tasks.Task<PUTRenewSubscriptionResponseType> PUTRenewSubscriptionAsync (string subscriptionKey, PUTRenewSubscriptionType request, string zuoraVersion = null)
        {
             ApiResponse<PUTRenewSubscriptionResponseType> localVarResponse = await PUTRenewSubscriptionAsyncWithHttpInfo(subscriptionKey, request, zuoraVersion);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Renew subscription Renews a termed subscription using existing renewal terms. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>Task of ApiResponse (PUTRenewSubscriptionResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<PUTRenewSubscriptionResponseType>> PUTRenewSubscriptionAsyncWithHttpInfo (string subscriptionKey, PUTRenewSubscriptionType request, string zuoraVersion = null)
        {
            // verify the required parameter 'subscriptionKey' is set
            if (subscriptionKey == null)
                throw new ApiException(400, "Missing required parameter 'subscriptionKey' when calling SubscriptionsApi->PUTRenewSubscription");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling SubscriptionsApi->PUTRenewSubscription");

            var localVarPath = "/subscriptions/{subscription-key}/renew";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (subscriptionKey != null) localVarPathParams.Add("subscription-key", Configuration.ApiClient.ParameterToString(subscriptionKey)); // path parameter
            if (zuoraVersion != null) localVarHeaderParams.Add("zuora-version", Configuration.ApiClient.ParameterToString(zuoraVersion)); // header parameter
            if (request != null && request.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(request); // http body (model) parameter
            }
            else
            {
                localVarPostBody = request; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PUTRenewSubscription", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<PUTRenewSubscriptionResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (PUTRenewSubscriptionResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(PUTRenewSubscriptionResponseType)));
            
        }

        /// <summary>
        /// Update subscription Use this call to make the following kinds of changes to a subscription:   * Add a note   * Change the renewal term or auto-renewal flag   * Change the term length or change between evergreen and termed   * Add a new product rate plan   * Remove an existing subscription rate plan   * Change the quantity or price of an existing subscription rate plan  ## Notes * The Update Subscription call creates a new subscription, which has the old subscription number but a new subscription ID.  The old subscription is canceled but remains in the system. * In one request, this call can make:   * Up to 9 combined add, update, and remove changes   * No more than 1 change to terms &amp; conditions * Updates are performed in the following sequence:   1. First change the notes on the existing subscription, if requested.   2. Then change the terms and conditions, if requested.   3. Then perform the remaining amendments based upon the effective dates specified. If multiple amendments have the same contract-effective dates, then execute adds before updates, and updates before removes. * The update operation is atomic. If any of the updates fails, the entire operation is rolled back.  ## Override a Tiered Price There are two ways you override a tiered price:  * Override a specific tier number For example: &#x60;tiers[{tier:1,price:8},{tier:2,price:6}]&#x60;  * Override the entire tier structure For example:  &#x60;tiers[{tier:1,price:8,startingUnit:1,endingUnit:100,priceFormat:\&quot;FlatFee\&quot;}, {tier:2,price:6,startingUnit:101,priceFormat:\&quot;FlatFee\&quot;}]&#x60;  If you just override a specific tier, do not include the &#x60;startingUnit&#x60; field in the request. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>PUTSubscriptionResponseType</returns>
        public PUTSubscriptionResponseType PUTSubscription (string subscriptionKey, PUTSubscriptionType request, string zuoraVersion = null)
        {
             ApiResponse<PUTSubscriptionResponseType> localVarResponse = PUTSubscriptionWithHttpInfo(subscriptionKey, request, zuoraVersion);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Update subscription Use this call to make the following kinds of changes to a subscription:   * Add a note   * Change the renewal term or auto-renewal flag   * Change the term length or change between evergreen and termed   * Add a new product rate plan   * Remove an existing subscription rate plan   * Change the quantity or price of an existing subscription rate plan  ## Notes * The Update Subscription call creates a new subscription, which has the old subscription number but a new subscription ID.  The old subscription is canceled but remains in the system. * In one request, this call can make:   * Up to 9 combined add, update, and remove changes   * No more than 1 change to terms &amp; conditions * Updates are performed in the following sequence:   1. First change the notes on the existing subscription, if requested.   2. Then change the terms and conditions, if requested.   3. Then perform the remaining amendments based upon the effective dates specified. If multiple amendments have the same contract-effective dates, then execute adds before updates, and updates before removes. * The update operation is atomic. If any of the updates fails, the entire operation is rolled back.  ## Override a Tiered Price There are two ways you override a tiered price:  * Override a specific tier number For example: &#x60;tiers[{tier:1,price:8},{tier:2,price:6}]&#x60;  * Override the entire tier structure For example:  &#x60;tiers[{tier:1,price:8,startingUnit:1,endingUnit:100,priceFormat:\&quot;FlatFee\&quot;}, {tier:2,price:6,startingUnit:101,priceFormat:\&quot;FlatFee\&quot;}]&#x60;  If you just override a specific tier, do not include the &#x60;startingUnit&#x60; field in the request. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>ApiResponse of PUTSubscriptionResponseType</returns>
        public ApiResponse< PUTSubscriptionResponseType > PUTSubscriptionWithHttpInfo (string subscriptionKey, PUTSubscriptionType request, string zuoraVersion = null)
        {
            // verify the required parameter 'subscriptionKey' is set
            if (subscriptionKey == null)
                throw new ApiException(400, "Missing required parameter 'subscriptionKey' when calling SubscriptionsApi->PUTSubscription");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling SubscriptionsApi->PUTSubscription");

            var localVarPath = "/subscriptions/{subscription-key}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (subscriptionKey != null) localVarPathParams.Add("subscription-key", Configuration.ApiClient.ParameterToString(subscriptionKey)); // path parameter
            if (zuoraVersion != null) localVarHeaderParams.Add("zuora-version", Configuration.ApiClient.ParameterToString(zuoraVersion)); // header parameter
            if (request != null && request.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(request); // http body (model) parameter
            }
            else
            {
                localVarPostBody = request; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PUTSubscription", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<PUTSubscriptionResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (PUTSubscriptionResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(PUTSubscriptionResponseType)));
            
        }

        /// <summary>
        /// Update subscription Use this call to make the following kinds of changes to a subscription:   * Add a note   * Change the renewal term or auto-renewal flag   * Change the term length or change between evergreen and termed   * Add a new product rate plan   * Remove an existing subscription rate plan   * Change the quantity or price of an existing subscription rate plan  ## Notes * The Update Subscription call creates a new subscription, which has the old subscription number but a new subscription ID.  The old subscription is canceled but remains in the system. * In one request, this call can make:   * Up to 9 combined add, update, and remove changes   * No more than 1 change to terms &amp; conditions * Updates are performed in the following sequence:   1. First change the notes on the existing subscription, if requested.   2. Then change the terms and conditions, if requested.   3. Then perform the remaining amendments based upon the effective dates specified. If multiple amendments have the same contract-effective dates, then execute adds before updates, and updates before removes. * The update operation is atomic. If any of the updates fails, the entire operation is rolled back.  ## Override a Tiered Price There are two ways you override a tiered price:  * Override a specific tier number For example: &#x60;tiers[{tier:1,price:8},{tier:2,price:6}]&#x60;  * Override the entire tier structure For example:  &#x60;tiers[{tier:1,price:8,startingUnit:1,endingUnit:100,priceFormat:\&quot;FlatFee\&quot;}, {tier:2,price:6,startingUnit:101,priceFormat:\&quot;FlatFee\&quot;}]&#x60;  If you just override a specific tier, do not include the &#x60;startingUnit&#x60; field in the request. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>Task of PUTSubscriptionResponseType</returns>
        public async System.Threading.Tasks.Task<PUTSubscriptionResponseType> PUTSubscriptionAsync (string subscriptionKey, PUTSubscriptionType request, string zuoraVersion = null)
        {
             ApiResponse<PUTSubscriptionResponseType> localVarResponse = await PUTSubscriptionAsyncWithHttpInfo(subscriptionKey, request, zuoraVersion);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Update subscription Use this call to make the following kinds of changes to a subscription:   * Add a note   * Change the renewal term or auto-renewal flag   * Change the term length or change between evergreen and termed   * Add a new product rate plan   * Remove an existing subscription rate plan   * Change the quantity or price of an existing subscription rate plan  ## Notes * The Update Subscription call creates a new subscription, which has the old subscription number but a new subscription ID.  The old subscription is canceled but remains in the system. * In one request, this call can make:   * Up to 9 combined add, update, and remove changes   * No more than 1 change to terms &amp; conditions * Updates are performed in the following sequence:   1. First change the notes on the existing subscription, if requested.   2. Then change the terms and conditions, if requested.   3. Then perform the remaining amendments based upon the effective dates specified. If multiple amendments have the same contract-effective dates, then execute adds before updates, and updates before removes. * The update operation is atomic. If any of the updates fails, the entire operation is rolled back.  ## Override a Tiered Price There are two ways you override a tiered price:  * Override a specific tier number For example: &#x60;tiers[{tier:1,price:8},{tier:2,price:6}]&#x60;  * Override the entire tier structure For example:  &#x60;tiers[{tier:1,price:8,startingUnit:1,endingUnit:100,priceFormat:\&quot;FlatFee\&quot;}, {tier:2,price:6,startingUnit:101,priceFormat:\&quot;FlatFee\&quot;}]&#x60;  If you just override a specific tier, do not include the &#x60;startingUnit&#x60; field in the request. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>Task of ApiResponse (PUTSubscriptionResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<PUTSubscriptionResponseType>> PUTSubscriptionAsyncWithHttpInfo (string subscriptionKey, PUTSubscriptionType request, string zuoraVersion = null)
        {
            // verify the required parameter 'subscriptionKey' is set
            if (subscriptionKey == null)
                throw new ApiException(400, "Missing required parameter 'subscriptionKey' when calling SubscriptionsApi->PUTSubscription");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling SubscriptionsApi->PUTSubscription");

            var localVarPath = "/subscriptions/{subscription-key}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (subscriptionKey != null) localVarPathParams.Add("subscription-key", Configuration.ApiClient.ParameterToString(subscriptionKey)); // path parameter
            if (zuoraVersion != null) localVarHeaderParams.Add("zuora-version", Configuration.ApiClient.ParameterToString(zuoraVersion)); // header parameter
            if (request != null && request.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(request); // http body (model) parameter
            }
            else
            {
                localVarPostBody = request; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PUTSubscription", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<PUTSubscriptionResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (PUTSubscriptionResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(PUTSubscriptionResponseType)));
            
        }

        /// <summary>
        /// Resume subscription This REST API reference describes how to resume a suspended subscription.   This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://suport.zuora.com).  
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID. Subscription status must be Active.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>PUTSubscriptionResumeResponseType</returns>
        public PUTSubscriptionResumeResponseType PUTSubscriptionResume (string subscriptionKey, PUTSubscriptionResumeType request, string zuoraVersion = null)
        {
             ApiResponse<PUTSubscriptionResumeResponseType> localVarResponse = PUTSubscriptionResumeWithHttpInfo(subscriptionKey, request, zuoraVersion);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Resume subscription This REST API reference describes how to resume a suspended subscription.   This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://suport.zuora.com).  
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID. Subscription status must be Active.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>ApiResponse of PUTSubscriptionResumeResponseType</returns>
        public ApiResponse< PUTSubscriptionResumeResponseType > PUTSubscriptionResumeWithHttpInfo (string subscriptionKey, PUTSubscriptionResumeType request, string zuoraVersion = null)
        {
            // verify the required parameter 'subscriptionKey' is set
            if (subscriptionKey == null)
                throw new ApiException(400, "Missing required parameter 'subscriptionKey' when calling SubscriptionsApi->PUTSubscriptionResume");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling SubscriptionsApi->PUTSubscriptionResume");

            var localVarPath = "/subscriptions/{subscription-key}/resume";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (subscriptionKey != null) localVarPathParams.Add("subscription-key", Configuration.ApiClient.ParameterToString(subscriptionKey)); // path parameter
            if (zuoraVersion != null) localVarHeaderParams.Add("zuora-version", Configuration.ApiClient.ParameterToString(zuoraVersion)); // header parameter
            if (request != null && request.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(request); // http body (model) parameter
            }
            else
            {
                localVarPostBody = request; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PUTSubscriptionResume", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<PUTSubscriptionResumeResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (PUTSubscriptionResumeResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(PUTSubscriptionResumeResponseType)));
            
        }

        /// <summary>
        /// Resume subscription This REST API reference describes how to resume a suspended subscription.   This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://suport.zuora.com).  
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID. Subscription status must be Active.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>Task of PUTSubscriptionResumeResponseType</returns>
        public async System.Threading.Tasks.Task<PUTSubscriptionResumeResponseType> PUTSubscriptionResumeAsync (string subscriptionKey, PUTSubscriptionResumeType request, string zuoraVersion = null)
        {
             ApiResponse<PUTSubscriptionResumeResponseType> localVarResponse = await PUTSubscriptionResumeAsyncWithHttpInfo(subscriptionKey, request, zuoraVersion);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Resume subscription This REST API reference describes how to resume a suspended subscription.   This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://suport.zuora.com).  
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID. Subscription status must be Active.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>Task of ApiResponse (PUTSubscriptionResumeResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<PUTSubscriptionResumeResponseType>> PUTSubscriptionResumeAsyncWithHttpInfo (string subscriptionKey, PUTSubscriptionResumeType request, string zuoraVersion = null)
        {
            // verify the required parameter 'subscriptionKey' is set
            if (subscriptionKey == null)
                throw new ApiException(400, "Missing required parameter 'subscriptionKey' when calling SubscriptionsApi->PUTSubscriptionResume");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling SubscriptionsApi->PUTSubscriptionResume");

            var localVarPath = "/subscriptions/{subscription-key}/resume";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (subscriptionKey != null) localVarPathParams.Add("subscription-key", Configuration.ApiClient.ParameterToString(subscriptionKey)); // path parameter
            if (zuoraVersion != null) localVarHeaderParams.Add("zuora-version", Configuration.ApiClient.ParameterToString(zuoraVersion)); // header parameter
            if (request != null && request.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(request); // http body (model) parameter
            }
            else
            {
                localVarPostBody = request; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PUTSubscriptionResume", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<PUTSubscriptionResumeResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (PUTSubscriptionResumeResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(PUTSubscriptionResumeResponseType)));
            
        }

        /// <summary>
        /// Suspend subscription This REST API reference describes how to suspend an active subscription.   This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://suport.zuora.com). 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID. Subscription status must be Active.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>PUTSubscriptionSuspendResponseType</returns>
        public PUTSubscriptionSuspendResponseType PUTSubscriptionSuspend (string subscriptionKey, PUTSubscriptionSuspendType request, string zuoraVersion = null)
        {
             ApiResponse<PUTSubscriptionSuspendResponseType> localVarResponse = PUTSubscriptionSuspendWithHttpInfo(subscriptionKey, request, zuoraVersion);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Suspend subscription This REST API reference describes how to suspend an active subscription.   This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://suport.zuora.com). 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID. Subscription status must be Active.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>ApiResponse of PUTSubscriptionSuspendResponseType</returns>
        public ApiResponse< PUTSubscriptionSuspendResponseType > PUTSubscriptionSuspendWithHttpInfo (string subscriptionKey, PUTSubscriptionSuspendType request, string zuoraVersion = null)
        {
            // verify the required parameter 'subscriptionKey' is set
            if (subscriptionKey == null)
                throw new ApiException(400, "Missing required parameter 'subscriptionKey' when calling SubscriptionsApi->PUTSubscriptionSuspend");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling SubscriptionsApi->PUTSubscriptionSuspend");

            var localVarPath = "/subscriptions/{subscription-key}/suspend";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (subscriptionKey != null) localVarPathParams.Add("subscription-key", Configuration.ApiClient.ParameterToString(subscriptionKey)); // path parameter
            if (zuoraVersion != null) localVarHeaderParams.Add("zuora-version", Configuration.ApiClient.ParameterToString(zuoraVersion)); // header parameter
            if (request != null && request.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(request); // http body (model) parameter
            }
            else
            {
                localVarPostBody = request; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PUTSubscriptionSuspend", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<PUTSubscriptionSuspendResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (PUTSubscriptionSuspendResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(PUTSubscriptionSuspendResponseType)));
            
        }

        /// <summary>
        /// Suspend subscription This REST API reference describes how to suspend an active subscription.   This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://suport.zuora.com). 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID. Subscription status must be Active.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>Task of PUTSubscriptionSuspendResponseType</returns>
        public async System.Threading.Tasks.Task<PUTSubscriptionSuspendResponseType> PUTSubscriptionSuspendAsync (string subscriptionKey, PUTSubscriptionSuspendType request, string zuoraVersion = null)
        {
             ApiResponse<PUTSubscriptionSuspendResponseType> localVarResponse = await PUTSubscriptionSuspendAsyncWithHttpInfo(subscriptionKey, request, zuoraVersion);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Suspend subscription This REST API reference describes how to suspend an active subscription.   This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://suport.zuora.com). 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionKey">Subscription number or ID. Subscription status must be Active.</param>
        /// <param name="request"></param>
        /// <param name="zuoraVersion">The minor version of the Zuora REST API. You only need to set this parameter if you use the __collect__ or __invoice__ field. See [REST API Basics](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics) for more information. (optional)</param>
        /// <returns>Task of ApiResponse (PUTSubscriptionSuspendResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<PUTSubscriptionSuspendResponseType>> PUTSubscriptionSuspendAsyncWithHttpInfo (string subscriptionKey, PUTSubscriptionSuspendType request, string zuoraVersion = null)
        {
            // verify the required parameter 'subscriptionKey' is set
            if (subscriptionKey == null)
                throw new ApiException(400, "Missing required parameter 'subscriptionKey' when calling SubscriptionsApi->PUTSubscriptionSuspend");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling SubscriptionsApi->PUTSubscriptionSuspend");

            var localVarPath = "/subscriptions/{subscription-key}/suspend";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (subscriptionKey != null) localVarPathParams.Add("subscription-key", Configuration.ApiClient.ParameterToString(subscriptionKey)); // path parameter
            if (zuoraVersion != null) localVarHeaderParams.Add("zuora-version", Configuration.ApiClient.ParameterToString(zuoraVersion)); // header parameter
            if (request != null && request.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(request); // http body (model) parameter
            }
            else
            {
                localVarPostBody = request; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PUTSubscriptionSuspend", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<PUTSubscriptionSuspendResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (PUTSubscriptionSuspendResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(PUTSubscriptionSuspendResponseType)));
            
        }

        /// <summary>
        /// CRUD: Delete Subscription 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <returns>ProxyDeleteResponse</returns>
        public ProxyDeleteResponse ProxyDELETESubscription (string id)
        {
             ApiResponse<ProxyDeleteResponse> localVarResponse = ProxyDELETESubscriptionWithHttpInfo(id);
             return localVarResponse.Data;
        }

        /// <summary>
        /// CRUD: Delete Subscription 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <returns>ApiResponse of ProxyDeleteResponse</returns>
        public ApiResponse< ProxyDeleteResponse > ProxyDELETESubscriptionWithHttpInfo (string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling SubscriptionsApi->ProxyDELETESubscription");

            var localVarPath = "/object/subscription/{id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (id != null) localVarPathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ProxyDELETESubscription", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ProxyDeleteResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProxyDeleteResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProxyDeleteResponse)));
            
        }

        /// <summary>
        /// CRUD: Delete Subscription 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <returns>Task of ProxyDeleteResponse</returns>
        public async System.Threading.Tasks.Task<ProxyDeleteResponse> ProxyDELETESubscriptionAsync (string id)
        {
             ApiResponse<ProxyDeleteResponse> localVarResponse = await ProxyDELETESubscriptionAsyncWithHttpInfo(id);
             return localVarResponse.Data;

        }

        /// <summary>
        /// CRUD: Delete Subscription 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <returns>Task of ApiResponse (ProxyDeleteResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ProxyDeleteResponse>> ProxyDELETESubscriptionAsyncWithHttpInfo (string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling SubscriptionsApi->ProxyDELETESubscription");

            var localVarPath = "/object/subscription/{id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (id != null) localVarPathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ProxyDELETESubscription", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ProxyDeleteResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProxyDeleteResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProxyDeleteResponse)));
            
        }

        /// <summary>
        /// CRUD: Retrieve Subscription 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="fields">Object fields to return (optional)</param>
        /// <returns>ProxyGetSubscription</returns>
        public ProxyGetSubscription ProxyGETSubscription (string id, string fields = null)
        {
             ApiResponse<ProxyGetSubscription> localVarResponse = ProxyGETSubscriptionWithHttpInfo(id, fields);
             return localVarResponse.Data;
        }

        /// <summary>
        /// CRUD: Retrieve Subscription 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="fields">Object fields to return (optional)</param>
        /// <returns>ApiResponse of ProxyGetSubscription</returns>
        public ApiResponse< ProxyGetSubscription > ProxyGETSubscriptionWithHttpInfo (string id, string fields = null)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling SubscriptionsApi->ProxyGETSubscription");

            var localVarPath = "/object/subscription/{id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (id != null) localVarPathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter
            if (fields != null) localVarQueryParams.Add("fields", Configuration.ApiClient.ParameterToString(fields)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ProxyGETSubscription", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ProxyGetSubscription>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProxyGetSubscription) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProxyGetSubscription)));
            
        }

        /// <summary>
        /// CRUD: Retrieve Subscription 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="fields">Object fields to return (optional)</param>
        /// <returns>Task of ProxyGetSubscription</returns>
        public async System.Threading.Tasks.Task<ProxyGetSubscription> ProxyGETSubscriptionAsync (string id, string fields = null)
        {
             ApiResponse<ProxyGetSubscription> localVarResponse = await ProxyGETSubscriptionAsyncWithHttpInfo(id, fields);
             return localVarResponse.Data;

        }

        /// <summary>
        /// CRUD: Retrieve Subscription 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="fields">Object fields to return (optional)</param>
        /// <returns>Task of ApiResponse (ProxyGetSubscription)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ProxyGetSubscription>> ProxyGETSubscriptionAsyncWithHttpInfo (string id, string fields = null)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling SubscriptionsApi->ProxyGETSubscription");

            var localVarPath = "/object/subscription/{id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (id != null) localVarPathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter
            if (fields != null) localVarQueryParams.Add("fields", Configuration.ApiClient.ParameterToString(fields)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ProxyGETSubscription", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ProxyGetSubscription>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProxyGetSubscription) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProxyGetSubscription)));
            
        }

        /// <summary>
        /// CRUD: Create Subscription 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createRequest"></param>
        /// <returns>ProxyCreateOrModifyResponse</returns>
        public ProxyCreateOrModifyResponse ProxyPOSTSubscription (ProxyCreateSubscription createRequest)
        {
             ApiResponse<ProxyCreateOrModifyResponse> localVarResponse = ProxyPOSTSubscriptionWithHttpInfo(createRequest);
             return localVarResponse.Data;
        }

        /// <summary>
        /// CRUD: Create Subscription 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createRequest"></param>
        /// <returns>ApiResponse of ProxyCreateOrModifyResponse</returns>
        public ApiResponse< ProxyCreateOrModifyResponse > ProxyPOSTSubscriptionWithHttpInfo (ProxyCreateSubscription createRequest)
        {
            // verify the required parameter 'createRequest' is set
            if (createRequest == null)
                throw new ApiException(400, "Missing required parameter 'createRequest' when calling SubscriptionsApi->ProxyPOSTSubscription");

            var localVarPath = "/object/subscription";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (createRequest != null && createRequest.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(createRequest); // http body (model) parameter
            }
            else
            {
                localVarPostBody = createRequest; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ProxyPOSTSubscription", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ProxyCreateOrModifyResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProxyCreateOrModifyResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProxyCreateOrModifyResponse)));
            
        }

        /// <summary>
        /// CRUD: Create Subscription 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createRequest"></param>
        /// <returns>Task of ProxyCreateOrModifyResponse</returns>
        public async System.Threading.Tasks.Task<ProxyCreateOrModifyResponse> ProxyPOSTSubscriptionAsync (ProxyCreateSubscription createRequest)
        {
             ApiResponse<ProxyCreateOrModifyResponse> localVarResponse = await ProxyPOSTSubscriptionAsyncWithHttpInfo(createRequest);
             return localVarResponse.Data;

        }

        /// <summary>
        /// CRUD: Create Subscription 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createRequest"></param>
        /// <returns>Task of ApiResponse (ProxyCreateOrModifyResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ProxyCreateOrModifyResponse>> ProxyPOSTSubscriptionAsyncWithHttpInfo (ProxyCreateSubscription createRequest)
        {
            // verify the required parameter 'createRequest' is set
            if (createRequest == null)
                throw new ApiException(400, "Missing required parameter 'createRequest' when calling SubscriptionsApi->ProxyPOSTSubscription");

            var localVarPath = "/object/subscription";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (createRequest != null && createRequest.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(createRequest); // http body (model) parameter
            }
            else
            {
                localVarPostBody = createRequest; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ProxyPOSTSubscription", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ProxyCreateOrModifyResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProxyCreateOrModifyResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProxyCreateOrModifyResponse)));
            
        }

        /// <summary>
        /// CRUD: Update Subscription 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="modifyRequest"></param>
        /// <returns>ProxyCreateOrModifyResponse</returns>
        public ProxyCreateOrModifyResponse ProxyPUTSubscription (string id, ProxyModifySubscription modifyRequest)
        {
             ApiResponse<ProxyCreateOrModifyResponse> localVarResponse = ProxyPUTSubscriptionWithHttpInfo(id, modifyRequest);
             return localVarResponse.Data;
        }

        /// <summary>
        /// CRUD: Update Subscription 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="modifyRequest"></param>
        /// <returns>ApiResponse of ProxyCreateOrModifyResponse</returns>
        public ApiResponse< ProxyCreateOrModifyResponse > ProxyPUTSubscriptionWithHttpInfo (string id, ProxyModifySubscription modifyRequest)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling SubscriptionsApi->ProxyPUTSubscription");
            // verify the required parameter 'modifyRequest' is set
            if (modifyRequest == null)
                throw new ApiException(400, "Missing required parameter 'modifyRequest' when calling SubscriptionsApi->ProxyPUTSubscription");

            var localVarPath = "/object/subscription/{id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (id != null) localVarPathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter
            if (modifyRequest != null && modifyRequest.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(modifyRequest); // http body (model) parameter
            }
            else
            {
                localVarPostBody = modifyRequest; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ProxyPUTSubscription", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ProxyCreateOrModifyResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProxyCreateOrModifyResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProxyCreateOrModifyResponse)));
            
        }

        /// <summary>
        /// CRUD: Update Subscription 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="modifyRequest"></param>
        /// <returns>Task of ProxyCreateOrModifyResponse</returns>
        public async System.Threading.Tasks.Task<ProxyCreateOrModifyResponse> ProxyPUTSubscriptionAsync (string id, ProxyModifySubscription modifyRequest)
        {
             ApiResponse<ProxyCreateOrModifyResponse> localVarResponse = await ProxyPUTSubscriptionAsyncWithHttpInfo(id, modifyRequest);
             return localVarResponse.Data;

        }

        /// <summary>
        /// CRUD: Update Subscription 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="modifyRequest"></param>
        /// <returns>Task of ApiResponse (ProxyCreateOrModifyResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ProxyCreateOrModifyResponse>> ProxyPUTSubscriptionAsyncWithHttpInfo (string id, ProxyModifySubscription modifyRequest)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling SubscriptionsApi->ProxyPUTSubscription");
            // verify the required parameter 'modifyRequest' is set
            if (modifyRequest == null)
                throw new ApiException(400, "Missing required parameter 'modifyRequest' when calling SubscriptionsApi->ProxyPUTSubscription");

            var localVarPath = "/object/subscription/{id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (id != null) localVarPathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter
            if (modifyRequest != null && modifyRequest.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(modifyRequest); // http body (model) parameter
            }
            else
            {
                localVarPostBody = modifyRequest; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ProxyPUTSubscription", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ProxyCreateOrModifyResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProxyCreateOrModifyResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProxyCreateOrModifyResponse)));
            
        }

    }
}
