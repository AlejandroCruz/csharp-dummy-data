C# Application: File Read/Write
=====================================

This repository includes files for a C# program that finds a comma separated value (CSV) data file, edits specified data values and creates a new CSV file with the edits. The idea behind the program is producing dummy data for development purposes. The user creates a raw file with a heading line and a record line. In the case that a raw data file already exists produced by a DB system, the program will read and remove quotaion wrapping the values. Final output will have the new data without quotes for uploading to a DB table.

![Console output](https://github.com/AlejandroCruz/mvc-app/blob/master/_resources/MovieApp_User-Interface.PNG)