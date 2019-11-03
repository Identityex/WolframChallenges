using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WolframChallenges.Shared
{
    public interface IUtilities
    {
        string GetListString<T>(T myList, string contString = null);
        string GetArrayString(object[] myList, string contString = null);
        bool IsList(object o);
        bool IsArray(object o);
    }

    /// <summary>
    /// Utilities to be utilized multiple times
    /// </summary>
    public class Utilities : IUtilities
    {
        
        public Utilities() { }

        /// <summary>
        /// Takes an list and converts it to a visable string 
        /// </summary>
        /// <param name="myList">input list</param>
        /// <returns>a list formatted as a string for viewing purposes</returns>
        public string GetListString<T>(T inputList, string contString = null)
        {
            string listString = "[";
            int i = 0;

            if(inputList is List<List<object>>)
            {
                foreach (List<object> obj in (List<List<object>>)(object)inputList)
                {
                    listString += GetListString(obj, listString);
                    if (((List<List<object>>)(object)inputList).Count != i + 1)
                    {
                        listString += ",";
                    }
                    i++;
                }
            }
            else
            {
                foreach (object obj in (List<object>)(object)inputList)
                {

                    var myList = (List<object>)(object)inputList;
                    if (IsList(obj) || IsArray(obj))
                    {
                        listString += GetListString((List<object>)obj, listString);
                        if (myList.Count != i + 1)
                        {
                            listString += ",";
                        }
                    }
                    else if (IsArray(obj))
                    {
                        listString += GetArrayString((object[])obj, listString);
                        if (myList.Count != i + 1)
                        {
                            listString += ",";
                        }
                    }
                    else
                    {
                        listString += obj.ToString();
                        if (myList.Count != i + 1)
                        {
                            listString += ",";
                        }
                    }
                    i++;
                }
            }

            
            
            return listString += "]";
        }

        /// <summary>
        /// Takes an array and converts it to a visable string 
        /// </summary>
        /// <param name="myList">input list</param>
        /// <returns>a list formatted as a string for viewing purposes</returns>
        public string GetArrayString(object[] myList, string contString = null)
        {
            string listString = "[";
            int i = 0;
            foreach (object obj in myList)
            {
                if (IsList(obj) || IsArray(obj))
                {
                    listString += GetListString((List<object>) obj, listString);
                    if(myList.Length != i+1)
                    {
                        listString += ",";
                    }
                }
                else if (IsArray(obj))
                {
                    listString += GetArrayString((object[] )obj, listString);
                    if (myList.Length != i+1)
                    {
                        listString += ",";
                    }
                }
                else
                {
                    listString += obj.ToString();
                    if (myList.Length != i+1)
                    {
                        listString += ",";
                    }
                }
                i++;
            }

            return listString += "]";
        }

        public bool IsList(object o)
        {
            try
            {
                List<object> list = (List<object>)o;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsArray(object o)
        {
            try
            {
                object[] list = (object[])o;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
