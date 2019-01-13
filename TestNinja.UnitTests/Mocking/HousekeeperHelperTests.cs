using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class HousekeeperHelperTests
    {
        Housekeeper housekeeper;
        Mock<IUnitOfWork> unitOfWork;
        [SetUp]
        public void Setup()
        {
            housekeeper = new Housekeeper { Email = "a@a.com", FullName = "a", Oid = 1, StatementEmailBody = "body" };
            unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(u => u.Query<Housekeeper>()).Returns(new List<Housekeeper> { housekeeper }.AsQueryable());
        }
        [Test]
        public void SendStatementEmails_StatementNotFound_ReturnsFalse()
        {
            var statementGenerator = new Mock<IStatementGenerator>();
            statementGenerator.Setup(s => s.SaveStatement(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>())).Returns("");
            var emailer = new Mock<IEmailer>();
            emailer.Setup(e => e.Email(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(u => u.Query<Housekeeper>()).Returns(new List<Housekeeper>().AsQueryable());
            var result = HousekeeperHelper.SendStatementEmails(unitOfWork.Object, statementGenerator.Object, emailer.Object, DateTime.Now);

            unitOfWork.Verify(u => u.Query<Housekeeper>());
            //emailer.Verify(e => e.Email(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            //statementGenerator.Verify(s => s.SaveStatement(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>()));
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void SendStatementEmails_StatementNotFound_ShouldReturnsFalse()
        {
            var statementGenerator = new Mock<IStatementGenerator>();
            statementGenerator.Setup(s => s.SaveStatement(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>())).Returns("");
            var emailer = new Mock<IEmailer>();
            emailer.Setup(e => e.Email(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(u => u.Query<Housekeeper>()).Returns(new List<Housekeeper>().AsQueryable());
            var result = HousekeeperHelper.SendStatementEmails(unitOfWork.Object, statementGenerator.Object, emailer.Object, DateTime.Now);

            unitOfWork.Verify(u => u.Query<Housekeeper>());
            //emailer.Verify(e => e.Email(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            //statementGenerator.Verify(s => s.SaveStatement(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>()));
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void SendStatementEmails_StatementFoundButFileNotSaved_ShouldCallSaveStatementShouldNotCallEmailAndReturnsTrue()
        {
            var statementGenerator = new Mock<IStatementGenerator>();
            statementGenerator.Setup(s => s.SaveStatement(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>())).Returns("");
            var emailer = new Mock<IEmailer>();
            emailer.Setup(e => e.Email(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));

            var result = HousekeeperHelper.SendStatementEmails(unitOfWork.Object, statementGenerator.Object, emailer.Object, DateTime.Now);

            unitOfWork.Verify(u => u.Query<Housekeeper>());
            emailer.Verify(e => e.Email(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            statementGenerator.Verify(s => s.SaveStatement(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>()));
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void SendStatementEmails_StatementFoundFileSaved_ShouldCallSaveStatementShouldCallEmailAndReturnsTrue()
        {
            var statementGenerator = new Mock<IStatementGenerator>();
            statementGenerator.Setup(s => s.SaveStatement(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>())).Returns("saved");
            var emailer = new Mock<IEmailer>();
            emailer.Setup(e => e.Email(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));

            var result = HousekeeperHelper.SendStatementEmails(unitOfWork.Object, statementGenerator.Object, emailer.Object, DateTime.Now);

            unitOfWork.Verify(u => u.Query<Housekeeper>());
            emailer.Verify(e => e.Email(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            statementGenerator.Verify(s => s.SaveStatement(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>()));
            Assert.That(result, Is.EqualTo(true));
        }
    }
}
