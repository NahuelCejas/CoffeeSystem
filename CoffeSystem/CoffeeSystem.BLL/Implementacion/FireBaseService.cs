using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeSystem.BLL.Interfaces;
using Firebase.Auth;
using Firebase.Storage;
using CoffeeSystem.Entity;
using CoffeeSystem.DAL.Interfaces;


namespace CoffeeSystem.BLL.Implementacion
{
    public class FireBaseService : IFireBaseService
    {
        private readonly IGenericRepository<Configuracion> _repositorio;

        public FireBaseService(IGenericRepository<Configuracion> repositorio)
        {
            _repositorio = repositorio;
        }   
        
        public async Task<string> SubirStorage(Stream streamArchivo, string carpetaDestino, string nombreArchivo)
        {
            string urlImagen = "";

            try
            {
                IQueryable<Configuracion> query = await _repositorio.Consultar(c => c.Recurso.Equals("FireBase_Storage"));

                Dictionary<string, string> config = query.ToDictionary(keySelector : c => c.Propiedad, elementSelector : c => c.Valor);

                var auth = new FirebaseAuthProvider(new FirebaseConfig(config["api_key"]));
                var a = await auth.SignInWithEmailAndPasswordAsync(config["email"], config["clave"]);

                var cancellation = new CancellationTokenSource();

                var task = new FirebaseStorage(
                   config["ruta"],
                   new FirebaseStorageOptions
                   {
                       AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                       ThrowOnCancel = true
                   })
                    .Child(config[carpetaDestino])
                    .Child(nombreArchivo)
                    .PutAsync(streamArchivo, cancellation.Token);
                   
                urlImagen = await task;
            }
            catch
            {
                urlImagen = "";
            }

            return urlImagen;
        }

        public async Task<bool> EliminarStorage(string carpetaDestino, string nombreArchivo)
        {
            try
            {
                IQueryable<Configuracion> query = await _repositorio.Consultar(c => c.Recurso.Equals("FireBase_Storage"));

                Dictionary<string, string> config = query.ToDictionary(keySelector: c => c.Propiedad, elementSelector: c => c.Valor);

                var auth = new FirebaseAuthProvider(new FirebaseConfig(config["api_key"]));
                var a = await auth.SignInWithEmailAndPasswordAsync(config["email"], config["clave"]);

                var cancellation = new CancellationTokenSource();

                var task = new FirebaseStorage(
                   config["ruta"],
                   new FirebaseStorageOptions
                   {
                       AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                       ThrowOnCancel = true
                   })
                    .Child(config[carpetaDestino])
                    .Child(nombreArchivo)
                    .DeleteAsync();

                await task;

                return true;
            }
            catch
            {
                return false;
            }
        }

        
    }
}
