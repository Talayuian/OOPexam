using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace OOPeksamen2
{
    class TestUser
    {
        [TestFixture]
        class Test
        {
            #region Firstname

            [Test]
            public void UserFirstNameNormal()
            {
                bool success = true;

                try
                {
                    User user = new User(1, "Daniel", "Sørensen", "Talayuian", "Daniel.Sørensen@gmail.com",0);
                }
                catch (Exception)
                {
                    success = false;
                }

                Assert.AreEqual(true, success);
            }

            [Test]
            public void UserFirstNameNull()
            {
                bool success = true;

                try
                {
                    User user = new User(1, null, "Sørensen", "Talayuian", "Daniel.Sørensen@gmail.com",0);
                }
                catch (Exception)
                {
                    success = false;
                }

                Assert.AreEqual(false, success);
            }

            [Test]
            public void UserFirstNameEmpty()
            {
                bool success = true;

                try
                {
                    User user = new User(1, "", "Sørensen", "Talayuian", "Daniel.Sørensen@gmail.com",0);
                }
                catch (Exception)
                {
                    success = false;
                }

                Assert.AreEqual(false, success);

            }

            #endregion
            #region LastName

            [Test]
            public void UserLastNameNormal()
            {
                bool success = true;

                try
                {
                    User user = new User(1, "Daniel", "Sørensen", "Talayuian", "Daniel.Sørensen@gmail.com",0);
                }
                catch
                {
                    success = false;
                }

                Assert.AreEqual(true, success);
            }

            [Test]
            public void UserLastNameNull()
            {
                bool success = true;

                try
                {
                    User user = new User(1, "Daniel", null, "Talayuian", "Daniel.Sørensen@gmail.com",0);
                }
                catch
                {
                    success = false;
                }

                Assert.AreEqual(false, success);
            }

            [Test]
            public void UserLastNameEmpty()
            {
                bool success = true;

                try
                {
                    User user = new User(1, "Daniel", "", "Talayuian", "Daniel.Sørensen@gmail.com",0);
                }
                catch
                {
                    success = false;
                }

                Assert.AreEqual(false, success);
            }

            #endregion
            #region Username

            [Test]
            public void UserUsernameNormal()
            {
                bool success = true;

                try
                {
                    User user = new User(1, "Daniel", "Sørensen", "Talayuian", "Daniel.Sørensen@gmail.com",0);
                }
                catch (Exception)
                {
                    success = false;
                }

                Assert.AreEqual(true, success);
            }

            #endregion
            #region Email
            [Test]
            public void UserEMailNormal()
            {
                bool success = true;

                try
                {
                    User user = new User(1, "Daniel", "Sørensen", "Talayuian", "Daniel.Sørensen@gmail.com",0);
                }
                catch (Exception)
                {
                    success = false;
                }

                Assert.AreEqual(true, success);
            }

            [Test]
            public void UserEMail2At()
            {
                bool success = true;

                try
                {
                    User user = new User(1, "Daniel", "Sørensen", "Talayuian", "Daniel.Sørensen@gmail@me.com",0);
                }
                catch (Exception)
                {
                    success = false;
                }

                Assert.AreEqual(false, success);
            }

            [Test]
            public void UserEMailStartDot()
            {
                bool success = true;

                try
                {
                    User user = new User(1, "Daniel", "Sørensen", "Talayuian", "Daniel.Sørensen@.gmail.com",0);
                }
                catch (Exception)
                {
                    success = false;
                }

                Assert.AreEqual(false, success);
            }

            [Test]
            public void UserEMailIlligalCharacter()
            {
                bool success = true;

                try
                {
                    User user = new User(1, "Daniel", "Sørensen", "Talayuian", "Daniel.Sørensen@.gm#¤%&/a#il.com",0);
                }
                catch (Exception)
                {
                    success = false;
                }

                Assert.AreEqual(false, success);
            }

            [Test]
            public void UserEMailLocal()
            {
                bool success = true;

                try
                {
                    User user = new User(1, "Daniel", "Sørensen", "Talayuian", "dani$el.Sørensen@gmail.com",0);
                }
                catch (Exception)
                {
                    success = false;
                }

                Assert.AreEqual(false, success);
            }

            [Test]
            public void UserEMailSlash()
            {
                bool success = true;

                try
                {
                    User user = new User(1, "Daniel", "Sørensen", "Talayuian", "Daniel.Sørensen@gma/il.com",0);
                }
                catch (Exception)
                {
                    success = false;
                }

                Assert.AreEqual(false, success);
            }

            #endregion
        }
    }
}
