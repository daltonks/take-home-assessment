using System;
using System.Threading.Tasks;
using Coterie.Domain.Quotes;
using Coterie.UnitTests.Base;
using NUnit.Framework;

namespace Coterie.UnitTests
{
    public class QuoteServiceShould : TestsBase
    {
        private static readonly QuoteRequest[] InvalidQuotes =
        {
            // Invalid business
            new()
            {
                Business = null,
                Revenue = 10,
                States = new [] { "TX" }
            },
            new()
            {
                Business = "",
                Revenue = 10,
                States = new [] { "TX" }
            },
            new()
            {
                Business = "FakeBusiness",
                Revenue = 10,
                States = new [] { "TX" }
            },
            
            // Invalid revenue
            new()
            {
                Business = "Plumber",
                Revenue = 0,
                States = new [] { "TX" }
            },
            new()
            {
                Business = "Plumber",
                Revenue = -1,
                States = new [] { "TX" }
            },
            new()
            {
                Business = "Plumber",
                Revenue = -2,
                States = new [] { "TX" }
            },
            
            // Invalid state
            new()
            {
                Business = "Plumber",
                Revenue = 6000000,
                States = new string [] { null }
            },
            new()
            {
                Business = "Plumber",
                Revenue = 6000000,
                States = new [] { "" }
            },
            new()
            {
                Business = "Plumber",
                Revenue = 6000000,
                States = new [] { "FakeState" }
            },
            new()
            {
                Business = "Plumber",
                Revenue = 6000000,
                States = new [] { "FakeState", "TX" }
            },
            new()
            {
                Business = "Plumber",
                Revenue = 6000000,
                States = new [] { "TX", "FakeState" }
            },
            
            // Invalid everything
            new()
            {
                Business = "FakeBusiness",
                Revenue = -100,
                States = new [] { "FakeState" }
            }
        };
        
        private static readonly (QuoteRequest request, PremiumModel[] expectedPremiums)[] ValidQuotes =
        {
            (
                request: new QuoteRequest
                {
                    Business = "Plumber",
                    Revenue = 6000000,
                    States = Array.Empty<string>()
                },
                expectedPremiums: Array.Empty<PremiumModel>()
            ),
            (
                request: new QuoteRequest
                {
                    Business = "Plumber",
                    Revenue = 6000000,
                    States = new[] { "TX" }
                },
                expectedPremiums: new []
                {
                    new PremiumModel
                    {
                        Premium = 11316,
                        State = "TX"
                    }
                }
            ),
            (
                request: new QuoteRequest
                {
                    Business = "Plumber",
                    Revenue = 6000000,
                    States = new[] { "TX", "OH", "FL" }
                },
                expectedPremiums: new []
                {
                    new PremiumModel
                    {
                        Premium = 11316,
                        State = "TX"
                    },
                    new PremiumModel
                    {
                        Premium = 12000,
                        State = "OH"
                    },
                    new PremiumModel
                    {
                        Premium = 14400,
                        State = "FL"
                    }
                }
            ),
            (
                request: new QuoteRequest
                {
                    Business = "plumber",
                    Revenue = 6000000,
                    States = new[] { "ohio", "FLORIDA", "tx" }
                },
                expectedPremiums: new []
                {
                    new PremiumModel
                    {
                        Premium = 12000,
                        State = "OH"
                    },
                    new PremiumModel
                    {
                        Premium = 14400,
                        State = "FL"
                    },
                    new PremiumModel
                    {
                        Premium = 11316,
                        State = "TX"
                    },
                }
            )
        };
        
        [TestCaseSource(nameof(InvalidQuotes))]
        public async Task HandleInvalidQuotes(QuoteRequest request)
        {
            // Act
            var response = await QuoteService.GetAsync(request);

            // Assert
            Assert.IsEmpty(response.Premiums);
            Assert.IsFalse(response.IsSuccessful);
            Assert.IsNotEmpty(response.TransactionId);
            Assert.IsNotEmpty(response.Message);
        }

        [TestCaseSource(nameof(ValidQuotes))]
        public async Task HandleValidQuotes(ValueTuple<QuoteRequest, PremiumModel[]> tuple)
        {
            // Arrange
            var request = tuple.Item1;
            var expectedPremiums = tuple.Item2;
            
            // Act
            var response = await QuoteService.GetAsync(request);
            
            // Assert
            Assert.AreEqual(request.Business, response.Business);
            Assert.AreEqual(request.Revenue, response.Revenue);
            for (var i = 0; i < response.Premiums.Count; i++)
            {
                var premium = response.Premiums[i];
                var expectedPremium = expectedPremiums[i];
                Assert.AreEqual(premium, expectedPremium);
            }
            Assert.IsTrue(response.IsSuccessful);
            Assert.IsNotEmpty(response.TransactionId);
            Assert.IsNull(response.Message);
        }
    }
}