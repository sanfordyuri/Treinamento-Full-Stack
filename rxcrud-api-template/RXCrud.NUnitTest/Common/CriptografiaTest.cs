using NUnit.Framework;
using RXCrud.Domain.Exception;
using RXCrud.Service.Common;

namespace RXCrud.NUnitTest.Common
{
    public class CriptografiaTest
    {
        [Test]
        [TestCase("nQm92qSBD7TDIhkt5co1YA==", "gleryston123")]
        [TestCase("GzoT50husRZTJjZkQNMvxQ==", "glerystonrxcrud")]
        public void DecryptStringAESTest(string encrypted, string decripted)
            => Assert.IsTrue(Criptografia.DecryptStringAES(encrypted).Equals(decripted));

        [Test]
        public void DecryptStringAESTextoInvalidoTest()
            => Assert.IsTrue(Assert.Throws<RXCrudException>(() => Criptografia.DecryptStringAES(""))
                .Message.Equals("Não foi informado um valor valido para o campo texto."));

        [Test]
        [TestCase("nQm92qSBD7TDIhkt5co1YA==", "gleryston123")]
        [TestCase("GzoT50husRZTJjZkQNMvxQ==", "glerystonrxcrud")]
        public void EncryptStringAESTest(string encrypted, string decripted)
            => Assert.IsTrue(Criptografia.EncryptStringAES(decripted).Equals(encrypted));

        [Test]
        public void EncryptStringAESTextoInvalidoTest()
            => Assert.IsTrue(Assert.Throws<RXCrudException>(() => Criptografia.EncryptStringAES(""))
                .Message.Equals("Não foi informado um valor valido para o campo texto."));
    }
}