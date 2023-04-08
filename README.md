# decemberLabsTest

----Hello!

The test was created using C# and Selenium with NUnit framework, also implementing POM.

Please, open the solution called "DecemberLabsTest.sln" in Visual Studio.

Once you open it, you will see different folders in the Solution Explorer section:

1) Pages - This folder contains the pages with the page objects and functions in it.
	 - Here you will see a class called "BasePage", this class contains the common 
	   functions that the child classes will use.
	 - The classes "AustinOfficePage" and "DecemberLabsMainPage" contains the objects 
	   and functions for these pages (the ones we need for the required test)

2) Test  - This folder contains the Test Suites and the TestBase
         - The TestBase is the father class which contains the Setups and Teardowns, 
           Driver configuration, ExtentReport configuration, that all the suites will use.
	   (Here in the Setup I added the first part of the test which is going to 
	   DecemberLabs page and verify Title/Menu. But this can be changed. Also the 
	   Setups/Teardowns can be added in the specific Suites if the projects requires it
	 - The Suite_AustinOffice contains the test created with all the steps separated in
	   "regions" to have an easy way to see what the code does.

3) Resources - This folder contains the parameters_files to use in the projects
             - The Environment.xml contains the Browser selection, URL, and the Extent Report
	       configuration.
	     - The TestValues.xml contains the values that we wanna verify in the tests.
	       Keeping these values separated makes the project more easy to adapt if needed.

4) Utils - This folder contains classes that implements general configurations for the project

	 - In Utils class there is the Driver Configuration and other functions to interact
         - The ExtentManager and StatusTests classes contains the functions to generate HTML reports
         - The ParameterReader contains the functions to read the parameters_files (XML)

Steps to run the tests:

	On the Solution Explorer, you can do right-click on "Suite_AustinOffice" and select 
	"Run Tests"
	Or you can simply do "Ctrl+R, A"

	To see the HTML report, you can go into the folder "ReportHTMLDecemberLabsTests"
	and click the report folder created. Inside there is the "index.html" report. 
	Double click on it, it will be opened in the browser.

Thank you!