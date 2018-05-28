/*
 * MessageMediaMessages.Tests
 *
 * This file was automatically generated for MessageMedia by APIMATIC v2.0 ( https://apimatic.io )
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using APIMATIC.SDK.Common; 
using APIMATIC.SDK.Http.Client;
using APIMATIC.SDK.Http.Response;
using MessageMedia.Messages.Helpers;
using NUnit.Framework;
using MessageMedia.Messages;
using MessageMedia.Messages.Controllers;

namespace MessageMedia.Messages
{
    [TestFixture]
    public class RepliesControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests)
        /// </summary>
        private static IRepliesController controller;

        /// <summary>
        /// Setup test class
        /// </summary>
        [SetUp]
        public static void SetUpClass()
        {
            controller = GetClient().Replies;
        }

        /// <summary>
        /// Check for any replies that have been received.
        ///Replies are messages that have been sent from a handset in response to a message sent by an
        ///application or messages that have been sent from a handset to a inbound number associated with
        ///an account, known as a dedicated inbound number (contact <support@messagemedia.com> for more
        ///information on dedicated inbound numbers).
        ///Each request to the check replies endpoint will return any replies received that have not yet
        ///been confirmed using the confirm replies endpoint. A response from the check replies endpoint
        ///will have the following structure:
        ///```json
        ///{
        ///    "replies": [
        ///        {
        ///            "metadata": {
        ///                "key1": "value1",
        ///                "key2": "value2"
        ///            },
        ///            "message_id": "877c19ef-fa2e-4cec-827a-e1df9b5509f7",
        ///            "reply_id": "a175e797-2b54-468b-9850-41a3eab32f74",
        ///            "date_received": "2016-12-07T08:43:00.850Z",
        ///            "callback_url": "https://my.callback.url.com",
        ///            "destination_number": "+61491570156",
        ///            "source_number": "+61491570157",
        ///            "vendor_account_id": {
        ///                "vendor_id": "MessageMedia",
        ///                "account_id": "MyAccount"
        ///            },
        ///            "content": "My first reply!"
        ///        },
        ///        {
        ///            "metadata": {
        ///                "key1": "value1",
        ///                "key2": "value2"
        ///            },
        ///            "message_id": "8f2f5927-2e16-4f1c-bd43-47dbe2a77ae4",
        ///            "reply_id": "3d8d53d8-01d3-45dd-8cfa-4dfc81600f7f",
        ///            "date_received": "2016-12-07T08:43:00.850Z",
        ///            "callback_url": "https://my.callback.url.com",
        ///            "destination_number": "+61491570157",
        ///            "source_number": "+61491570158",
        ///            "vendor_account_id": {
        ///                "vendor_id": "MessageMedia",
        ///                "account_id": "MyAccount"
        ///            },
        ///            "content": "My second reply!"
        ///        }
        ///    ]
        ///}
        ///```
        ///Each reply will contain details about the reply message, as well as details of the message the reply was sent
        ///in response to, including any metadata specified. Every reply will have a reply ID to be used with the
        ///confirm replies endpoint.
        ///*Note: The source number and destination number properties in a reply are the inverse of those
        ///specified in the message the reply is in response to. The source number of the reply message is the
        ///same as the destination number of the original message, and the destination number of the reply
        ///message is the same as the source number of the original message. If a source number
        ///wasn't specified in the original message, then the destination number property will not be present
        ///in the reply message.*
        ///Subsequent requests to the check replies endpoint will return the same reply messages and a maximum
        ///of 100 replies will be returned in each request. Applications should use the confirm replies endpoint
        ///in the following pattern so that replies that have been processed are no longer returned in
        ///subsequent check replies requests.
        ///1. Call check replies endpoint
        ///2. Process each reply message
        ///3. Confirm all processed reply messages using the confirm replies endpoint
        ///*Note: It is recommended to use the Webhooks feature to receive reply messages rather than polling
        ///the check replies endpoint.* 
        /// </summary>
        [Test]
        public async Task TestCheckReplies1() 
        {

            // Perform API call
            Messages.Models.CheckRepliesResponse result = null;

            try
            {
                result = await controller.GetCheckRepliesAsync();
            }
            catch(APIException) {};

            // Test response code
            Assert.AreEqual(200, httpCallBackHandler.Response.StatusCode,
                    "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", null);

            Assert.IsTrue(TestHelper.AreHeadersProperSubsetOf (
                    headers, httpCallBackHandler.Response.Headers),
                    "Headers should match");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");

            Assert.AreEqual("{  \"replies\": [    {      \"metadata\": {        \"key1\": \"value1\",        \"key2\": \"value2\"      },      \"message_id\": \"877c19ef-fa2e-4cec-827a-e1df9b5509f7\",      \"reply_id\": \"a175e797-2b54-468b-9850-41a3eab32f74\",      \"date_received\": \"2016-12-07T08:43:00.850Z\",      \"callback_url\": \"https://my.callback.url.com\",      \"destination_number\": \"+61491570156\",      \"source_number\": \"+61491570157\",      \"vendor_account_id\": {        \"vendor_id\": \"MessageMedia\",        \"account_id\": \"MyAccount\"      },      \"content\": \"My first reply!\"    },    {      \"metadata\": {        \"key1\": \"value1\",        \"key2\": \"value2\"      },      \"message_id\": \"8f2f5927-2e16-4f1c-bd43-47dbe2a77ae4\",      \"reply_id\": \"3d8d53d8-01d3-45dd-8cfa-4dfc81600f7f\",      \"date_received\": \"2016-12-07T08:43:00.850Z\",      \"callback_url\": \"https://my.callback.url.com\",      \"destination_number\": \"+61491570157\",      \"source_number\": \"+61491570158\",      \"vendor_account_id\": {        \"vendor_id\": \"MessageMedia\",        \"account_id\": \"MyAccount\"      },      \"content\": \"My second reply!\"    }  ]}", 
                    TestHelper.ConvertStreamToString(httpCallBackHandler.Response.RawBody),
                    "Response body should match exactly (string literal match)");
        }

        /// <summary>
        /// Mark a reply message as confirmed so it is no longer returned in check replies requests.
        ///The confirm replies endpoint is intended to be used in conjunction with the check replies endpoint
        ///to allow for robust processing of reply messages. Once one or more reply messages have been processed
        ///they can then be confirmed using the confirm replies endpoint so they are no longer returned in
        ///subsequent check replies requests.
        ///The confirm replies endpoint takes a list of reply IDs as follows:
        ///```json
        ///{
        ///    "reply_ids": [
        ///        "011dcead-6988-4ad6-a1c7-6b6c68ea628d",
        ///        "3487b3fa-6586-4979-a233-2d1b095c7718",
        ///        "ba28e94b-c83d-4759-98e7-ff9c7edb87a1"
        ///    ]
        ///}
        ///```
        ///Up to 100 replies can be confirmed in a single confirm replies request. 
        /// </summary>
        [Test]
        public async Task TestConfirmRepliesAsReceived1() 
        {
            // Parameters for the API call
            Messages.Models.ConfirmRepliesAsReceivedRequest body = APIHelper.JsonDeserialize<Messages.Models.ConfirmRepliesAsReceivedRequest>("{    \"reply_ids\": [        \"011dcead-6988-4ad6-a1c7-6b6c68ea628d\",        \"3487b3fa-6586-4979-a233-2d1b095c7718\",        \"ba28e94b-c83d-4759-98e7-ff9c7edb87a1\"    ]}");

            // Perform API call
            dynamic result = null;

            try
            {
                result = await controller.CreateConfirmRepliesAsReceivedAsync(body);
            }
            catch(APIException) {};

            // Test response code
            Assert.AreEqual(202, httpCallBackHandler.Response.StatusCode,
                    "Status should be 202");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", null);

            Assert.IsTrue(TestHelper.AreHeadersProperSubsetOf (
                    headers, httpCallBackHandler.Response.Headers),
                    "Headers should match");

        }

    }
}