using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Loggr;

namespace tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class Fluent
    {
        [TestMethod]
        public void Fluent_CreateEvent()
        {
            var e = Events.Create();
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_CreatEventFromException()
        {
            var ex = new ApplicationException();
            var e = Events.CreateFromException(ex);
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_CreatEventFromVariable()
        {
            string foo = "foo";
            var e = Events.CreateFromVariable(foo);
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_Event()
        {
            var e = Events.Create().Event;
            Assert.IsNotNull(e);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void Fluent_PostNoText()
        {
            TestLogClient client = new TestLogClient();
            var e = Events.Create().UseLogClient(client).Post();
        }

        [TestMethod]
        public void Fluent_Post()
        {
            TestLogClient client = new TestLogClient();
            var e = Events.Create().UseLogClient(client).Text("foo").Post();
            client.AssertPostWasValid();
            Assert.IsTrue(client.HttpClient.Data["text"] == e.Event.Text);
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_PostDefaultAsync()
        {
            TestLogClient client = new TestLogClient();
            var e = Events.Create().UseLogClient(client).Text("foo").Post();
            Assert.IsTrue(client.WasAsync == true);
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_PostAsync()
        {
            TestLogClient client = new TestLogClient();
            var e = Events.Create().UseLogClient(client).Text("foo").Post(true);
            Assert.IsTrue(client.WasAsync == true);
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_PostSync()
        {
            TestLogClient client = new TestLogClient();
            var e = Events.Create().UseLogClient(client).Text("foo").Post(false);
            Assert.IsTrue(client.WasAsync == false);
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_Clear()
        {
            var e = Events.Create().Clear();
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_UseLog()
        {
            var e = Events.Create().UseLog("test", "test");
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_Text()
        {
            var e = Events.Create().Text("test");
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_TextFormatted()
        {
            var e = Events.Create().Text("test", 1, 2, 3);
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_AddText()
        {
            var e = Events.Create().AddText("test");
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_AddTextFormatted()
        {
            var e = Events.Create().AddText("test", 1, 2, 3);
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_Link()
        {
            var e = Events.Create().Link("test");
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_Source()
        {
            var e = Events.Create().Source("test");
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_Tags()
        {
            var e = Events.Create().Tags("test");
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_TagsArray()
        {
            var e = Events.Create().Tags(new string[] {"test", "foo"});
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_AddTags()
        {
            var e = Events.Create().AddTags("test");
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_AddTagsArray()
        {
            var e = Events.Create().AddTags(new string[] { "test", "foo" });
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_Value()
        {
            var e = Events.Create().Value(123);
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_ValueClear()
        {
            var e = Events.Create().ValueClear();
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_Data()
        {
            var e = Events.Create().Data("test");
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_DataFormatted()
        {
            var e = Events.Create().Data("test", 1, 2, 3);
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_AddData()
        {
            var e = Events.Create().AddData("test");
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_AddDataFormatted()
        {
            var e = Events.Create().AddData("test", 1, 2, 3);
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_Geo()
        {
            var e = Events.Create().Geo(-123.456, -123.456);
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_GeoText()
        {
            var e = Events.Create().Geo("-123.456", "-123.456");
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_GeoClear()
        {
            var e = Events.Create().GeoClear();
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_DataType()
        {
            var e = Events.Create().DataType(DataType.html);
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Fluent_Several()
        {
            TestLogClient client = new TestLogClient();
            var ev = Events.Create().UseLogClient(client)
                    .Text("test")
                    .AddText("test")
                    .Link("test")
                    .Source("test")
                    .Tags("test")
                    .AddTags("test test")
                    .Value(123)
                    .Data("test")
                    .AddData("test")
                    .Geo(-123.456, -123.456)
                    .Geo("-123.456", "-123.456")
                    .Post()
                    .Event;
            client.AssertPostWasValid();
            Assert.IsTrue(client.HttpClient.Data["text"] == ev.Text);
            Assert.IsTrue(client.HttpClient.Data["link"] == ev.Link);
            Assert.IsTrue(client.HttpClient.Data["source"] == ev.Source);
            Assert.IsTrue(client.HttpClient.Data["tags"] == string.Join(" ", ev.Tags.ToArray()));
            Assert.IsTrue(client.HttpClient.Data["value"] == ev.Value.ToString());
            Assert.IsTrue(client.HttpClient.Data["data"] == ev.Data);
            Assert.IsTrue(client.HttpClient.Data["geo"] == ev.Geo);
            Assert.IsNotNull(ev);
        }
    }
}
