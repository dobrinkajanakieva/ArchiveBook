using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DALTests
{
	public class DocumentScanTest
	{
        [Fact]
        public void Test1() //IsValidGetArchiveCodeByID1()
        {
            //Arrange
            var archiveCodeService = new ArchiveCodeService();
            const string Code = "01";
            const string Name = "Основање, организација и развој";

            //Act
            ArchiveCode code = archiveCodeService.getArchiveCodeByID(1);
            bool isValid = true;
            if (Code != code.Code || Name != code.Name)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive Code with ID=1 is not valid");
        }

        [Fact]
        public void Test2() //IsValidGetArchiveCodeByCode1()
        {
            //Arrange
            var archiveCodeService = new ArchiveCodeService();
            const string Code = "01";
            const string Name = "Основање, организација и развој";

            //Act
            ArchiveCode code = archiveCodeService.getArchiveCodeByCode(Code);
            bool isValid = true;
            if (Code != code.Code || Name != code.Name)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive Code with Code=01 is not valid");
        }

        [Fact]
        public void Test3() //IsValidInsertArchiveCodeByCode()
        {
            //Arrange
            var archiveCodeService = new ArchiveCodeService();
            const string Code = "09";
            const string Name = "test9";

            //Act
            ArchiveCode code = new ArchiveCode(100, Code, Name);
            archiveCodeService.InsertArchiveCode(code);
            code = archiveCodeService.getArchiveCodeByCode(Code);
            bool isValid = true;
            if (Code != code.Code || Name != code.Name)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive Code with Code=09 is not valid");
        }

        [Fact]
        public void Test4() //IsValidUpdateArchiveCodeByCode()
        {
            //Arrange
            var archiveCodeService = new ArchiveCodeService();
            const string Code = "09";
            const string Name = "updated";

            //Act
            ArchiveCode code = new ArchiveCode(100, Code, Name);
            archiveCodeService.UpdateArchiveCodeByCode(Code, code);
            code = archiveCodeService.getArchiveCodeByCode(Code);
            bool isValid = true;
            if (code.Code != Code || code.Name != Name)
                isValid = false;

            archiveCodeService.DeleteArchiveCodeByCode(Code);
            //Assert
            Assert.True(isValid, "The Archive Code with Code=09 is not valid");
        }

        [Fact]
        public void Test5() //IsValidDeleteArchiveCodeByCode()
        {
            //Arrange
            var archiveCodeService = new ArchiveCodeService();
            const string Code = "09";
            const string Name = "test9";

            //Act
            ArchiveCode code = new ArchiveCode(100, Code, Name);
            archiveCodeService.UpdateArchiveCodeByCode(Code, code);
            archiveCodeService.DeleteArchiveCodeByCode(Code);
            code = archiveCodeService.getArchiveCodeByCode(Code);
            bool isValid = true;
            if (code.Code != null || code.Name != null)
                isValid = false;
            if (code.Code == Code || code.Name == Name)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive Code with Code=09 is not valid");
        }
    }
}
