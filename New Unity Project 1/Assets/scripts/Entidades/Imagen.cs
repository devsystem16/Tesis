using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.scripts.Entidades
{
   public class Imagen 
    {

        int idImagen;
        int imagenPregunta_id;
        string rutaImagen;
        int correcta;

        public Imagen() { }
        public Imagen(int idImagen, int imagenPregunta_id, string rutaImagen)
        {
            this.idImagen = idImagen;
            this.imagenPregunta_id = imagenPregunta_id;
            this.rutaImagen = rutaImagen;
        }

        public int IdImagen
        {
            get
            {
                return idImagen;
            }

            set
            {
                idImagen = value;
            }
        }

        public int ImagenPregunta_id
        {
            get
            {
                return imagenPregunta_id;
            }

            set
            {
                imagenPregunta_id = value;
            }
        }

        public string RutaImagen
        {
            get
            {
                return rutaImagen;
            }

            set
            {
                rutaImagen = value;
            }
        }

        public int Correcta
        {
            get
            {
                return correcta;
            }

            set
            {
                correcta = value;
            }
        }
    }
}
