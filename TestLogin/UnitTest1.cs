using BUS;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject
{
    [TestClass]
    public class LoginFormTests
    {


        [TestMethod]
        public void TestLogin_KhongNhapMatKhau()
        {
            // Arrange
            BUS_TaiKhoan loginForm = new BUS_TaiKhoan();
            string username = "abc";
            string password = "";

            // Act
            bool result = loginForm.kiemTraTK(username, password);

            // Assert
            Assert.AreEqual(result, false);
        }
        [TestMethod]
        public void TestLogin_KhongNhapTenTaiKhoan()
        {
            // Arrange
            BUS_TaiKhoan loginForm = new BUS_TaiKhoan();
            string username = "";
            string password = "abc";

            // Act
            bool result = loginForm.kiemTraTK(username, password);

            // Assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TestLogin_KhongNhapTenTaiKhoan_MatKhau()
        {
            // Arrange
            BUS_TaiKhoan loginForm = new BUS_TaiKhoan();
            string username = "";
            string password = "";

            // Act
            bool result = loginForm.kiemTraTK(username, password);

            // Assert
            Assert.AreEqual(result, false);
        }
        [TestMethod]
        public void TestLogin_NhapSaiMatKhau()
        {
            // Arrange
            BUS_TaiKhoan loginForm = new BUS_TaiKhoan();
            string username = "ql01";
            string password = "abc";

            // Act
            bool result = loginForm.kiemTraTK(username, password);

            // Assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TestLogin_NhapSaiTaiKhoan()
        {
            // Arrange
            BUS_TaiKhoan loginForm = new BUS_TaiKhoan();
            string username = "abc";
            string password = "123";

            // Act
            bool result = loginForm.kiemTraTK(username, password);

            // Assert
            Assert.AreEqual(result, false);
        }
        [TestMethod]
        public void TestLogin_NhapDung()
        {
            // Arrange
            BUS_TaiKhoan loginForm = new BUS_TaiKhoan();
            string username = "admin";
            string password = "admin";

            // Act
            bool result = loginForm.kiemTraTK(username, password);

            // Assert
            Assert.IsTrue(result);
        }

    }
}