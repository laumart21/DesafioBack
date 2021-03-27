using DesafioBack.Domain.Domains;
using DesafioBack.Domain.Models;
using DesafioBack.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Desafio.Api.Titulos.Test
{
    public class UnitTest1
    {
        //private readonly Titulo _titulo;
        private readonly PopulaTitulo _populaTitulo;
        private readonly TituloCalculoJuros _tituloCalculoJuros;
        private readonly TituloCalculoMulta _tituloCalculoMulta;
        private readonly TituloCalculoValorOriginal _tituloValorOriginal;
        //private readonly int _juros = 1;
        //private readonly int _multa = 2;

        ITestOutputHelper _itestOutputHelper;
        public UnitTest1(ITestOutputHelper testOutputHelper)
        {
            //_titulo = new Titulo();
            _populaTitulo = new PopulaTitulo();
            _tituloCalculoJuros = new TituloCalculoJuros();
            _tituloCalculoMulta = new TituloCalculoMulta();
            _tituloValorOriginal = new TituloCalculoValorOriginal();
            _itestOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Calculo_Multa()
        {
            Assert.Equal(7.2M, _tituloCalculoMulta.Calcular(_populaTitulo.titulo));
        }

        [Fact]
        public void Calculo_Juros()
        {
            Assert.Equal(16.48M, _tituloCalculoJuros.Calcular(_populaTitulo.titulo));
        }

        [Fact]
        public void Calculo_Valor_Atualizado()
        {
            Assert.Equal(383.68M, _tituloValorOriginal.Calcular(_populaTitulo.titulo) +
                             _tituloCalculoMulta.Calcular(_populaTitulo.titulo) + 
                             _tituloCalculoJuros.Calcular(_populaTitulo.titulo));
        }
    }
}
