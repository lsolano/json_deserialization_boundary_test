using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace JsonParseTest
{
    [DataContract]
    public class DummyPoco
    {
        private ISet<int> internalSet01;
        private ISet<int> internalSet02;

        public DummyPoco()
        {
            internalSet01 = new HashSet<int>();
            internalSet02 = new HashSet<int>();
        }

        [DataMember]
        [JsonProperty("fakeList01", ObjectCreationHandling = ObjectCreationHandling.Replace)]
        public List<int> FakeList01
        {
            get
            {
                return this.internalSet01.ToList();
            }
            set
            {
                var safeList = (value ?? new List<int>());
                this.internalSet01 = new HashSet<int>(safeList);
            }
        }

        [DataMember]
        [JsonProperty("fakeList02")]
        public List<int> FakeList02
        {
            get
            {
                return this.internalSet02.ToList();
            }
            set
            {
                var safeList = (value ?? new List<int>());
                this.internalSet02 = new HashSet<int>(safeList);
            }
        }

        [DataMember]
        [JsonProperty("realList")]
        public List<int> RealList { get; set; }
    }
}
