using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BatchAPI.Entities;
using BatchAPI.Services;
using FakeItEasy;
using Microsoft.AspNetCore.Http;

namespace BatchProject.Test
{
    public class BatchControllerTest
    {
        
        [SetUp]
        public void SetUp()
        {
            
        }
        [Test]
        public void TestAddBatch()
        {
            IBatchServices batchServices = A.Fake<IBatchServices>();
            AddBatchResponse objAddBatchResponse = A.Fake<AddBatchResponse>();
            A.CallTo(() => batchServices.PostBatch(A<BatchRequest>._, A<IFormFile>._));
            Assert.IsNotNull(objAddBatchResponse);
        }
        [Test]
        public void TestGetBatch()
        {
            IBatchServices batchServices = A.Fake<IBatchServices>();
            Batch objbatch = A.Fake<Batch>();
            A.CallTo(() => batchServices.GetBatch(A<Guid>._));
            Assert.IsNotNull (objbatch);
        }
    }
}
