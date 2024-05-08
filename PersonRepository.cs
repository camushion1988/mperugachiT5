using mperugachiAC5.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mperugachiAC5
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLiteConnection conn;
        public string StatusMessage { get; set; }

        private void Init()
        {
            if (conn is not null)
                return;
            conn = new(_dbPath);
            conn.CreateTable<Persona>();
        }

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre es requerido");
                Persona person = new() { Name = name };
                result = conn.Insert(person);
                StatusMessage = string.Format("Se inserto una persona", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al insertar una persona", name, ex.Message);
            }
        }

        public List<Persona> getAllPeople()
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al listar", ex.Message);
            }
            return new List<Persona>();
        }
    }
}
