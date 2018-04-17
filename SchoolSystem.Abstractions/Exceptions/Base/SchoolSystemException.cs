using System;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Resources;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SchoolSystem.Abstractions.Exceptions.Attributes;

namespace SchoolSystem.Abstractions.Exceptions.Base
{
    [StatusCode(HttpStatusCode.BadRequest)]
    public abstract class SchoolSystemException : ApplicationException
    {
        public ResourceManager ExceptionMessagesManager => ExceptionMessages.ResourceManager;
        public ResourceManager ExceptionCodesManager => ExceptionCodes.ResourceManager;

        [Log, Response]
        public override string Message => ExceptionMessagesManager.GetString(FriendlyTypeName) ?? String.Empty;

        [Log, Response] public virtual string Code => ExceptionCodesManager.GetString(FriendlyTypeName) ?? String.Empty;

        protected string FriendlyTypeName => GetType().Name.Split('.').First();

        public JObject GetLogObject()
        {
            var logObjects = GetObjectPropertiesWithAttribute<LogAttribute>();

            var thisJObject = JObject.FromObject(this);

            thisJObject.Add("AdditionalData", logObjects);

            return thisJObject;
        }

        public JObject GetResponseObject()
        {
            var responseObjects = GetObjectPropertiesWithAttribute<ResponseAttribute>();

            return responseObjects;
        }

        private JObject GetObjectPropertiesWithAttribute<TAttribute>()
            where TAttribute : Attribute
        {
            var logProperties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(info => info.GetCustomAttributes<TAttribute>().Any());

            var jObject = new JObject();

            var jsonSerializer = JsonSerializer.CreateDefault();

            foreach (var propertyInfo in logProperties)
            {
                var response = propertyInfo.GetGetMethod().Invoke(this, null);

                var property = response != null
                    ? JToken.FromObject(response, jsonSerializer)
                    : new JValue((object) null);

                jObject.Add(propertyInfo.Name, property);
            }

            return jObject;
        }
    }
}