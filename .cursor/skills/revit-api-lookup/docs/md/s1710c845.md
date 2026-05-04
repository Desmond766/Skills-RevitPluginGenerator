---
kind: method
id: M:Autodesk.Revit.DB.Document.Import(System.String,Autodesk.Revit.DB.GBXMLImportOptions)
zh: 导入
source: html/7a6bffbf-b0fe-b047-1008-36d57f495417.htm
---
# Autodesk.Revit.DB.Document.Import Method

**中文**: 导入

Imports a Green-Building XML file into the document.

## Syntax (C#)
```csharp
public bool Import(
	string file,
	GBXMLImportOptions options
)
```

## Parameters
- **file** (`System.String`) - Full path of the file to import. File must exist.
- **options** (`Autodesk.Revit.DB.GBXMLImportOptions`) - Various options applicable to GBXml import. If Nothing nullptr a null reference ( Nothing in Visual Basic) , all options will be set to their respective default values.

## Returns
True if successful, otherwise False.

## Remarks
This method is available only in MEP. 
Though the 'options' argument is not currently used, an object still must be provided (may be Nothing nullptr a null reference ( Nothing in Visual Basic) ).
The method will return False if not succeed. e.g when the input xml file does not contain any result elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when file argument is Nothing nullptr a null reference ( Nothing in Visual Basic) or empty.
- **Autodesk.Revit.Exceptions.FileNotFoundException** - Thrown when the file specified does not exist.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when no file is specified or if the file is not a valid gbXML file or does not contain any result elements.

