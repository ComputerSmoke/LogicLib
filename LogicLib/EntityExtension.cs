using LogicLib.Devices;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib
{
    public class MissingChildException(string msg) : Exception(msg) { };
    public static class EntityExtension
    {
        //Search children of entity for specified component
        public static T FindInChild<T>(this Entity entity) where T : EntityComponent
        {
            List<T> occurances = FindAllInChild<T>(entity);
            if(occurances.Count > 0) 
                return occurances[0];
            throw new MissingChildException("no child with component of this type");
        }
        //Find all components of specified type in children of this entity
        public static List<T> FindAllInChild<T>(this Entity entity) where T: EntityComponent
        {
            List<T> res = [];
            foreach (Entity child in entity.GetChildren())
                res.AddRange(child.GetAll<T>());
            return res;
        }
    }
}
