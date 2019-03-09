﻿using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Questor.Mio;

namespace Questor.Extensions
{
    public static class XmlSerializerEx
    {
        public static T Load<T>(this VirtualFile file) 
            where T : class
        {
            try
            {
                using (Stream stream = file.OpenRead())
                {
                    XmlSerializer xs = XmlSerializer(typeof(T));
                    return xs.Deserialize(stream) as T;
                }
            }
            catch(Exception ex)
            {
                // do nothing
            }
            return default(T);
        }

        public static T Load<T>(this string filename) 
            where T : class
        {
            try
            {
                using (Stream stream = File.OpenRead(filename))
                {
                    XmlSerializer xs = XmlSerializer(typeof(T));
                    return xs.Deserialize(stream) as T;
                }
            }
            catch(Exception ex)
            {
                // do nothing
            }
            return default;
        }

        public static T LoadFromText<T>(string text) 
            where T : class
        {
            try
            {
                using (StringReader stream = new StringReader(text))
                {
                    XmlSerializer xs = XmlSerializer(typeof(T));
                    return xs.Deserialize(stream) as T;
                }
            }
            catch
            {
                //
            }
            return default;
        }

        private class SwUtf8 : StringWriter
        {
            public SwUtf8(StringBuilder sb) : base(sb)
            {
            }

            public override Encoding Encoding
            {
                get
                {
                    return Encoding.UTF8;
                }
            }
        }

        public static string Serialize(this object value)
        {
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new SwUtf8(sb))
            {
                XmlSerializer xs = XmlSerializer(value.GetType());
                xs.Serialize(sw, value);
                return sb.ToString();
            }
        }

        public static void Save<T>(this T value, VirtualFile file)
        {
            Save(file, value);
        }

        public static void Save<T>(VirtualFile file, T value)
        {
            using (Stream stream = file.OpenWrite())
            {
                XmlSerializer xs = XmlSerializer(typeof(T));
                xs.Serialize(stream, value);
                stream.Flush();
                stream.Close();
            }
        }

        public static void Save<T>(this T value, string filename)
        {
            Save(filename, value);
        }

        public static void Save<T>(string filename, T value)
        {
            using (FileStream stream = File.Create(filename))
            {
                XmlSerializer xs = XmlSerializer(typeof(T));
                xs.Serialize(stream, value);
                stream.Flush();
                stream.Close();
            }
        }
        
        private static XmlSerializer XmlSerializer(Type type) 
        {
            XmlSerializer xs = new XmlSerializer(type);
            xs.UnknownAttribute += Xs_UnknownAttribute;
            xs.UnknownElement += XsOnUnknownElement;
            xs.UnknownNode += Xs_UnknownNode;
            xs.UnreferencedObject += Xs_UnreferencedObject;
            return xs;
        }

        private static void Xs_UnreferencedObject(object sender, UnreferencedObjectEventArgs e)
        {
        }

        private static void Xs_UnknownNode(object sender, XmlNodeEventArgs e)
        {
        }

        private static void XsOnUnknownElement(object sender, XmlElementEventArgs e)
        {
        }

        private static void Xs_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
        }
    }
}
