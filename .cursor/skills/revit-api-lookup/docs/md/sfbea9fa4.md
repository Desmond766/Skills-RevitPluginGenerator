---
kind: method
id: M:Autodesk.Revit.DB.IFC.ImporterIFCUtils.GetLocalFileName(Autodesk.Revit.DB.Document,System.String)
source: html/a89c3feb-ae9c-ef11-a6ad-15af9913a4e4.htm
---
# Autodesk.Revit.DB.IFC.ImporterIFCUtils.GetLocalFileName Method

Get the local file name, including the path, corresponding to a linked IFC file.
 This will create a local copy of the IFC file if necessary.

## Syntax (C#)
```csharp
public static string GetLocalFileName(
	Document aDoc,
	string fileName
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - The document that will contain the IFC link.
- **fileName** (`System.String`) - The original file name and path.

## Returns
The local file name and path corresponding to the input file name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Can't process file name.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

