using Idigao.TestAuthetification.Core.Entites;
using Idigao.TestAuthetification.Core.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Idigao.TestAuthetification.TestUnit
{
    public class TestUnitaire
    {
        private readonly string _login = "karmil.omar@gmail.com";
        private readonly string _mdp = "P@ssw0rd";
        private Mock<IAuthetificationServices> _mockAuthentification;

        public TestUnitaire()
        {
            _mockAuthentification = new Mock<IAuthetificationServices>();
        }

        [Fact]
        public void Authorisation()
        {
            var result = GetTestList().AsQueryable().Where(e => e.Email == _login && e.Password == _mdp).FirstOrDefault();
            var test = new User { Email = "karmil.omar@gmail.com", Password = "P@ssw0rd" };
            Assert.NotNull(result);
            
        }
        public List<User> GetTestList()
        {
            return new List<User>()
            {
                new User(){Email="karmil.omar@gmail.com",Password="P@ssw0rd" },
                new User(){Email="karmil.omar2@gmail.com",Password="P@ssw0rd" }
            };
        }

    }
}
