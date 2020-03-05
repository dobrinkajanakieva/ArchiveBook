using DAL.SQLServer;
using Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace DALTests
{
	public class ArchiveCodeTest
	{
		[Fact]
		public void GetArchiveCodeByID() 
        {
            //Arrange
            var archiveCodeEngine = new ArchiveCodeEngine();
            const string Code = "01";
            const string Name = "Основање, организација и развој";

            //Act
            ArchiveCode code = archiveCodeEngine.GetArchiveCodeByID(1);

            //Assert
            Assert.Equal(Code, code.Code);
            Assert.Equal(Name, code.Name);
        }

        [Fact]
        public void GetArchiveCodeByCode() 
        {
            //Arrange
            var archiveCodeEngine = new ArchiveCodeEngine();
            const string Code = "01";
            const string Name = "Основање, организација и развој";

            //Act
            ArchiveCode code = archiveCodeEngine.GetArchiveCodeByCode(Code);

            //Assert
            Assert.Equal(1, code.ID_ArchiveCode);
            Assert.Equal(Name, code.Name);
        }

        [Fact]
        public void InsertArchiveCode() 
        {
            //Arrange
            var archiveCodeEngine = new ArchiveCodeEngine();
            const string Code = "09";
            const string Name = "test9";

            //Act
            ArchiveCode code = new ArchiveCode(100, Code, Name);
            archiveCodeEngine.InsertArchiveCode(code);
            code = archiveCodeEngine.GetArchiveCodeByCode(Code);

            //Assert
            Assert.Equal(Code, code.Code);
            Assert.Equal(Name, code.Name);
        }

        [Fact]
        public void UpdateArchiveCodeByCode() 
        {
            //Arrange
            var archiveCodeEngine = new ArchiveCodeEngine();
            const string Code = "458";
            const string Name = "updated";

            //Act
            ArchiveCode code = new ArchiveCode(100, Code, Name);
            archiveCodeEngine.UpdateArchiveCodeByCode("456", code);
            code = archiveCodeEngine.GetArchiveCodeByCode(Code);

            //Assert
            Assert.Equal(Code, code.Code);
            Assert.Equal(Name, code.Name);
        }

        [Fact]
        public void DeleteArchiveCodeByCode() 
        {
            //Arrange
            var archiveCodeEngine = new ArchiveCodeEngine();
            const string Code = "7564";

            //Act
            archiveCodeEngine.DeleteArchiveCodeByCode(Code);
            ArchiveCode code = archiveCodeEngine.GetArchiveCodeByCode(Code);

            //Assert
            Assert.Null(code.Code);
            Assert.Null(code.Name);
        }

        [Fact]
        public void InsertArchiveCodes() 
        {
            //Arrange
            var archiveCodeEngine = new ArchiveCodeEngine();
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

            archiveCodeEngine.InsertArchiveCodes(archiveCodes);

            codes.Add(Code1);
            codes.Add(Code2);
            codes.Add(Code3);

            result = archiveCodeEngine.GetArchiveCodesByCodes(codes);

            //Assert
            foreach (ArchiveCode code in result)
            {
                Assert.Contains(code.Code, codes);
            }
        }

        [Fact]
        public void DeleteArchiveCodes()
        {
            //Arrange
            var archiveCodeEngine = new ArchiveCodeEngine();
            const string Code1 = "09";
            const string Code2 = "0901";
            const string Code3 = "0902";
            List<ArchiveCode> result = new List<ArchiveCode>();
            List<string> codes = new List<string>();

            //Act


            codes.Add(Code1);
            codes.Add(Code2);
            codes.Add(Code3);

            archiveCodeEngine.DeleteArchiveCodesByCodes(codes);

            result = archiveCodeEngine.GetArchiveCodesByCodes(codes);

            //Assert
            foreach (ArchiveCode code in result)
            {
                Assert.Null(code.Code);
            }
        }
    }
}
