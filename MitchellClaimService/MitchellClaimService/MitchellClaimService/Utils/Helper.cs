using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Configuration;
using System.Text;
using System.ServiceModel;
using System.Xml.Linq;
using MitchellClaimService.DataContracts;

namespace MitchellClaimService.Utils
{
    /// <summary>
    /// Helper static methods.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// This method is used to get string from object, serialized into xml 
        /// </summary>
        /// <param name="classObject"></param>
        /// <returns></returns>
        public static string CreateXml(Object classObject)
        {
            if (classObject != null)
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlSerializer xmlSerializer = new XmlSerializer(classObject.GetType());
                using (MemoryStream xmlStream = new MemoryStream())
                {
                    xmlSerializer.Serialize(xmlStream, classObject);
                    xmlStream.Position = 0;
                    xmlDoc.Load(xmlStream);
                    return xmlDoc.InnerXml;
                }
            }
            return null;
        }

        /// <summary>
        /// This method returns object from the xml string, using xml serialization.
        /// </summary>
        /// <param name="xmlString"></param>
        /// <param name="classObject"></param>
        /// <returns></returns>
        public static Object CreateObject(string xmlString, Object classObject)
        {
            if (classObject != null)
            {
                try
                {
                    XmlSerializer oXmlSerializer = new XmlSerializer(classObject.GetType());
                    classObject = oXmlSerializer.Deserialize(new StringReader(xmlString));
                }
                catch(Exception ex)
                {
                    if (ex.InnerException != null)
                        throw new FaultException(ex.InnerException.Message);
                    else
                        throw new FaultException(ex.Message);
                }
            }
            return classObject;
        }
    }
}