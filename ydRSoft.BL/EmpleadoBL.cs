using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ydRSoft.Model;
using ydRSoft.ViewModel;
using ydRSoft.DataBase;
using System.Security.Cryptography;

namespace ydRSoft.BL
{
    public class EmpleadoBL
    {
        ydRSoftEntities context = new ydRSoftEntities();

        public int AddEmpleado(EmpleadoViewModel vmEmpleado)
        {
            try
            {
                var resultado = new System.Data.Entity.Core.Objects.ObjectParameter("ID", 0);
                var temp = context.sp_Insert_Empleado(vmEmpleado.DNI, vmEmpleado.ID_Cargo,  vmEmpleado.Nombres.ToUpper(),
                    vmEmpleado.Apellidos.ToUpper(), vmEmpleado.Correo.ToLower(),Encryptar(vmEmpleado.DNI),vmEmpleado.ID_Sexo, resultado);

                int objId = Convert.ToInt32(resultado.Value);
                return objId;
            }
            catch { return -1; }
        }

        public EmpleadoModel getLogin(LoginModel mLogin)
        {
            try
            {
                var objModel = context.Empleado.Where(x => x.DNI == mLogin.DNI).FirstOrDefault();
                EmpleadoModel temp = new EmpleadoModel();
                if (objModel != null) { 

                    string clave = Decryptar(objModel.Clave);
                    if (clave == mLogin.Clave)
                    {
                        temp.Nombres = getNombres(objModel.Nombres, objModel.Apellidos);
                        temp.DNI = objModel.DNI;
                        if (clave == objModel.DNI) {
                            temp.ID = 2;
                            return temp;
                        }

                        temp.ID = 1;
                        temp.Cargo = objModel.Cargo.Nombre;
                        temp.Apellidos = objModel.Apellidos;
                        temp.ID_Cargo = objModel.ID_Cargo;
                        temp.Correo = objModel.Correo;
                        temp.ID_Sexo = objModel.Sexo;
                    }
                    else {
                        temp.ID = -1;
                    }
                }
                return temp;
            }
            catch { return null; }
        }
        

        public int ActualizaClave(string DNI,string Clave)
        {
            try
            {                
                var objModel = context.Empleado.Where(x => x.DNI == DNI).FirstOrDefault();
                if (objModel != null)
                {
                    byte[] pass = Encryptar(Clave);
                    objModel.Clave = pass;
                    context.SaveChanges();
                    return 1;
                }

                return 0;
            }
            catch { return -1; }
        }

        public List<TipoModel> listaCargo(int IdCargo) {

            try {
                List<TipoModel> vmLista = new List<TipoModel>();

                var lista = context.Cargo.ToList();
                if (lista != null) {
                    foreach (var item in lista) {
                        TipoModel temp = new TipoModel(item.ID, item.Nombre);
                        vmLista.Add(temp);                                         
                    }
                }

                if (IdCargo != ydR.Cargos.ADMINISTRADOR) {
                    vmLista.RemoveAt(vmLista.Count() - 1);
                }
                
                return vmLista;

            } catch {
                return null;
            }
        }

        #region Encryptar y Decryptar

        private byte[] Encryptar(string texto)
        {
            string hash = "ydRSoftPass";
            byte[] data = UTF8Encoding.UTF8.GetBytes(texto);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));

                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    string encrip = Convert.ToBase64String(results, 0, results.Length);
                    return results;
                }
            }
        }

        private string Decryptar(byte[] data)
        {
            string hash = "ydRSoftPass";

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));

                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);

                    string encrip = UTF8Encoding.UTF8.GetString(results);
                    return encrip;
                }
            }
        }

        private string getNombres(string nombre, string apellido) {
            try {
                string palabra = "";
                for(int i = 0; i < nombre.Count(); i++)
                {
                    if (nombre[i] == ' ') {
                        for (int j = 0; j < apellido.Count(); j++)
                        {
                            if (apellido[i] == ' ')
                                return palabra;

                            palabra = palabra + nombre[i];
                        }
                    }

                    palabra = palabra + nombre[i];

                }
                
                return palabra;
            } catch {
                return "Sin Nombre";
            }
        }
        #endregion

    }
}


/*********
 
     
     var objModel = context.Empleados.Where(x => x.DNI == vmEmpleado.DNI).FirstOrDefault();

                if (objModel == null) {

                    var objUltimo = context.Empleados.OrderByDescending(x => x.ID).First();

                    int IdEmpleado = 1;
                    if (objUltimo != null) {
                        IdEmpleado = objUltimo.ID + 1;
                    }

                    Empleados model = new Empleados();
                    model.ID = IdEmpleado;
                    model.Nombres = vmEmpleado.Nombres;
                    model.Apellidos = vmEmpleado.Apellidos;
                    model.DNI = vmEmpleado.DNI;
                    model.Correo = vmEmpleado.Correo;
                    model.ID_Cargo = vmEmpleado.ID_Cargo;
                    model.Direccion = vmEmpleado.Direccion;
                    model.Sexo = vmEmpleado.ID_Sexo;
                    model.Estado = 1;
                    model.Fecha_Reg = DateTime.Now;

                    context.Empleados.Add(model);
                    context.SaveChanges();

                    return IdEmpleado;
                }
     */
