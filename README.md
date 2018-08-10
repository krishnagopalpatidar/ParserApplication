# ParserApplication
ParserApplication

Please read below comments file and class wise to know more about intention/thoughts behind different code/design items in different places:-

************************************************************************************************************************************************************************************************
	1. Here, I kept two layer asp.net application- ParserUI and BusinessLayer, not using DataLayer. But, we can certainly have that if we have to 
           write our data operations etc. in our applications.
************************************************************************************************************************************************************************************************


******************************************************************************************************************************************************************************************
	2. ASSUMPTION ON PARSING OF GIVEN INPUT  (Got confirmation via Email on my assumption of parsing to be done) 
******************************************************************************************************************************************************************************************
After taking user input, when I do parsing I am just allowing alphabetical letters and two special characters which can be part of individual word-  1. Hypen (-)   2. Apostrophe (').
Earlier, I thought to consider more special characters as per English language like brackets/parenthesis, quotation marks(""), ellipsis(...) etc. , but then they will add 
more time and complexity (complexity to decide on actual sentences). Instead, I focus on other segments of program to be developed. 
*****************************************************************************************************************************************************************************************



****************************************************************************************************************************************************************************
	3. Design thoughts/decisions:-
****************************************************************************************************************************************************************************
(i). 'Single' responsibility principle:-
  Main classes like Parser, XmlConverter, CsvConverter, ConcreteConverterFactory, Sentence etc. are following one main respobility thus adhering to 'Single' Responsibility
  principle.


(ii). 'Open/Closed' Principle  (I had to Choose between Singleton and Open/Closed in this case):-
Initial thought was to make Parser class as Singleton. Let's say this application grows big in future and if there are different functionality like 
xml, csv writing example- different formats writing and other processing. Then this Parser singleton class's single object would have been used throughout
the application.

But, considering the point that if we need some specific parsing logic for any expected format (for example- allowing specific special characters in one format but not in other).
So in this case we might need customized parsing for a format.
So, going by this thought- decides to go for "Open/Closed" principle of SOLID principles. So, we keep Parser class normal class and its Parse method is
virtual. And both XmlConverter and CsvConverter classes inherit from Parser class. So, these XmlConverter and CsvConverter classes are open for extension.
So, this will completely depend on parsing needed from application. If its only one parsing always, Singleton can be used. But for now, going ahead with
"Open/Closed" principle considering points mentioned above.

So, current design is like below-

class Parser{
public virtual List<Sentence> Parse(string input){//method logic}
}

public class XmlConverter : Parser, IConverter
public class CsvConverter : Parser, IConverter

Currently both these XmlConverter and CsvConverter classes use existing inherited Parse method. If any of these writer class or any other new class in future
need customization, they can override Parse method.


(iii). FactoryMethod design pattern:-
   ConverterFactory and ConcreteConverterFactory classes


****************************************************************************************************************************************************************************



*********************************************************************************************************************************************************************
	4.
	 File name- 
	 Class name- Constants
*********************************************************************************************************************************************************************
Here, I took these 3 xml declaration related constant strings assuming if this will be big application to create different 
   xml files for different things. Then, it would be good to maintain consistency across all xml file generation logic.
*********************************************************************************************************************************************************************


*********************************************************************************************************************************************************************
	5.
	 File name- Global.asax
*********************************************************************************************************************************************************************
 Custom error handling logic is left blank in Global.asax. We can add as per our need. Currently, we show only DefaultErrorPage.
*********************************************************************************************************************************************************************
