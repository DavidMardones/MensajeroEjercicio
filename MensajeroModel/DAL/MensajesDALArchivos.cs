﻿using MensajeroModel.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroModel.DAL
{
    public class MensajesDALArchivos : IMensajesDAL
    {
        private static string url = Directory.GetCurrentDirectory();
        private static string archivo = url + "/mensajes.txt";
        public void AgregarMensaje(Mensaje mensaje)
        {
            try
            {
                using (StreamWriter write = new StreamWriter(archivo, true))
                {
                    write.WriteLine(mensaje.Nombre + ";" + mensaje.Texto + ";" + mensaje.Tipo);
                    write.Flush();
                }
            }
            catch (Exception ex)
            {

            }

        }
            public List<Mensaje> ObtenerMensajes()
            {
                List<Mensaje> Lista = new List<Mensaje>();
                try
                {
                    using (StreamReader read = new StreamReader(archivo))
                    {
                        string texto = "";
                        do
                        {
                            texto = read.ReadLine();
                            if (texto != null)
                            {
                                string[] arr = texto.Trim().Split(';');
                                Mensaje mensaje = new Mensaje()
                                {
                                    Nombre = arr[0],
                                    Texto = arr[1],
                                    Tipo = arr[2]
                                };


                        } while (texto != null);
                    }
                }
                catch (Exception ex)
                {
                    Lista = null;
                }
                return Lista;
            }

        }

    }


