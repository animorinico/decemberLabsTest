using System.Xml;

namespace DecemberLabsTest.utils
{
    /// <summary>
    /// Contains a configurated path.
    /// This path is used by methods that returns parametrized values in external files of the platform.
    /// </summary>
    class ParameterReader
    {
        private static readonly string path = @"..\..\..\resources\parameter_files\";

        /// <summary>
        /// It allows as to get values from an external document. 
        /// </summary>
        /// <remarks>
        /// The values are all the identifiers/hooks of the web elements.
        /// </remarks>
        /// <param name="fathernode">Node with multple values.</param>
        /// <param name="node">Key node which we want to get the value.</param>
        /// <returns>Node value.</returns>
        public static string GetTestValues(string fathernode, string node)
        {
            XmlDocument testValues = new XmlDocument();
            testValues.Load(path + "TestValues.xml");
            return ((XmlElement)testValues.GetElementsByTagName(fathernode)[0]).GetElementsByTagName(node)[0].InnerText;
        }

        /// <summary>
        /// It allows as to get values from an external document. 
        /// </summary>
        /// <remarks>
        /// The values are necessary for the tests.
        /// </remarks>
        /// <param name="fathernode">Node with multple values.</param>
        /// <param name="node">Key node which we want to get the value.</param>
        /// <returns>Node value.</returns>
        public static string GetScreenComponents(string fathernode, string node)
        {
            XmlDocument screenComponents = new XmlDocument();
            screenComponents.Load(path + "ScreenComponents.xml");
            return ((XmlElement)screenComponents.GetElementsByTagName(fathernode)[0]).GetElementsByTagName(node)[0].InnerText;
        }

        /// <summary>
        /// It allows as to get values from an external document. 
        /// </summary>
        /// <remarks>
        /// The values are needed to configure the environment.
        /// </remarks>
        /// <param name="node">Key node which we want to get the value.</param>
        /// <returns>Node value.</returns>
        public static string GetEnvironment(string node)
        {
            XmlDocument screenComponents = new XmlDocument();
            screenComponents.Load(path + "Environment.xml");
            return ((XmlElement)screenComponents.GetElementsByTagName("Environment")[0]).GetElementsByTagName(node)[0].InnerText;
        }

        /// <summary>
        /// It allows us the get credential values stored in an external XML document. 
        /// </summary>
        /// <param name="node">Key node which we want to get the value.</param>
        /// <returns>Node value.</returns>
        public static string GetCredenciales(string node)
        {
            XmlDocument testValues = new XmlDocument();
            testValues.Load(@"C:\Credentials\UsersSigb.xml");
            return ((XmlElement)testValues.GetElementsByTagName("UsersSigb")[0]).GetElementsByTagName(node)[0].InnerText;
        }
    }
}
