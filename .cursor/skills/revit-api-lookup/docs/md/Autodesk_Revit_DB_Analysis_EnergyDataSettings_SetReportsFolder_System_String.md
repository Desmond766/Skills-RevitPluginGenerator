---
kind: method
id: M:Autodesk.Revit.DB.Analysis.EnergyDataSettings.SetReportsFolder(System.String)
source: html/d13d3951-5f37-5774-6fde-44131f676aa5.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.SetReportsFolder Method

Sets the reports folder path.

## Syntax (C#)
```csharp
public void SetReportsFolder(
	string folderPath
)
```

## Parameters
- **folderPath** (`System.String`) - The string to specify the path. It may include the special label for project name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - A folder path cannot contain special characters.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

