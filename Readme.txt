Set Emergent project as Startup Project and Run
Will require .NET Core installed

Thoughts on Emergent Software Code Challenge
* First thought is to gather requirements
    * Create a website
    * Users will provide input of version number
    * Format of version strings consists of three parts (major.minor.patch)
        * My assumption here is that the versions are numbers but this would be a question I would ask
        * Also, if they are not always numbers, next question is how you would sort them
        * More than major.minor.patch will be ignored
    * Minor and Patch values are not always provided, if not provided, they default to 0
* Build solution for website considerations
    * Http is an option during ASP.NET Core setup, always https was selected and is recommended
* Beginning development decisions
    * Beautifying not worth doing because it would be more valuable to get the customer's opinion before investing time
        Left bootstrap/jquery css/js libraries in from default template because of minor usage
        Possible beautifying includes 
            * multiple cards per row
            * buttons and inputs using bootstrap classes
    * I went with a more intelligent Software object, because to keep it in the string format by default
        means that every time you search, you have to convert the string to numbers, converting the string to correct
        version format earlier will allow the application to fail faster if there is an issue with the Software data.
        Shouldn't need to wait until a search to know that the data is bad
    * Use Singleton because we only need one version of the SoftwareManager, anything more and it's wasted
        No race conditions or async issues should occur
    * Am not building async though that would be my default for a normal application since a normal application would user
        a database, API, etc.; at minimum requiring some form of IO.
    * Any limit on size of version numbers?  I made them int, but there's no requirement for size
    * Page load vs. ajax type calls are a design decision based on needs of the front end
        Since it's not in the requirements, I went with page loads to be simpler
        Ajax calls would likely be more performant, less data, but more maintenance
    * No sorting in requirements, could be useful to sort so that the results made more sense
        Linq OrderBy and ThenBy easy change
    * Currently the Developer Exception Page shows while in development, would avoid showing that for a public site
        to reduce info given to malicious users