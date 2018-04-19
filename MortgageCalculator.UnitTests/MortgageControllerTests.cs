
using MortgageCalculator.Api.Controllers;
using MortgageCalculator.Api.Services;
using NUnit.Framework;
using Moq;
using System;
using System.Web.Http;
using System.Web.Http.Results;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MortgageCalculator.Dto;

namespace MortgageCalculator.Api.UnitTests
{
    [TestFixture]
    public class MortgageControllerTests
    {
        [Test]
        public void MortgageControllerExists()
        {
            var mockRepository = new Mock<IMortgageService>();
            var controller = new MortgageController(mockRepository.Object);
            Assert.IsInstanceOf(typeof(MortgageController), controller);
        }

        [Test]
        public void MortgageControllerGetMortgageShouldReturnOKWithResult()
        {
            var listOfMortgage = new List<Mortgage>();
            listOfMortgage.Add(new Mortgage { Name = "Loan", MortgageId = 1,  InterestRate= 8.00m, CancellationFee = 10, EffectiveEndDate = DateTime.Now });

            var mockRepository = new Mock<IMortgageService>();
            mockRepository.Setup(x => x.GetAllMortgages())
                .Returns(listOfMortgage);


            var controller = new MortgageController(mockRepository.Object);

            IHttpActionResult actionResult = controller.Get();

            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<Mortgage>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Count());
        }

        [Test]
        public void MortgageControllerGetMortgageByIdShouldReturnOKWithResult()
        {
            var listOfMortgage = new List<Mortgage>();
            listOfMortgage.Add(new Mortgage { Name = "Loan", MortgageId = 1, InterestRate = 8.00m, CancellationFee = 10, EffectiveEndDate = DateTime.Now });

            var mockRepository = new Mock<IMortgageService>();
            mockRepository.Setup(x => x.GetAllMortgages())
                .Returns(listOfMortgage);


            var controller = new MortgageController(mockRepository.Object);

            IHttpActionResult actionResult = controller.Get(1);

            var contentResult = actionResult as OkNegotiatedContentResult<Mortgage>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.MortgageId);
        }

        [Test]
        public void MortgageControllerGetMortgageByIdShouldReturnOKWithNotFound()
        {

            var mockRepository = new Mock<IMortgageService>();

            var controller = new MortgageController(mockRepository.Object);

            IHttpActionResult actionResult = controller.Get(12312112);

            Assert.IsInstanceOf(typeof(NotFoundResult), actionResult);

        }

    }
}
