# Cron Expression Parser - Deliveroo Coding Challenge
Simple C# cron parser that uses standard cron format with five time fields (minute, hour, day of month, month, and day of week) plus a command. The cron string is passed to the application on the command line as a single argument on a single line.  

## How to Run the program on MacOS/Linux
  - Firstly navigate to the folder containing the cronparser.cs file in         
    terminal
  
  ![Example Image](/example_images/example2.png)
  
  - Enter "mcs cronparser.cs" in the terminal to compile the application
  
  ![Example Image](/example_images/example3.png)
  
  - Enter "mono cronparser.cs [COMMAND LINE ARGUMENTS]" to run the  
    application
  
  ![Example Image](/example_images/example4.png)
  
  ### Quirks on MacOS/Linux
  - May have to use backslash ("\\") when using all ("\*") symbol, as the terminal will think that the user is asking for the 
    names of all the files in the current directory
  
## Command Line Arguments
The command line arguments consist of five arguments which are minute, hour, day of month, month, and day of week plus a command; seperated by a space. Which can be expressed as:

**deliveroocronparser USER$ mono crosparser.exe [MINUTE] [HOUR] [DAY OF MONTH] [MONTH] [DAY OF WEEK] [COMMAND]**

Below shows an example screenshot of the application running with the command line arguments.  

![Example Image](/example_images/example1.png)

## Testing
Testing was implemented using the NUnit package/framework, the test scenarios were:
  - Testing "\*" symbolising all values
  - Testing "\*/<NUMBER>" symboling all values divided by a specified value
  - Testing ranges (e.g 1-5) symbolising all values between the two numbers
  - Testing specific values (e.g. 1,2,3) symboling only those values should be produced
 
 The Unit tests can be found in the project under "test.cs"
 
 
 
