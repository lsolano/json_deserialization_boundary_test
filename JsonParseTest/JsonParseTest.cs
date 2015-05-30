using Newtonsoft.Json;
using NUnit.Framework;
using System.Linq;

namespace JsonParseTest
{
    [TestFixture]
    public class JsonDeserializeTestWithObjectCreationHandling
    {
        [Test]
        public void Test_Copy_Getter_And_ObjectCreationHandling_Replace()
        {
            var json = @" { ""fakeList01"": [ 1, 1, 2, 2, 3, 3 ] } ";
            var poco = JsonConvert.DeserializeObject<DummyPoco>(json);

            var arr = new int[] { 1, 2, 3 };
            Assert.AreEqual(3, poco.FakeList01.Count);
            Assert.True(poco.FakeList01.All(elem => arr.Contains(elem)));
        }

        [Test]
        public void Test_Copy_Getter_And_ObjectCreationHandling_Auto()
        {
            var json = @" { ""fakeList02"": [ 1, 1, 2, 2, 3, 3 ] } ";
            var poco = JsonConvert.DeserializeObject<DummyPoco>(json);

            Assert.AreEqual(0, poco.FakeList02.Count);
        }

        [Test]
        public void Test_Default_Getter_And_ObjectCreationHandling_Auto()
        {
            var json = @" { ""realList"": [ 1, 1, 2, 2, 3, 3 ] } ";
            var poco = JsonConvert.DeserializeObject<DummyPoco>(json);

            var arr = new int[] { 1, 2, 3 };
            Assert.AreEqual(6, poco.RealList.Count);
            Assert.True(poco.RealList.All(elem => arr.Contains(elem)));
        }

        [Test]
        public void Test_Copy_Getter_Not_Present_In_Json_And_ObjectCreationHandling_Replace()
        {
            var json = @" { ""realList"": [ 1, 1, 2, 2, 3, 3 ] } ";
            var poco = JsonConvert.DeserializeObject<DummyPoco>(json);

            Assert.IsNotNull(poco.FakeList01);
            Assert.AreEqual(0, poco.FakeList01.Count);
        }

        [Test]
        public void Test_Copy_Getter_Not_Present_In_Json_And_ObjectCreationHandling_Auto()
        {
            var json = @" { ""realList"": [ 1, 1, 2, 2, 3, 3 ] } ";
            var poco = JsonConvert.DeserializeObject<DummyPoco>(json);

            Assert.IsNotNull(poco.FakeList02);
            Assert.AreEqual(0, poco.FakeList02.Count);
        }

        [Test]
        public void Test_Default_Getter_Not_Present_In_Json()
        {
            var json = @" { ""fakeList01"": [ 1, 1, 2, 2, 3, 3 ] } ";
            var poco = JsonConvert.DeserializeObject<DummyPoco>(json);

            Assert.IsNull(poco.RealList);
        }

        [Test]
        public void Test_Deserialize_All()
        {
            var json = @" { ""fakeList01"": [ 1, 1, 2, 2, 3, 3 ], ""realList"": [ 1, 1, 2, 2, 3, 3 ], ""fakeList02"": [ 1, 1, 2, 2, 3, 3 ] } ";
            var poco = JsonConvert.DeserializeObject<DummyPoco>(json);

            var arr = new int[] { 1, 2, 3 };
            Assert.AreEqual(6, poco.RealList.Count);
            Assert.True(poco.RealList.All(elem => arr.Contains(elem)));

            Assert.AreEqual(3, poco.FakeList01.Count);
            Assert.True(poco.FakeList01.All(elem => arr.Contains(elem)));

            Assert.AreEqual(0, poco.FakeList02.Count);
            Assert.True(poco.FakeList02.All(elem => arr.Contains(elem)));
        }
    }
}
