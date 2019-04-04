using System;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TesteLerInfoSucesso()
        {
            string nome = "NomeTeste";
            float altura = 1.90f;
            int idade = 15;
            string cidade = "Umuarama";
            string cpf = "1111111111";

            Controller.LerInfo(nome, altura, idade, cidade, cpf);

            Assert.AreEqual(Model.Lista[0], "NomeTeste");
            Assert.AreEqual(Model.Lista[1], 1.90f);
            Assert.AreEqual(Model.Lista[2], 15);
            Assert.AreEqual(Model.Lista[3], "Umuarama");
            Assert.AreEqual(Model.Lista[4], "1111111111");
        }


        [TestMethod]
        public void TesteAcharCadastroPorNomeContemNome()
        {
            string nome = "NomeTeste";
            float altura = 1.90f;
            int idade = 15;
            string cidade = "Umuarama";
            string cpf = "1111111111";
            Controller.LerInfo(nome, altura, idade, cidade, cpf);

            Controller.AcharCad("NomeTeste");

            Assert.AreEqual(Controller.AcharCad("NomeTeste"), true);
        }

        [TestMethod]
        public void TesteAcharCadastroPorNomeNaoContemNome()
        {
            string nome = "NomeTeste";
            float altura = 1.90f;
            int idade = 15;
            string cidade = "Umuarama";
            string cpf = "1111111111";
            Controller.LerInfo(nome, altura, idade, cidade, cpf);

            Controller.AcharCad("NomeTeste2");

            Assert.AreNotEqual(Controller.AcharCad("NomeTeste2"), true);
        }
    }
}
