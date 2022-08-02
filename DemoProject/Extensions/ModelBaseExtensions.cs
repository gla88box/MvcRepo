using System;
using DemoProject.Models;

namespace DemoProject.Extensions
{
    public static class ModelBaseExtensions
    {
        /// <summary>
        /// Populates the basic data for a new record
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static T SetCreateDefaultSettings<T>(this T model) where T : ModelBase
        {
            //This is a hack as the database context is using the UI Models and a separated out into another project with its own models
            model.Id = Guid.NewGuid();
            model.IsActive = true;
            model.CreatedOn = DateTime.Now;
            return model;
        }
    }
}
