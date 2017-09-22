
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mono.Data.SqliteClient;
namespace Assets.scripts.Entidades
{
    class ImagenPregunta : Pregunta
    {
        int idImagenPregunta;
        string rutaImagenPregunta;
        string descripcionImagenPregunta;
        List<Imagen> imagenes;




        public void cargarImagenes()
        {

            this.imagenes = new List<Imagen>();

            MyDBConnection oCnn = new MyDBConnection();
            oCnn.conectar();
            IDataReader odr = oCnn.select(ControllerSQL.Imagen_ListarImagen(this.idImagenPregunta.ToString()));
            while (odr.Read())
            {
                Imagen unaImagen = new Imagen();
                unaImagen.IdImagen = odr.GetInt32(0);
                unaImagen.RutaImagen = odr.GetString(1);
                unaImagen.ImagenPregunta_id = odr.GetInt32(2);
                unaImagen.Correcta = odr.GetInt32(3);
                imagenes.Add(unaImagen);
            }
            if (odr != null)
            {
                if (!odr.IsClosed)
                    odr.Close();
            }
            oCnn.cerrar();


        }

        public ImagenPregunta() { }
        public ImagenPregunta(int idImagenPregunta, string rutaImagenPregunta, string descripcionImagenPregunta)
        {
            this.idImagenPregunta = idImagenPregunta;
            this.rutaImagenPregunta = rutaImagenPregunta;
            this.descripcionImagenPregunta = descripcionImagenPregunta;
        }

        public int IdImagenPregunta
        {
            get
            {
                return idImagenPregunta;
            }

            set
            {
                idImagenPregunta = value;
            }
        }

        public string RutaImagenPregunta
        {
            get
            {
                return rutaImagenPregunta;
            }

            set
            {
                rutaImagenPregunta = value;
            }
        }

        public string DescripcionImagenPregunta
        {
            get
            {
                return descripcionImagenPregunta;
            }

            set
            {
                descripcionImagenPregunta = value;
            }
        }

        public List<Imagen> Imagenes
        {
            get
            {
                return imagenes;
            }

            set
            {
                imagenes = value;
            }
        }
    }
}
