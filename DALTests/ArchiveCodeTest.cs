using DAL;
using Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace DALTests
{
	public class ArchiveCodeTest
	{
		[Fact]
		public void Test1() 
        {
            //Arrange
            var archiveCodeService = new ArchiveCodeService();
            const string Code = "01";
            const string Name = "Основање, организација и развој";

            //Act
            ArchiveCode code = archiveCodeService.GetArchiveCodeByID(1);
            bool isValid = true;
            if (Code != code.Code || Name != code.Name)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive Code with ID=1 is not valid");
        }

        [Fact]
        public void Test2() 
        {
            //Arrange
            var archiveCodeService = new ArchiveCodeService();
            const string Code = "01";
            const string Name = "Основање, организација и развој";

            //Act
            ArchiveCode code = archiveCodeService.GetArchiveCodeByCode(Code);
            bool isValid = true;
            if (Code != code.Code || Name != code.Name)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive Code with Code=01 is not valid");
        }

        [Fact]
        public void Test3() 
        {
            //Arrange
            var archiveCodeService = new ArchiveCodeService();
            const string Code = "09";
            const string Name = "test9";

            //Act
            ArchiveCode code = new ArchiveCode(100, Code, Name);
            archiveCodeService.InsertArchiveCode(code);
            code = archiveCodeService.GetArchiveCodeByCode(Code);
            bool isValid = true;
            if (Code != code.Code || Name != code.Name)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive Code with Code=09 is not valid");
        }

        [Fact]
        public void Test4() 
        {
            //Arrange
            var archiveCodeService = new ArchiveCodeService();
            const string Code = "09";
            const string Name = "updated";

            //Act
            ArchiveCode code = new ArchiveCode(100, Code, Name);
            archiveCodeService.UpdateArchiveCodeByCode(Code, code);
            code = archiveCodeService.GetArchiveCodeByCode(Code);
            bool isValid = true;
            if (code.Code != Code || code.Name != Name)
                isValid = false;

            archiveCodeService.DeleteArchiveCodeByCode(Code);
            //Assert
            Assert.True(isValid, "The Archive Code with Code=09 is not valid");
        }

        [Fact]
        public void Test5() 
        {
            //Arrange
            var archiveCodeService = new ArchiveCodeService();
            const string Code = "09";
            const string Name = "test9";

            //Act
            ArchiveCode code = new ArchiveCode(100, Code, Name);
            archiveCodeService.InsertArchiveCode(code);
            archiveCodeService.DeleteArchiveCodeByCode(Code);
            code = archiveCodeService.GetArchiveCodeByCode(Code);
            bool isValid = true;
            if (code.Code != null || code.Name != null)
                isValid = false;
            if (code.Code == Code || code.Name == Name)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive Code with Code=09 is not valid");
        }

        [Fact]
        public void Test6() 
        {
            //Arrange
            var archiveCodeService = new ArchiveCodeService();
            const string Code1 = "09";
            const string Name1 = "test9";
            const string Code2 = "0901";
            const string Name2 = "test91";
            const string Code3 = "0902";
            const string Name3 = "test92";
            List<ArchiveCode> archiveCodes = new List<ArchiveCode>();
            List<ArchiveCode> result = new List<ArchiveCode>();
            List<string> codes = new List<string>();

            //Act
            ArchiveCode code1 = new ArchiveCode(100, Code1, Name1);
            ArchiveCode code2 = new ArchiveCode(101, Code2, Name2);
            ArchiveCode code3 = new ArchiveCode(102, Code3, Name3);

            archiveCodes.Add(code1);
            archiveCodes.Add(code2);
            archiveCodes.Add(code3);
            
            archiveCodeService.InsertArchiveCodes(archiveCodes);

            codes.Add(Code1);
            codes.Add(Code2);
            codes.Add(Code3);

            result = archiveCodeService.GetArchiveCodesByCodes(codes);

            bool isValid = true;
            foreach(ArchiveCode code in result)
            {
                if(!codes.Contains(code.Code))
                    isValid = false;
            }

            archiveCodeService.DeleteArchiveCodesByCodes(codes);

            //Assert
            Assert.True(isValid, "Not valid");
        }
    }
}
