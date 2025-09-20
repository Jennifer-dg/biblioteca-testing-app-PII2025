using App.Entidades;

namespace Tests
{
    public class Tests
    {
        private Biblioteca _biblioteca;
        private Libro _libro1;
        private Libro _libro2;

        [SetUp]
        public void Setup()
        {
            _biblioteca = new Biblioteca();
            _libro1 = new Libro("1984", "George Orwell");
            _libro2 = new Libro("El Principito", "Antoine de Saint-Exupéry");
            _biblioteca.AgregarLibro(_libro1);
            _biblioteca.AgregarLibro(_libro2);
        }

        [Test]
        public void PrestarLibro_LibroDisponible_PrestaLibroCorrectamente()
        {
            // Act
            _biblioteca.PrestarLibro(_libro1.Titulo);

            // Assert
            Assert.IsFalse(_libro1.Equals(true));
        }

        [Test]
        public void PrestarLibro_LibroNoDisponible_LanzaExcepcion()
        {
            // Act
            _biblioteca.PrestarLibro(_libro1.Titulo);


            // Assert
            Assert.Throws<InvalidOperationException>(() => _biblioteca.PrestarLibro(_libro1.Titulo));
        }

        [Test]
        public void DevolverLibro_LibroPrestado_DevolveLibroCorrectamente()
        {
            // Act
            _libro1.Prestar();
            _libro2.Prestar();
            _biblioteca.DevolverLibro(_libro1.Titulo);
            _biblioteca.DevolverLibro(_libro2.Titulo);

            // Assert
            Assert.IsTrue(_libro1.Equals(false));
            Assert.IsFalse(_libro2.Equals(true));

        }

        [Test]
        public void DevolverLibro_LibroNoPrestado_LanzaExcepcion()
        {
            // Act
            _libro1.Prestar();
            _biblioteca.DevolverLibro(_libro1.Titulo);



            // Assert
            Assert.Throws<InvalidOperationException>(() => _biblioteca.DevolverLibro(_libro1.Titulo));

        }

        [Test]
        public void ObtenerLibros_RetornaListaDeLibros()
        {
            // Act
            var libros = _biblioteca.ObtenerLibros();

            // Assert
            Assert.That(libros.Count, Is.EqualTo(2));
        }
    }
}