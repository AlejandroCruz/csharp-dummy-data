C# Application: File Read/Write
=====================================

This repository includes source files for a C# program that finds a comma separated value (CSV) data file, edits specified data and creates a new CSV file. The output lines serve as database dummy data for development purposes. User can specify which "column" values to edit and the amount of lines to produce. The application will iterate through each specified element, incrementing the value by one, corresponding to its format: number, character, date.

In the case that a raw data file already exists produced by a DB system, this data can be used as template. The program will read raw data and remove undesired characters wrapping each value, usually double quotes. Final output will be written to a new file with specified name and path in system, maintaining data integrity of old file. CSV output file is ideally suited for uploading to DB table.

![Console output](https://github.com/AlejandroCruz/csharp-dummy-data/blob/CodeRestructure/FileReadWrite/_resources/FileReadWrite_Display-table.PNG)