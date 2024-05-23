using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;

namespace DummyData
{
    public partial class Form1 : Form
    {
        private static readonly string[] ApellidosEspanol = { "García", "Martínez", "López", "Sánchez" };
        private static readonly string[] ApellidosIngles = { "Smith", "Johnson", "Brown", "Taylor" };
        private static readonly string[] ApellidosFrances = { "Martin", "Bernard", "Dubois", "Thomas" };
        private static readonly string[] ApellidosAleman = { "Müller", "Schmidt", "Schneider", "Fischer" };
        private static readonly string[] Nombres = { "Juan", "María", "Luis", "Ana", "Carlos", "Laura" };

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            int cantidadRegistros = (int)numRegistros.Value;
            string formato = cbFormato.SelectedItem.ToString();

            List<Alumno> alumnos = GenerarDatosFicticios(cantidadRegistros);
            GuardarDatos(alumnos, formato);
        }

        private List<Alumno> GenerarDatosFicticios(int cantidad)
        {
            Random rand = new Random();
            List<Alumno> alumnos = new List<Alumno>();

            for (int i = 0; i < cantidad; i++)
            {
                string apellido1 = ObtenerElementoAleatorio(rand, ApellidosEspanol, ApellidosIngles, ApellidosFrances, ApellidosAleman);
                string apellido2 = ObtenerElementoAleatorio(rand, ApellidosEspanol, ApellidosIngles, ApellidosFrances, ApellidosAleman);
                string nombre = Nombres[rand.Next(Nombres.Length)];
                string correo = $"{nombre.ToLower()}.{apellido1.ToLower()}@unison.com";
                DateTime fechaNacimiento = new DateTime(rand.Next(1990, 2010), rand.Next(1, 13), rand.Next(1, 29));

                alumnos.Add(new Alumno
                {
                    Matricula = i + 1,
                    Apellido1 = apellido1,
                    Apellido2 = apellido2,
                    Nombres = nombre,
                    Correo = correo,
                    FechaNacimiento = fechaNacimiento
                });
            }

            return alumnos;
        }

        private string ObtenerElementoAleatorio(Random rand, params string[][] arreglos)
        {
            string[] arreglo = arreglos[rand.Next(arreglos.Length)];
            return arreglo[rand.Next(arreglo.Length)];
        }

        private void GuardarDatos(List<Alumno> alumnos, string formato)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = $"{formato.ToUpper()} files (*.{formato.ToLower()})|*.{formato.ToLower()}";
            saveFileDialog.Title = "Guardar Datos Generados";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                switch (formato.ToLower())
                {
                    case "sql":
                        File.WriteAllText(filePath, GenerarSQL(alumnos));
                        break;
                    case "csv":
                        File.WriteAllText(filePath, GenerarCSV(alumnos));
                        break;
                    case "xml":
                        GenerarXML(alumnos, filePath);
                        break;
                    case "json":
                        File.WriteAllText(filePath, GenerarJSON(alumnos));
                        break;
                }

                MessageBox.Show("Archivo guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string GenerarSQL(List<Alumno> alumnos)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO Alumnos (Matricula, Apellido1, Apellido2, Nombres, Correo, FechaNacimiento) VALUES");
            for (int i = 0; i < alumnos.Count; i++)
            {
                Alumno alumno = alumnos[i];
                sb.AppendFormat("({0}, '{1}', '{2}', '{3}', '{4}', '{5:yyyy-MM-dd}')",
                    alumno.Matricula, alumno.Apellido1, alumno.Apellido2, alumno.Nombres, alumno.Correo, alumno.FechaNacimiento);
                if (i < alumnos.Count - 1)
                {
                    sb.AppendLine(",");
                }
                else
                {
                    sb.AppendLine(";");
                }
            }
            return sb.ToString();
        }

        private string GenerarCSV(List<Alumno> alumnos)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Matricula,Apellido1,Apellido2,Nombres,Correo,FechaNacimiento");
            foreach (var alumno in alumnos)
            {
                sb.AppendLine($"{alumno.Matricula},{alumno.Apellido1},{alumno.Apellido2},{alumno.Nombres},{alumno.Correo},{alumno.FechaNacimiento:yyyy-MM-dd}");
            }
            return sb.ToString();
        }

        private void GenerarXML(List<Alumno> alumnos, string filePath)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(filePath, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Alumnos");

                foreach (var alumno in alumnos)
                {
                    writer.WriteStartElement("Alumno");

                    writer.WriteElementString("Matricula", alumno.Matricula.ToString());
                    writer.WriteElementString("Apellido1", alumno.Apellido1);
                    writer.WriteElementString("Apellido2", alumno.Apellido2);
                    writer.WriteElementString("Nombres", alumno.Nombres);
                    writer.WriteElementString("Correo", alumno.Correo);
                    writer.WriteElementString("FechaNacimiento", alumno.FechaNacimiento.ToString("yyyy-MM-dd"));

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private string GenerarJSON(List<Alumno> alumnos)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(alumnos, Newtonsoft.Json.Formatting.Indented);
        }

    }

    public class Alumno
    {
        public int Matricula { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Nombres { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
